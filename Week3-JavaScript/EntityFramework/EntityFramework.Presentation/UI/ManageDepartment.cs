using EntityFramework.Core.Entities;
using EntityFramework.Core.Models.RequestModel;
using EntityFramework.Core.Models.ResponseModel;
using EntityFramework.Infrastructure.Repositories;
using EntityFramework.Infrastructure.Services;

namespace EntityFramework.Presentation.UI;

public class ManageDepartment
{
    private DepartmentService _departmentService = new DepartmentService();
    private void AddDepartment()
    {
        DepartmentRequestModel department = new DepartmentRequestModel();
        Console.WriteLine("Enter Name =>");
        department.DepartmentName = Console.ReadLine();
        Console.WriteLine("Enter Location =>");
        department.Location = Console.ReadLine();
        Console.WriteLine(_departmentService.AddDepartment(department));
    }

    private void DeleteDepartment()
    {
        Console.WriteLine("Enter the Department Id =>");
        int id = Convert.ToInt32(Console.ReadLine());
        _departmentService.DeleteDepartment(id);
    }

    private void UpdateDepartment()
    {
        DepartmentRequestModel department = new DepartmentRequestModel();
        Console.WriteLine("Enter Name =>");
        department.DepartmentName = Console.ReadLine();
        Console.WriteLine("Enter Location =>");
        department.Location = Console.ReadLine();
        _departmentService.UpdateDepartment(department);
    }

    private void PrintAll()
    {
        var departments = _departmentService.GetAllDepartments();
        Console.WriteLine("Id" + "\t" + "DepartmentName" + "\t" + "Location");
        foreach (var department in departments)
        {
            Console.WriteLine(department.DepartmentName + "\t" + department.Location);
        }
    }

    private void PrintDepartmentById()
    {
        Console.WriteLine("Enter the Department by Id => ");
        int Id = Convert.ToInt32(Console.ReadLine());
        DepartmentResponseModel department = _departmentService.GetById(Id);
        Console.WriteLine(department.DepartmentName + "\t" + department.Location);
    }
    public void Run()
    {
        AddDepartment();
    }
}