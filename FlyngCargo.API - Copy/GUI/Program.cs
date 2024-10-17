
using Services.Helpers;
using Services.ServiceContracts;
using Services;
using Entities;
using Microsoft.Extensions.DependencyInjection;
using Repository.RepositoryContract;
using Repository.UnitOfWork;
using Repository;


namespace GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceProvider = new ServiceCollection()
                .AddScoped<IValidationService, ValidationService>() 
                .AddScoped<Form1>() 
                .BuildServiceProvider();

            var mainForm = serviceProvider.GetService<Form1>();

            if (mainForm == null)
            {
                throw new InvalidOperationException("Failed to create Form1.");
            }

            Application.Run(mainForm);
        }
    }
}
