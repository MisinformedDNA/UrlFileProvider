using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace WebApplicationSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string AllowedHosts { get; set; }
        public string PackageName { get; set; }
        public string RepoType { get; set; }

        public void OnGet()
        {
            AllowedHosts = _configuration["AllowedHosts"];
            PackageName = _configuration["name"];
            RepoType = _configuration["Repository:Type"];   // case insensitive
        }
    }
}
