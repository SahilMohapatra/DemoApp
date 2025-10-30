using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BooksManagement.Models;

public partial class ApplicationError
{
    [Key]
    public int Id { get; set; }

    public string Message { get; set; } = null!;

    public string StackTrace { get; set; } = null!;

    public DateTime Timestamp { get; set; }
}
