using Microsoft.AspNetCore.Mvc;
using Blog.Service;
using Blog.DTO;

namespace Blog.Controllers
{
    [Route("api")]
    [ApiController]
    public class CalculatePopularPostsController : Controller
    {
        private CalculatePopularPostsService calculateSimilarPostsService;
        
        public CalculatePopularPostsController(CalculatePopularPostsService calculateSimilarPostsService)
        {
            this.calculateSimilarPostsService = calculateSimilarPostsService;
        }

        [HttpGet("calculate-popular-posts/{maxPosts}")]
        public JsonResult Calculate([FromBody] PopularPostsDTO popularPostsDTO, int maxPosts)
        {
            return Json(calculateSimilarPostsService.CalculatePopularPosts(popularPostsDTO, maxPosts));
        }
    }
}
