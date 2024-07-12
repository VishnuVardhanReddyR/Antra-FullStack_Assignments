using DapperTutorial.Core.Entities;
using DapperTutorial.Infrastructure.Repositories;

namespace DapperTutorial.Presentation.UI;

public class ManageDepartment
{
    private DepartmentRepository _departmentRepository = new DepartmentRepository();

    private void AddDepartment()
    {
        Department department = new Department();
        Console.WriteLine("Enter id =>");
        department.Id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Name =>");
        department.DepartmentName = Console.ReadLine();
        Console.WriteLine("Enter Location =>");
        department.Location = Console.ReadLine();
        Console.WriteLine(_departmentRepository.Insert(department));
    }

    private void DeleteDepartment()
    {
        Console.WriteLine("Enter the Department Id =>");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(_departmentRepository.DeleteById(id));
    }

    private void UpdateDepartment()
    {
        Department department = new Department();
        Console.WriteLine("Enter id =>");
        department.Id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Name =>");
        department.DepartmentName = Console.ReadLine();
        Console.WriteLine("Enter Location =>");
        department.Location = Console.ReadLine();
        Console.WriteLine(_departmentRepository.Update(department));
    }

    private void PrintAll()
    {
        IEnumerable<Department> departments = _departmentRepository.GetAll();
        Console.WriteLine("Id" + "\t" + "DepartmentName" + "\t" + "Location");
        foreach (var department in departments)
        {
            Console.WriteLine(department.Id + "\t" + department.DepartmentName + "\t" + department.Location);
        }
    }

    private void PrintDepartmentById()
    {
        Console.WriteLine("Enter the Department by Id => ");
        int Id = Convert.ToInt32(Console.ReadLine());
        Department department = _departmentRepository.GetById(Id);
        Console.WriteLine(department.Id + "\t" + department.DepartmentName + "\t" + department.Location);
    }
    public void Run()
    {
        PrintDepartmentById();
    }
}