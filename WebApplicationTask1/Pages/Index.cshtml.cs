using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace WebApplicationTask1.Pages
{
    public class IndexModel : PageModel
    {
        IConfiguration _config;
        
        public IndexModel(IWebHostEnvironment env, IConfiguration conf)
        {
            _config = conf; 
        }


        public void OnGet()
        {
            ViewData["MyKey"] = _config["MyKey"];
        }
    }
}