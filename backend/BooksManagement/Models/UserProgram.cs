using System;
using System.Collections.Generic;

namespace BooksManagement.Models;

public partial class UserProgram
{
    public string ProgramId { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string? MoodLevel { get; set; }

    public string? StressLevel { get; set; }

    public string? Sleepquality { get; set; }

    public string? EnergyLevel { get; set; }

    public string? PhysicalActivity { get; set; }

    public string? SelfCareActivity { get; set; }
}
