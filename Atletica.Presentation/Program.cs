using Atletica.Application.Services;
using Atletica.Presentation.Config;
using Atletica.Presentation.Presenters;
using Atletica.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace Atletica.Presentation
{
    internal static class Program
    {
        public static ServiceProvider? ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Configurar Dependency Injection
            ServiceProvider = DependencyInjection.ConfigureServices();

            // Iniciar aplicação com menu principal
            var formMenu = new FormMenuPrincipal();
            var presenter = new MenuPresenter(formMenu, ServiceProvider);
            
            System.Windows.Forms.Application.Run(formMenu);
        }
    }
}