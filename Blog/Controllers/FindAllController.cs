using Blog.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Blog.Controllers
{
    [Route("api")]
    [ApiController]
    public class FindAllController : Controller
    {
        private FindAllPostService FindAllPostService;

        public FindAllController(FindAllPostService FindAllPostService)
        {
            this.FindAllPostService = FindAllPostService;
        }

        [HttpGet("find-all-post")]
        public JsonResult FindAllPost()
        {
            return Json(FindAllPostService.FindAll());
        }
    }
}