using System;
using System.Collections.Generic;

namespace BooksManagement.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
