using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BooksManagement.Models;

public partial class Department
{
    [Key]
    public int Id { get; set; }

    public string DeptName { get; set; } = null!;

    [InverseProperty("Dept")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
