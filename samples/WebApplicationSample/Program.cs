using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using YellowCounter.FileProvider.Url;

namespace WebApplicationSample
{
    public class Program
    {
        private const string ConfigUrl = "https://raw.githubusercontent.com/cdnjs/cdnjs/master/ajax/libs/aurelia/package.json";

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            // Use `UrlFileProvider` to read a file on the web
            .ConfigureAppConfiguration((c, b) => b.AddJsonFile(
                new UrlFileProvider(),
                ConfigUrl,
                optional: false,
                reloadOnChange: false))
            .UseStartup<Startup>();
    }
}
