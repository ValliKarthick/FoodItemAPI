using System;
using System.Collections.Generic;

namespace Web_Api___Scaffolded.Models
{
    public partial class BookDetail
    {
        public int BookNumber { get; set; }
        public string? BookName { get; set; }
        public string AuthorName { get; set; } = null!;
        public int PublishedYear { get; set; }
    }
}
