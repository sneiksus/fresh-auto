using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        public IActionResult Index()
        {
            return File("/html/index.html", "text/html");
        }
    }
}