using Dapper;
using DataAccess.DbAccess;
using DataAccess.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class EmployeeData : IEmployeeData
    {
        private readonly ISqlDataAccess _db;
        public EmployeeData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var result = await _db.LoadData<Employee, dynamic>(
                storedProdedure: "dbo.spGetEmployeeWithSpouseAndSalaryByEmployeeId",
                new { EmployeeId = id });

            return result.FirstOrDefault();
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _db.InsertNewEntity<Employee, dynamic>(
                storedProdedure: "dbo.spInsertEmployee",
                new
                {
                    employee.FirstName,
                    employee.MiddleName,
                    employee.LastName
                });

            employee.Id = result;

            return employee;
        }

        public async Task AddEmployeeSpouse(int employeeId, Spouse spouse)
        {
            await _db.SaveData(storedProdedure: "dbo.spInsertEmployeeSpouse",
                new
                {
                    EmployeeId = employeeId,
                    spouse.FirstName,
                    spouse.MiddleName,
                    spouse.LastName
                });
        }

        public async Task AddEmployeeDependent(Dependent dependent)
        {
            await _db.SaveData(storedProdedure: "dbo.spInsertEmployeeDependent",
                new
                {
                    EmployeeId = dependent.EmployeeId,
                    dependent.FirstName,
                    dependent.MiddleName,
                    dependent.LastName
                });
        }

        public async Task RemoveEmployeeDependent(int dependentId)
        {
            await _db.SaveData(storedProdedure: "dbo.spDeleteEmployeeDependent",
                new { dependentId = dependentId });
        }

        public async Task AddEmployeeDependents(IEnumerable<Dependent> dependents)
        {
            var dt = PrepareDependentsParameter(dependents);

            var employeeDependentsTableValuedParam = new
            {
                EmployeeDependents = dt.AsTableValuedParameter("EmployeeDependents")
            };

            await _db.SaveData(storedProdedure: "spInsertEmployeeDependents", employeeDependentsTableValuedParam);
        }

        private static DataTable PrepareDependentsParameter(IEnumerable<Dependent> dependents)
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn
            {
                DataType = typeof(int),
                ColumnName = "EmployeeId",
                AllowDBNull = false
            });

            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("MiddleName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));

            foreach (var dependent in dependents)
            {
                dt.Rows.Add(dependent.EmployeeId, dependent.FirstName, dependent.MiddleName, dependent.LastName);
            }

            return dt;
        }

        public async Task<IEnumerable<Dependent>> GetEmployeeDependents(int employeeId)
        {
            var result = await _db.LoadData<Dependent, dynamic>(
                storedProdedure: "dbo.spGetDependentsByEmployeeId",
                new { EmployeeId = employeeId });

            return result;
        }

        public async Task<Spouse> GetEmployeeSpouse(int employeeId)
        {
            var result = await _db.LoadData<Spouse, dynamic>(
                storedProdedure: "dbo.spGetEmployeeSpouse",
                new { EmployeeId = employeeId });

            return result.FirstOrDefault();
        }
    }
}
