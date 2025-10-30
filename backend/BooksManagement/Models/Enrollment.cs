using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BooksManagement.Models;

public partial class Enrollment
{
    [Key]
    [Column("EnrollmentID")]
    public int EnrollmentId { get; set; }

    [Column("UserID")]
    [StringLength(100)]
    [Unicode(false)]
    public string UserId { get; set; } = null!;

    [Column("ProgramID")]
    public int ProgramId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EnrollmentDate { get; set; }
}
