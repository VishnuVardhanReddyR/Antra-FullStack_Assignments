namespace DapperTutorial.Core.Entities;

public class Employee
{
    public int Id { get; set; }
    public string EmployeeName { get; set; }
    public int Age { get; set; }
    public int DeparmentId { get; set; }
    
    // Navigation Property
    public Department Department { get; set; }
}