using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BooksManagement.Models;

[Table("UsersTable")]
[Index("Username", Name = "UQ__UsersTab__536C85E4080B842E", IsUnique = true)]
public partial class UsersTable
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string Username { get; set; } = null!;

    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(50)]
    public string Role { get; set; } = null!;

    [StringLength(100)]
    public string? Name { get; set; }

    [StringLength(255)]
    public string? Email { get; set; }

    [StringLength(100)]
    public string? Course { get; set; }
}
