﻿namespace BooksManagement.DTOs
{
    public class ReviewDto
    {
        public int? Id { get; set; }
        public int BookId { get; set; }
        public string ReviewerName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}
