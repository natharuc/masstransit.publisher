using Masstransit.Publisher.Domain.Interfaces;
using Masstransit.Publisher.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Masstransit.Publisher.Windows
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            services.AddSingleton<IPublisherService, PublisherService>();
            services.AddSingleton<IMockInterfaceService, MockInterfaceService>();
            services.AddSingleton<ILogService, LogService>();
            services.AddSingleton<FormPublisher>();

            var provider = services.BuildServiceProvider();

            var form = provider.GetService<FormPublisher>();

            if (form == null)
                throw new InvalidOperationException("FormPublisher not found in service provider.");

            Application.ThreadException += (sender, args) =>
            {
                MessageBox.Show(args.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            Application.Run(form);
        }
    }
}