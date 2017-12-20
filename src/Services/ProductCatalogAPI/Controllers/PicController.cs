using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesOnContainers.Services.ProductCatalogAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Pic")]
    public class PicController : Controller
    {

        private readonly IHostingEnvironment env;

        public PicController(IHostingEnvironment env)
        {
            this.env = env;

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var webRoot = env.WebRootPath;
            var path = Path.Combine(webRoot + "/Pics/", "shoes-" + id + ".png");
            var buffer = System.IO.File.ReadAllBytes(path);
            return File(buffer, "image/png");
        }

    }
}
