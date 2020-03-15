using Blog.Entity;
using Microsoft.AspNetCore.Mvc;
using Blog.Service;

namespace Blog.Controllers
{
    [Route("api")]
    [ApiController]
    public class AddPostController : Controller
    {
        private AddPostService AddPostService;

        public AddPostController(AddPostService AddPostService)
        {
            this.AddPostService = AddPostService;
        }

        [HttpPost("add-post")]
        public JsonResult AddPost([FromBody] Post post)
        {
            this.AddPostService.Create(post);

            return Json(post);
        }
    }
}