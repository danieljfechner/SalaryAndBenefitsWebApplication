using AutoMapper;
using DataAccess.Data;
using HumanResourcesAndPayrollApp.Models;

namespace HumanResourcesAndPayrollApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeData _employeeData;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeData employeeData, IMapper mapper)
        {
            _employeeData = employeeData;
            _mapper = mapper;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            var dalEmployee = _mapper.Map<DataAccess.Models.Employee>(employee);
            dalEmployee = await _employeeData.AddEmployee(dalEmployee);

            if (employee.Spouse != null)
            {
                await _employeeData.AddEmployeeSpouse(dalEmployee.Id, dalEmployee.Spouse);
            }

            return dalEmployee.Id;
        }

        public async Task<bool> AddNewEmployeeDependent(Dependent dependent)
        {
            var dalDependent = _mapper.Map<DataAccess.Models.Dependent>(dependent);
            await _employeeData.AddEmployeeDependent(dalDependent);

            return true;
        }

        public async Task<bool> RemoveEmployeeDependent(int dependentId)
        {
            await _employeeData.RemoveEmployeeDependent(dependentId);

            return true;
        }

        public async Task<IEnumerable<Dependent>> GetEmployeeDependents(int employeeId)
        {
            var dalDependents = await _employeeData.GetEmployeeDependents(employeeId);
            var dependentModels = _mapper.Map<List<Dependent>>(dalDependents);

            return dependentModels;
        }

        public async Task<Spouse> GetEmployeeSpouse(int employeeId)
        {
            var dalSpouse = await _employeeData.GetEmployeeSpouse(employeeId);
            var spouseModel = _mapper.Map<Spouse>(dalSpouse);

            return spouseModel;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var dalEmployee = await _employeeData.GetEmployee(employeeId);
            var employeeModel = _mapper.Map<Employee>(dalEmployee);

            return employeeModel;
        }

        public async Task<Employee> GetEmployeeWithAllDependents(int employeeId)
        {
            Employee employee;

            var employeeTask = GetEmployee(employeeId);
            var spouseTask = GetEmployeeSpouse(employeeId);
            var dependentsTask = GetEmployeeDependents(employeeId);

            await Task.WhenAll(employeeTask, spouseTask, dependentsTask);

            employee = employeeTask.Result;
            employee.Spouse = spouseTask.Result;
            employee.Dependents = dependentsTask.Result;

            return employee;
        }

        public async Task<EmployeeCostSummary> GetEmployeeWithAllAssociatedCosts(int employeeId)
        {
            var employeeSummary = new EmployeeCostSummary();
            employeeSummary.Employee = await GetEmployeeWithAllDependents(employeeId);

            employeeSummary.TotalYearlySalary = Employee.PAYCHECK_SIZE * Employee.PAYCHECKS_PER_YEAR;
            employeeSummary.TotalYearlySalary -= GetCostOfIndividual(employeeSummary.Employee, employeeSummary);
            if (employeeSummary.Employee?.Spouse != null)
            {
                employeeSummary.TotalYearlySalary -= GetCostOfIndividual(employeeSummary.Employee.Spouse, employeeSummary);
            }

            if (employeeSummary.Employee?.Dependents != null)
            {
                foreach (var dependent in employeeSummary.Employee.Dependents)
                {   
                    employeeSummary.TotalYearlySalary -= GetCostOfIndividual(dependent, employeeSummary);
                }
            }

            return employeeSummary;
        }

        private decimal GetCostOfIndividual(PersonBase person, EmployeeCostSummary employeeSummary)
        {
            if (person == null)
            {
                return 0;
            }

            var discountMultiplier = 1m;
            if (person.FirstName.StartsWith("A", StringComparison.InvariantCultureIgnoreCase))
            {
                discountMultiplier = PersonBase.StartsWithADiscount;
            }

            person.Cost = person.StandardCost * discountMultiplier;
            employeeSummary.TotalCostOfBenefits += person.Cost;

            return person.Cost;
        }
    }
}
