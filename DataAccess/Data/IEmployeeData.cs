using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface IEmployeeData
    {
        Task<Employee> AddEmployee(Employee employee);
        Task AddEmployeeDependent(Dependent dependent);
        Task AddEmployeeDependents(IEnumerable<Dependent> dependents);
        Task AddEmployeeSpouse(int employeeId, Spouse spouse);
        Task<Employee> GetEmployee(int id);
        Task<IEnumerable<Dependent>> GetEmployeeDependents(int employeeId);
        Task<Spouse> GetEmployeeSpouse(int employeeId);
        Task RemoveEmployeeDependent(int dependentId);
    }
}