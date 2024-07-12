using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Core.Entities;

public class Employee
{
    public int Id { get; set; }
    [MaxLength(50)] // Data Annotation
    public string? EmployeeName { get; set; }
    [Required]     // Data Annotation
    public int Age { get; set; }
    [Required(ErrorMessage = "The department id field is required")] // Data Annotation
    public int DepartmentId { get; set; }
    
    // Navigation property
    public Department Department { get; set; }
}

// Data Annatotions == Check Constraint