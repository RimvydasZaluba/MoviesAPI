using System;

namespace Movies.Domain.Helper
{
    public class FilterModel
    {
        public string TitleSearch { get; set; }
        public int? ReleaseYearSearch { get; set; }
        public string[] GenreSearch { get; set; }
    }
}
