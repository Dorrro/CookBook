using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Net.Http.Headers;

namespace CookBook.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public RecipeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: /Recipe/
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Recipe/RecipeUpload
        [HttpPost]
        public async Task<IActionResult> Index(IEnumerable<IFormFile> files)
        {
            var recipes = Path.Combine(_hostingEnvironment.WebRootPath, "recipes");
            if (!Directory.Exists(recipes))
            {
                Directory.CreateDirectory(recipes);
            }

            foreach (var file in files)
            {
                var fileName = GetFileName(file);

                await file.SaveAsAsync(Path.Combine(recipes, fileName));
            }

            return View("RecipeUploaded");
        }

        private static string GetFileName(IFormFile file)
        {
            return ContentDispositionHeaderValue
                .Parse(file.ContentDisposition)
                .FileName
                .Trim('"');
        }
    }
}