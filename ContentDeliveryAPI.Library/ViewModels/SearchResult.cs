using System;
using System.Collections.Generic;

namespace ContentDeliveryAPI.Library.ViewModels
{

    public class SearchResults
    {
        public SearchResults()
        {
            TotalMatching = 0;
            Results = new List<Result>();
        }

        public int TotalMatching { get; set; }

        public List<Result> Results { get; set; }
    }

    public class Result
    {
        public string Title { get; set; }

        public string Excerpt { get; set; }

        public Uri Url { get; set; }
    }
}
