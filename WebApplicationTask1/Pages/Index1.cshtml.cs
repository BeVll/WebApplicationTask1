using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebApplicationTask1.Pages
{
    public class Index1Model : PageModel
    {
        private readonly IWebHostEnvironment _env;
        public string MyValue { get; set; }
        public string MyValue2 { get; set; }
        public Index1Model(IWebHostEnvironment env)
        {            
            _env = env;
        }
        public void OnGet()
        {
            string jsonFilePath = Path.Combine(_env.ContentRootPath, "appsettings.json");
            string jsonContent = System.IO.File.ReadAllText(jsonFilePath);
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonContent);

            var obj = jsonObject["listQuote"];
            Random random = new Random();

            int index = random.Next(0, obj.Count);
            MyValue = obj[index].quote;
            MyValue2 = obj[index].author;
        }
    }
}
