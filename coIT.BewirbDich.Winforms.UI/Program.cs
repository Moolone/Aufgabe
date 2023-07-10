using coIT.BewirbDich.Winforms.Domain;
using coIT.BewirbDich.Winforms.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace coIT.BewirbDich.Winforms.UI;

static class Program
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

        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;

        Application.Run(ServiceProvider.GetRequiredService<Form_Main>());
    }

    /// <summary>
    /// Der Dienstanbieter dieser Anwendung.
    /// </summary>
    public static IServiceProvider ServiceProvider { get; private set; }
   
    /// <summary>
    /// Erstellt einen <see cref="HostBuilder"/> und konfiguriert die für die Anwendung notwendigen Dienst.
    /// </summary>
    /// <returns>Der HostBuilder.</returns>
    private static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
        {
            services.AddSingleton<IRepository<Calculation>, JsonRepository<Calculation>>((repo) =>
            {
                return new JsonRepository<Calculation>("database.json");
            });
            services.AddTransient<Form_Main>();
            services.AddTransient<Form_NewCalculation>();
        });
    }
}