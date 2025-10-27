using System;
using System.Collections.Generic;

namespace BooksManagement.Models;

public partial class UsersTable
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Course { get; set; }
}
