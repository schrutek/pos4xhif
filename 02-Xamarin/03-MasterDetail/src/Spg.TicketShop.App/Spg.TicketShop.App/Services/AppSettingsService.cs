using Spg.TicketShop.Core.Eceptions;
using Spg.TicketShop.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;

// Registriert das Service, sodass die Instanz in der App mit DependencyService.Get<AppSettingsService>()
// abgerufen werden kann. Es wird nur 1 Instanz erstellt, falls keine Option für 
// DependencyFetchTarget.GlobalInstance in DependencyService angegeben wird.
// Vgl. https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/dependency-service/introduction
[assembly: Xamarin.Forms.Dependency(typeof(Spg.TicketShop.App.Services.AppSettingsService))]
namespace Spg.TicketShop.App.Services
{
    public class AppSettingsService: AppSettingsServiceBase
    {
        public AppSettingsService()
        {
            //Assembly assembly = GetType().Assembly;
            //base.ManifestName = $"{assembly.GetName().Name}";
        }
    }
}
