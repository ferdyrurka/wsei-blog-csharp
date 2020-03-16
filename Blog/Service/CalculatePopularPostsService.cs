﻿using System.Collections.Generic;
using System.Linq;
using Blog.DTO;

namespace Blog.Service
{
    public class CalculatePopularPostsService
    {
        private const double VALUE_PROBABILITY_VIEWS = 0.8;
        private const double VALUE_PROBABILITY_CONVERSIONS = 0.9;
        private const double VALUE_PROBABILITY_READ_TIME = 0.5;
        private const int COUNT_CALCULATE_PROBABILITY = 3;

        public IDictionary<string, double> CalculatePopularPosts(PopularPostsDTO popularPostsDTO, int maxPosts)
        {
            PostStatisticsDTO[] postStatisticsDTOs = popularPostsDTO.PostsStatistics;
            IDictionary<string, double> postsProbability = new Dictionary<string, double>();

            int allViews = postStatisticsDTOs.Sum(postStatistics => postStatistics.Views);
            int allConversion = postStatisticsDTOs.Sum(postStatistics => postStatistics.Conversions);
            double allReadTime = postStatisticsDTOs.Sum(postStatistics => postStatistics.ReadTime);

            foreach (PostStatisticsDTO postStatitsticDTO in postStatisticsDTOs)
            {
                double postProbability = CalculatePostProbability(
                    allViews,
                    allConversion,
                    allReadTime,
                    postStatitsticDTO
                );

                postsProbability.Add(postStatitsticDTO.PostId, postProbability);
            }

            return GetSortProbability(postsProbability, maxPosts);
        }

        private double CalculatePostProbability(
            int allViews,
            int allConversions,
            double allReadTime,
            PostStatisticsDTO postStatisticsDTO
        ) {
            if (allViews <= 0 || allReadTime <= 0)
            {
                return 0;
            }

            double sumProbability = 0;

            sumProbability += CalculateViewsProbability(postStatisticsDTO.Views, allViews);
            sumProbability += CalculateReadTimeProbability(postStatisticsDTO.ReadTime, allReadTime);

            if (allConversions > 0)
            {
                sumProbability += CalculateConversionProbability(postStatisticsDTO.Conversions, allConversions);
            }

            return sumProbability / COUNT_CALCULATE_PROBABILITY;
        }

        private double CalculateViewsProbability(int postViews, int allViews)
        {
            double probability = (double) postViews / allViews;

            return probability * VALUE_PROBABILITY_VIEWS;
        }

        private double CalculateConversionProbability(int postConversions, int allConversions)
        {
            double probability = (double) postConversions / allConversions;

            return probability * VALUE_PROBABILITY_CONVERSIONS;
        }

        private double CalculateReadTimeProbability(double postReadTime, double allReadTime)
        {
            double probability = postReadTime / allReadTime;

            return probability * VALUE_PROBABILITY_READ_TIME;
        }

        private IDictionary<string, double> GetSortProbability(IDictionary<string, double>  postsProbability, int limit)
        {
            IDictionary<string, double> result = new Dictionary<string, double>();
            int i = 1;

            var sortPostsProbability = from postProbability in postsProbability
                orderby postProbability.Value descending select postProbability
            ;

            foreach (KeyValuePair<string, double> postProbability in sortPostsProbability)
            {
                result.Add(postProbability.Key, postProbability.Value);

                if (i >= limit)
                {
                    break;
                }

                ++i;
            }

            return result;
        }
    }
}