using Spg.TicketShop.Core.Dtos;
using Spg.TicketShop.Core.Eceptions;
using Spg.TicketShop.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spg.TicketShop.WpfBackEnd.Services
{
    /// <summary>
    /// Diese Klasse leitet von CrudBase ab und ist als Singleton ausgeführt. D.h. der 
    /// Konstruktor wird private gesetzt und die Instanz innerhalb der Klasse generiert. 
    /// Eine Singelton-Instanz existiert also immer nur einmal im Speicher. Der Typ wir in
    /// <code>Lazy</code> gekapselt um den Singleton Thread-Save zu halten. Das ist die 
    /// einfachste Methode.
    /// </summary>
    /// <remarks>
    /// Diese Klasse erbt von CrudBase, weil sich diese Implementierung von jener der 
    /// Xamarin-App unterscheidet. Vererbung ist dabei edie einfachste Methode Code
    /// wieder zu verwenden. Besser wäre "Inversion of Control".
    /// </remarks>
    public class RestService : CrudBase
    {
        /// <summary>
        /// Erstellte eine neue Instanz der Klasse <code>RestService</code>
        /// </summary>
        private static readonly Lazy<RestService> _instance = new Lazy<RestService>(() => new RestService());

        /// <summary>
        /// Der Konstruktor wird private gesetzut. Die Klasse kann nun von 
        /// außen nicht mehr instanziert werden.
        /// </summary>
        /// <remarks>
        /// In dieser Methode wird <code>AppSettingsService</code> verwendet um die Base-Url
        /// zur API aus der appsettings.config zu laden und zu setzen.
        /// </remarks>
        private RestService()
        {
            Assembly assembly = GetType().Assembly;
            AppSettingsService appSettingsServiceBase = new AppSettingsService();
            appSettingsServiceBase.Assembly = assembly;

            base.BaseUrl = appSettingsServiceBase.Get("ServiceUrl");
        }

        /// <summary>
        /// Gib die Instanz der Klasse <code>RestService</code>zurück.
        /// </summary>
        public static RestService Instance => _instance.Value;
    }
}
