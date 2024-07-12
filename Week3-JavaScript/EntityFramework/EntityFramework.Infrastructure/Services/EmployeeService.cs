using EntityFramework.Core.Entities;
using EntityFramework.Core.Interfaces.Services;
using EntityFramework.Core.Models.RequestModel;
using EntityFramework.Core.Models.ResponseModel;
using EntityFramework.Infrastructure.Repositories;

namespace EntityFramework.Infrastructure.Services;

public class EmployeeService: IEmployeeService
{
    private EmployeeRepository _employeeRepository = new EmployeeRepository();
    
    public List<EmployeeResponseModel> GetAllEmployees()
    {
        var employees = _employeeRepository.GetAll();
        var employeeResponseModels = new List<EmployeeResponseModel>();
        foreach (var employee in employees)
        {
            employeeResponseModels.Add(new EmployeeResponseModel
            {
                EmployeeName = employee.EmployeeName,
                Age = employee.Age
            });
        }

        return employeeResponseModels;
    }

    public EmployeeResponseModel GetById(int id)
    {
        var employee = _employeeRepository.GetById(id);
        if (employee != null)
        {
            var employeeResponseModel = new EmployeeResponseModel
            {
                EmployeeName = employee.EmployeeName,
                Age = employee.Age
            };
            return employeeResponseModel;
        }
        return null;
    }

    public int AddEmployee(EmployeeRequestModel model)
    {
        var employeeEntity = new Employee
        {
            EmployeeName = model.EmployeeName,
            Age = model.Age,
            DepartmentId = 1
        };
        return _employeeRepository.Insert(employeeEntity);
    }

    public int UpdateEmployee(EmployeeRequestModel model)
    {
        var employeeEntity = new Employee
        {
            EmployeeName = model.EmployeeName,
            Age = model.Age,
        };
        return _employeeRepository.Update(employeeEntity);
    }

    public int DeleteEmployee(int id)
    {
        return _employeeRepository.DeleteById(id);
    }
}