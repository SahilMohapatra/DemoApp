using System;
using System.Collections.Generic;

namespace BooksManagement.Models;

public partial class ApplicationError
{
    public int Id { get; set; }

    public string Message { get; set; } = null!;

    public string StackTrace { get; set; } = null!;

    public DateTime Timestamp { get; set; }
}
