using EntityFramework.Core.Models.RequestModel;
using EntityFramework.Infrastructure.Services;

namespace EntityFramework.Presentation.UI;

public class ManageEmployee
{
    private EmployeeService _employeeService = new EmployeeService();

    private void AddEmployee()
    {
        EmployeeRequestModel employeeRequestModel = new EmployeeRequestModel();
        Console.WriteLine("Enter Employee Name: ");
        employeeRequestModel.EmployeeName = Console.ReadLine();
        Console.WriteLine("Enter Employee Age: ");
        employeeRequestModel.Age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(_employeeService.AddEmployee(employeeRequestModel));
    }

    private void PrintAllEmployee()
    {
        var employees = _employeeService.GetAllEmployees();
        foreach (var employee in employees)
        {
            Console.WriteLine(employee.EmployeeName + "\t" + employee.Age);
        }
    }

    private void GetEmployeeId()
    {
        Console.WriteLine("Enter Employee Age");
        int id = Convert.ToInt32(Console.ReadLine());
        var employee = _employeeService.GetById(id);
        Console.WriteLine(employee.EmployeeName + "\t" + employee.Age);
    }

    private void ModifyEmployee()
    {
        EmployeeRequestModel employeeRequestModel = new EmployeeRequestModel();
        Console.WriteLine("Enter Employee Name: ");
        employeeRequestModel.EmployeeName = Console.ReadLine();
        Console.WriteLine("Enter Employee Age: ");
        employeeRequestModel.Age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(_employeeService.UpdateEmployee(employeeRequestModel));
    }

    private void DeleteEmployee()
    {
        Console.WriteLine("Enter the Employee id :");
        var id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(_employeeService.DeleteEmployee(id));
    }

    public void Run()
    {
        PrintAllEmployee(); }
}