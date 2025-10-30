using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BooksManagement.Models;

[Index("DeptId", Name = "IX_Employees_Dept_Id")]
public partial class Employee
{
    [Key]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("email")]
    public string Email { get; set; } = null!;

    [Column("mobile")]
    public string Mobile { get; set; } = null!;

    [Column("Dept_Id")]
    public int DeptId { get; set; }

    [ForeignKey("DeptId")]
    [InverseProperty("Employees")]
    public virtual Department Dept { get; set; } = null!;
}
