using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Common;

namespace DataAccess.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        private const string ID_Column_Name = "Id";
        private const string connectionString = "Data Source=DAN-DESKTOP\\SQLEXPRESS;Initial Catalog=PayrollAndBenefitsDb;Integrated Security=True";

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProdedure,
            U parameters,
            string connectionId = "PayrollAndBenefitsDbConnection")
        {
            using (var connection = new SqlConnection(_config.GetConnectionString(connectionId)))
            {
                return await connection.QueryAsync<T>(storedProdedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task SaveData<T>(string storedProdedure,
            T parameters,
            string connectionId = "PayrollAndBenefitsDbConnection")
        {
            using (var connection = new SqlConnection(_config.GetConnectionString(connectionId)))
            {
                await connection.ExecuteAsync(storedProdedure, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> InsertNewEntity<T, U>(string storedProdedure,
            U parameters,
            string connectionId = "PayrollAndBenefitsDbConnection")
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.AddDynamicParams(parameters);
                dynamicParameters.Add(ID_Column_Name, dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteScalarAsync(storedProdedure, dynamicParameters, commandType: CommandType.StoredProcedure);

                return dynamicParameters.Get<int>(ID_Column_Name);
            }
        }
    }
}