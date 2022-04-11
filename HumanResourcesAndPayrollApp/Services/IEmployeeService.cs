using HumanResourcesAndPayrollApp.Models;

namespace HumanResourcesAndPayrollApp.Services
{
    public interface IEmployeeService
    {
        Task<int> AddEmployee(Employee employee);
        Task<bool> AddNewEmployeeDependent(Dependent dependent);
        Task<bool> RemoveEmployeeDependent(int dependentId);
        Task<IEnumerable<Dependent>> GetEmployeeDependents(int employeeId);
        Task<Spouse> GetEmployeeSpouse(int employeeId);
        Task<Employee> GetEmployee(int employeeId);
        Task<Employee> GetEmployeeWithAllDependents(int employeeId);
        Task<EmployeeCostSummary> GetEmployeeWithAllAssociatedCosts(int employeeId);
    }
}