using System.Data;
using System.Data.Common;
using Dapper;
using DapperTutorial.Core.Entities;
using DapperTutorial.Core.Interfaces;
using DapperTutorial.Infrastructure.Data;
namespace DapperTutorial.Infrastructure.Repositories;

public class DepartmentRepository: IRepository<Department>
{
    private Data.DbConnection _dbConnection = new Data.DbConnection();

    public int Insert(Department obj)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return conn.Execute("Insert INTO Department VALUES(@id, @departmentName, @location)", obj);
    }

    public int DeleteById(int id)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return conn.Execute("DELETE FROM Department where Id = @id", new { Id = id });
    }

    public int Update(Department obj)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return conn.Execute("UPDATE Department SET DepartmentName=@departmentName, Location=@Location" + " where Id=@id",
            obj);
    }

    public IEnumerable<Department> GetAll()
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return conn.Query<Department>("Select Id, DepartmentName, Location from Department");
    }

    public Department GetById(int id)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return conn.QuerySingleOrDefault<Department>("Select Id, DepartmentName, Location From Department where Id=@id",
            new { Id = id });
    }
}