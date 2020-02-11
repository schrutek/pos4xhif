using Spg.TicketShop.Core.Dtos;
using Spg.TicketShop.Core.Eceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spg.TicketShop.Core.Services
{
    /// <summary>
    /// Stellt ein Service bereit, welches alle Abfragen an die REST API zur Verfügung stellt.
    /// Dafür muss die Permission INTERNET in Android bei externen Servern gesetzt werden. Außerdem
    /// muss die Firewall des Servers Verbindungen von diesem Port akzeptieren.
    /// </summary>
    public abstract class RestServiceBase
    {
        private readonly HttpClientHandler _handler;           // Genauere Steuerung des HttpClient
        private readonly HttpClient _client;                   // Einzige Instanz des HttpClient
        private UserDto _currentUser;                          // Aktuell angemeldeter Benutzer.

        // Properties werden von System.Text.Json in camelCase umgewandelt. Daher muss bei der
        // Deserialisierung Case Sensitive deaktiviert werden.
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public UserDto CurrentUser => _currentUser;

        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }
        private string _baseUrl;

        /// <summary>
        /// Konstruktor. Legt die Http Einstellungen fest.
        /// </summary>
        public RestServiceBase()
        {
            // Akzeptiert das selbst ausgestellte Zertifikat der REST API.
            // Sollte nicht im Produktionscode sein, deswegen ist das Akteptieren von ungültigen
            // Zertifikaten nur im Debugmodus aktiviert.
            _handler = new HttpClientHandler() { ClientCertificateOptions = ClientCertificateOption.Manual };
#if DEBUG
            _handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
#endif
            _client = new HttpClient(_handler);
        }

        /// <summary>
        /// Meldet den User an der Adresse (baseUrl)/user/login an und setzt den Token als
        /// Default Request Header für zukünftige Anfragen.
        /// </summary>
        /// <param name="user">Benutzer, der angemeldet werden soll.</param>
        /// <returns>Userobjekt mit Token wenn erfolgreich, null bei ungültigen Daten.</returns>
        public async Task<bool> TryLoginAsync(UserDto user)
        {
            try
            {
                UserDto sentUser = await SendAsync<UserDto>(HttpMethod.Post, "user/login", user);
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", sentUser.Token);
                _currentUser = sentUser;
                return true;
            }
            catch (ServiceException e) when (e.HttpStatusCode == (int)HttpStatusCode.Unauthorized)
            {
                return false;
            }
        }

        /// <summary>
        /// Löscht den Token aus den HTTP Headern. Ein Logout Request in der API ist nicht nötig.
        /// </summary>
        /// <returns></returns>
        public void Logout()
        {
            _currentUser = null;
            _client.DefaultRequestHeaders.Authorization = null;
        }

        protected Task<T> SendAsync<T>(HttpMethod method, string actionUrl) => SendAsync<T>(method, actionUrl, "", null);
        protected Task<T> SendAsync<T>(HttpMethod method, string actionUrl, object requestData) => SendAsync<T>(method, actionUrl, "", requestData);
        protected Task<T> SendAsync<T>(HttpMethod method, string actionUrl, string idParam) => SendAsync<T>(method, actionUrl, idParam, null);

        /// <summary>
        /// Sendet einen Request an die REST API und gibt das Ergebnis zurück.
        /// </summary>
        /// <typeparam name="T">Typ, in den die JSON Antwort des Servers umgewandelt wird.</typeparam>
        /// <param name="method">HTTP Methode, die zum Senden des Requests verwendet wird.</param>
        /// <param name="actionUrl">Adresse, die in {baseUrl}/{actionUrl}/{idParam} ersetzt wird.</param>
        /// <param name="idParam">Adresse, die in {baseUrl}/{actionUrl}/{idParam} ersetzt wird.</param>
        /// <param name="requestData">Daten, die als JSON Request Body bzw. als Parameter bei GET Requests gesendet werden.</param>
        /// <returns></returns>
        protected async Task<T> SendAsync<T>(HttpMethod method, string actionUrl, string idParam, object requestData)
        {
            string url = $"{_baseUrl}/{actionUrl}/{idParam}";

            // Wurde der Zugriff auf das Internet im Manifest erlaubt? Es muss
            // <uses-permission android:name="android.permission.INTERNET" />
            // in Androidprojekt/Properties/AndroidManifest.xml gesetzt werden.
            //if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            //{
            //    throw new ServiceException("No permission for Internet connecions.") { Url = url };
            //}

            try
            {
                // Die Daten für den Request Body als JSON serialisieren und mitsenden.
                string jsonContent = JsonSerializer.Serialize(requestData);
                StringContent request = new StringContent(
                    jsonContent, Encoding.UTF8, "application/json"
                );

                HttpResponseMessage response;
                if (method == HttpMethod.Get)
                {
                    string parameters = requestData as string;
                    if (!string.IsNullOrEmpty(parameters))
                        url = $"{url}?{parameters}";
                    response = await _client.GetAsync(url);
                }
                else if (method == HttpMethod.Post)
                { response = await _client.PostAsync(url, request); }
                else if (method == HttpMethod.Put)
                { response = await _client.PutAsync(url, request); }
                else if (method == HttpMethod.Delete)
                { response = await _client.DeleteAsync(url); }
                else
                {
                    throw new ServiceException("Unsupported Request Method") { Url = url };
                }

                if (!response.IsSuccessStatusCode)
                {
                    switch (response.StatusCode)
                    {
                        // Bei REST hat man sich auf folgende HTTP-Reposnses festgelegt. Der Einfachheit halber
                        // werden alle auf ServiceException("Request not successful.") gemapt.
                        case HttpStatusCode.MovedPermanently:
                        case HttpStatusCode.NotModified:
                        case HttpStatusCode.MethodNotAllowed:
                        case HttpStatusCode.NotFound:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.BadRequest:
                            throw new ServiceException("Request not successful.")
                            {
                                Url = url,
                                HttpStatusCode = (int)response.StatusCode
                            };
                        // Unauthorized/Forbidden betrifft Login/Authenitication Der Einfachheit halber
                        // werden alle auf AuthenticationException("Die Anmeldung ist fehlgeschlagen!") gemapt.
                        case HttpStatusCode.Forbidden:
                        case HttpStatusCode.Unauthorized:
                            throw new AuthenticationException("Die Anmeldung ist fehlgeschlagen!")
                            {
                                Url = url,
                                HttpStatusCode = (int)response.StatusCode
                            };
                        // weitere:
                        //case HttpStatusCode.TemporaryRedirect:
                        //    // TODO: Inplementation
                        //    break;
                    }
                }
                string result = await response.Content.ReadAsStringAsync();
                try
                {
                    return JsonSerializer.Deserialize<T>(result, _jsonOptions);
                }
                catch (Exception ex)
                {
                    throw new ServiceException("Cannot parse result", ex)
                    {
                        Url = url
                    };
                }
            }
            catch (ServiceException) { throw; }
            catch (AuthenticationException) { throw; }
            catch (Exception ex)
            {
                throw new ServiceException("Request not successful.", ex)
                {
                    Url = url,
                };
            }
        }
    }
}
