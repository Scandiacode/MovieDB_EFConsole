using System;
using System.Collections.Generic;

#nullable disable

namespace Movie_Database_EF_Lab
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public float? Runtime { get; set; }
    }
}
