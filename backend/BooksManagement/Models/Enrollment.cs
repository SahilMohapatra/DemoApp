using System;
using System.Collections.Generic;

namespace BooksManagement.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public string UserId { get; set; } = null!;

    public int ProgramId { get; set; }

    public DateTime? EnrollmentDate { get; set; }
}
