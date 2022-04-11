using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProdedure, U parameters, string connectionId = "PayrollAndBenefitsDbConnection");
        Task SaveData<T>(string storedProdedure, T parameters, string connectionId = "PayrollAndBenefitsDbConnection");
        Task<int> InsertNewEntity<T, U>(string storedProdedure, U parameters, string connectionId = "PayrollAndBenefitsDbConnection");
    }
}