using System;
using System.Collections.Generic;

namespace Common.Library.ViewModels
{

    public class SearchResults
    {
        public SearchResults()
        {
            TotalMatching = 0;
            SearchTerm = string.Empty;
            Results = new List<Result>();
            Pager = new Pager(TotalMatching, 0);
        }


        public int TotalMatching { get; set; }

        public string SearchTerm { get; set; }

        public List<Result> Results { get; set; }

        public Pager Pager { get; set; }
    }

    public class Result
    {
        public string Title { get; set; }

        public string Excerpt { get; set; }

        public Uri Url { get; set; }
    }

    public class Pager
    {
        public Pager(int totalItems, int? page, int pageSize = 10)
        {
            // calculate total, start and end pages
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }

        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
    }
}
