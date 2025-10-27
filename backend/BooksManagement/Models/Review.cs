using System;
using System.Collections.Generic;

namespace BooksManagement.Models;

public partial class Review
{
    public int Id { get; set; }

    public string? Comment { get; set; }

    public int? Rating { get; set; }

    public int? BookId { get; set; }

    public virtual Book? Book { get; set; }
}
