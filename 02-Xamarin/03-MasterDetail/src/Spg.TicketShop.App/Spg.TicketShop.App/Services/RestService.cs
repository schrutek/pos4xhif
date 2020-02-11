using Spg.TicketShop.Core.Dtos;
using Spg.TicketShop.Core.Eceptions;
using Spg.TicketShop.Core.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

// Registriert das Service, sodass die Instanz in der App mit DependencyService.Get<RestService>()
// abgerufen werden kann. Es wird nur 1 Instanz erstellt, falls keine Option für 
// DependencyFetchTarget.GlobalInstance in DependencyService angegeben wird.
// Vgl. https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/dependency-service/introduction
[assembly: Xamarin.Forms.Dependency(typeof(Spg.TicketShop.App.Services.RestService))]
namespace Spg.TicketShop.App.Services
{
    /// <summary>
    /// Stellt alle Methoden (in den Basisklassen) zur Verfügung um mit dem REST-Service zu kommunizieren.
    /// </summary>
    /// <remarks>
    /// Diese Klasse erbt von CrudBase, weil sich diese Implementierung von jener der 
    /// WPF-App unterscheidet. Vererbung ist dabei edie einfachste Methode Code
    /// wieder zu verwenden. Besser wäre "Inversion of Control".
    /// </remarks>
    public class RestService : CrudBase
    {
        /// <summary>
        /// Erstellt eine neue Instanz der Klasse <code>RestService</code> .
        /// </summary>
        /// <remarks>
        /// In dieser Methode wird <code>AppSettingsService</code> verwendet um die Base-Url
        /// zur API aus der appsettings.config zu laden und zu setzen.
        /// </remarks>
        public RestService()
        {
            Assembly assembly = GetType().Assembly;
            AppSettingsService appSettingsServiceBase = new AppSettingsService();
            appSettingsServiceBase.Assembly = assembly;

            base.BaseUrl = appSettingsServiceBase.Get("ServiceUrl");
        }
    }
}
