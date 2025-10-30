using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BooksManagement.Models;

public partial class Book
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    [StringLength(100)]
    public string Author { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [InverseProperty("Book")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
