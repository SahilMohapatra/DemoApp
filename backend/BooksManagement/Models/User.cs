using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BooksManagement.Models;

[Index("Email", Name = "UQ__Users__A9D10534491FC747", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("UserID")]
    [StringLength(100)]
    [Unicode(false)]
    public string UserId { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string? Roles { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Password { get; set; } = null!;
}
