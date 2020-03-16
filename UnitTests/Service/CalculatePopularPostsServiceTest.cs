using Xunit;
using Blog.Service;
using Blog.DTO;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UnitTests.Service
{
    public class CalculatePopularPostsServiceTest
    {
        private const string HIGH_PROBABILITY_POST_ID = "high";
        private const string LOW_PROBABILITY_POST_ID = "low";

        private const string CUSTOM_POST_ID_1 = "name_1";
        private const string CUSTOM_POST_ID_2 = "name_2";

        private CalculatePopularPostsService calculatePopularPostsService;

        public CalculatePopularPostsServiceTest()
        {
            this.calculatePopularPostsService = new CalculatePopularPostsService();
        }

        [Fact]
        public void TestAllPosts()
        {
            PopularPostsDTO popularPostsDTO = new PopularPostsDTO();
            popularPostsDTO.PostsStatistics = GetFullDataPostStatisticsDTOs();

            IDictionary<string, double> result = calculatePopularPostsService.CalculatePopularPosts(popularPostsDTO, 2);

            Assert.Equal(0.4816487859966121, result.First().Value);
            Assert.Equal(HIGH_PROBABILITY_POST_ID, result.First().Key);

            Assert.Equal(0.25168454733672124, result.Last().Value);
            Assert.Equal(LOW_PROBABILITY_POST_ID, result.Last().Key);
        }

        [Fact]
        public void TestResultOnePost()
        {
            PopularPostsDTO popularPostsDTO = new PopularPostsDTO();
            popularPostsDTO.PostsStatistics = GetFullDataPostStatisticsDTOs();

            IDictionary<string, double> result = calculatePopularPostsService.CalculatePopularPosts(popularPostsDTO, 1);

            Assert.Equal(0.4816487859966121, result.First().Value);
            Assert.Equal(HIGH_PROBABILITY_POST_ID, result.First().Key);
        }

        [Fact]
        public void TestOnePopularPostStatistics()
        {
            string postId = "single";
            Random random = new Random();

            PostStatisticsDTO postStatisticsDTO = new PostStatisticsDTO();
            postStatisticsDTO.PostId = postId;
            postStatisticsDTO.Views = random.Next(1, 100000);
            postStatisticsDTO.Conversions = random.Next(1, 100000);
            postStatisticsDTO.ReadTime = (double) random.Next(1, 100000);

            PostStatisticsDTO[] postsStatistics = { postStatisticsDTO };

            PopularPostsDTO popularPostsDTO = new PopularPostsDTO();
            popularPostsDTO.PostsStatistics = postsStatistics;

            IDictionary<string, double> result = calculatePopularPostsService.CalculatePopularPosts(popularPostsDTO, 1);

            Assert.Equal(0.7333333333333334, result.First().Value);
            Assert.Equal(postId, result.First().Key);
        }

        [Fact]
        public void TestZeroViews()
        {
            PopularPostsDTO popularPostsDTO = new PopularPostsDTO();
            popularPostsDTO.PostsStatistics = GetCustomDataPostStatisticsDTOs(0, 0, 1000);

            IDictionary<string, double> result = calculatePopularPostsService.CalculatePopularPosts(popularPostsDTO, 2);

            Assert.Equal(0, result.First().Value);
            Assert.Equal(CUSTOM_POST_ID_1, result.First().Key);

            Assert.Equal(0, result.Last().Value);
            Assert.Equal(CUSTOM_POST_ID_2, result.Last().Key);
        }

        [Fact]
        public void TestZeroReadTime()
        {
            PopularPostsDTO popularPostsDTO = new PopularPostsDTO();
            popularPostsDTO.PostsStatistics = GetCustomDataPostStatisticsDTOs(1000, 250, 0);

            IDictionary<string, double> result = calculatePopularPostsService.CalculatePopularPosts(popularPostsDTO, 2);

            Assert.Equal(0, result.First().Value);
            Assert.Equal(CUSTOM_POST_ID_1, result.First().Key);

            Assert.Equal(0, result.Last().Value);
            Assert.Equal(CUSTOM_POST_ID_2, result.Last().Key);
        }

        [Fact]
        public void TestZeroConversions()
        {
            PopularPostsDTO popularPostsDTO = new PopularPostsDTO();
            popularPostsDTO.PostsStatistics = GetCustomDataPostStatisticsDTOs(1000, 0, 2500);

            IDictionary<string, double> result = calculatePopularPostsService.CalculatePopularPosts(popularPostsDTO, 2);

            Assert.Equal(0.2435897435897436, result.First().Value);
            Assert.Equal(CUSTOM_POST_ID_1, result.First().Key);

            Assert.Equal(0.18974358974358974, result.Last().Value);
            Assert.Equal(CUSTOM_POST_ID_2, result.Last().Key);
        }

        private PostStatisticsDTO[] GetFullDataPostStatisticsDTOs()
        {
            PostStatisticsDTO postStatisticsDTO1 = new PostStatisticsDTO();
            postStatisticsDTO1.PostId = LOW_PROBABILITY_POST_ID;
            postStatisticsDTO1.Views = 1000;
            postStatisticsDTO1.Conversions = 170;
            postStatisticsDTO1.ReadTime = 2500;

            PostStatisticsDTO postStatisticsDTO2 = new PostStatisticsDTO();
            postStatisticsDTO2.PostId = HIGH_PROBABILITY_POST_ID;
            postStatisticsDTO2.Views = 2500;
            postStatisticsDTO2.Conversions = 325;
            postStatisticsDTO2.ReadTime = 3250;


            PostStatisticsDTO[] postsStatistics = {postStatisticsDTO1, postStatisticsDTO2};

            return postsStatistics;
        }

        private PostStatisticsDTO[] GetCustomDataPostStatisticsDTOs(int views = 0, int conversions = 0, double readTime = 0)
        {
            PostStatisticsDTO postStatisticsDTO1 = new PostStatisticsDTO();
            postStatisticsDTO1.PostId = CUSTOM_POST_ID_1;
            postStatisticsDTO1.Views = views * 50;
            postStatisticsDTO1.Conversions = conversions * 99;
            postStatisticsDTO1.ReadTime = readTime * 30;

            PostStatisticsDTO postStatisticsDTO2 = new PostStatisticsDTO();
            postStatisticsDTO2.PostId = CUSTOM_POST_ID_2;
            postStatisticsDTO2.Views = views * 15;
            postStatisticsDTO2.Conversions = conversions * 10;
            postStatisticsDTO2.ReadTime = readTime * 100;


            PostStatisticsDTO[] postsStatistics = { postStatisticsDTO1, postStatisticsDTO2 };

            return postsStatistics;
        }
    }
}
