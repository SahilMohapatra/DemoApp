using System;
using System.Collections.Generic;

namespace BooksManagement.Models;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Roles { get; set; }

    public string Password { get; set; } = null!;
}
