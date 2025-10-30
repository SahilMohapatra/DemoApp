using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BooksManagement.Models;

public partial class UserProgram
{
    [Key]
    [Column("ProgramID")]
    [StringLength(100)]
    [Unicode(false)]
    public string ProgramId { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? MoodLevel { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? StressLevel { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Sleepquality { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EnergyLevel { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? PhysicalActivity { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? SelfCareActivity { get; set; }
}
