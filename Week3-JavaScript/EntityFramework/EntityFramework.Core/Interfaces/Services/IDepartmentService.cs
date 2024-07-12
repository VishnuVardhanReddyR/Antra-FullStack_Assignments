using EntityFramework.Core.Models.RequestModel;
using EntityFramework.Core.Models.ResponseModel;

namespace EntityFramework.Core.Interfaces.Services;

public interface IDepartmentService
{
    List<DepartmentResponseModel> GetAllDepartments();
    
    DepartmentResponseModel GetById(int id);
    
    int AddDepartment(DepartmentRequestModel model);

    int UpdateDepartment(DepartmentRequestModel model);

    int DeleteDepartment(int id);
}