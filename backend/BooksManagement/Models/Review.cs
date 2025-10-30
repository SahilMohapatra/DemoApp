using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BooksManagement.Models;

[Table("Review")]
public partial class Review
{
    [Key]
    public int Id { get; set; }

    public int BookId { get; set; }

    [StringLength(100)]
    public string? ReviewerName { get; set; }

    [StringLength(255)]
    public string? Comment { get; set; }

    public int? Rating { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("Reviews")]
    public virtual Book Book { get; set; } = null!;
}
