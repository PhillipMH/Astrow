using Astrow.Client;
using Astrow.Client.APICaller;
using Astrow.Client.IAPICallers;
using Astrow_Services.Interfaces;
using Astrow_Services.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.Modal;
using Blazored.SessionStorage;

namespace Astrow.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<IStudentCaller, StudentCaller>();
            builder.Services.AddScoped<IStudentInterface, StudentRepository>();
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddBlazoredModal();
            await builder.Build().RunAsync();
        }
    }
}