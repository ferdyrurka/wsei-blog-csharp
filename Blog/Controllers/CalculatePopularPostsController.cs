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

/*
 {
    "PostsStatistics": [
        {
        	"PostId": "0cc175b9c0f1b6a831c399e269772661",
            "Views": 130300,
            "Conversions": 53287,
            "ReadTime": 223000.99
        },
        {
        	"PostId": "92eb5ffee6ae2fec3ad71c777531578f",
            "Views": 26986,
            "Conversions": 7000,
            "ReadTime": 9981.6
        },
        {
        	"PostId": "4a8a08f09d37b73795649038408b5f33",
            "Views": 9723,
            "Conversions": 7875,
            "ReadTime": 20449
        },
        {
        	"PostId": "8277e0910d750195b448797616e091ad",
            "Views": 54872,
            "Conversions": 25875,
            "ReadTime": 90999.4
        }
    ]
}
*/
