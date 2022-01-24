namespace ERP.API.Application.Queries
{
    using Dapper;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;

    public class DepartmentQueries
        : IDepartmentQueries
    {
        private string _connectionString = string.Empty;

        public DepartmentQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }


        public async Task<Department> GetDepartmentAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"select *
                        FROM dbo.Departments e                        
                        WHERE e.Id=@id"
                        , new { id }
                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapDepartmentItems(result);
            }
        }
        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<Department>("SELECT * FROM dbo.Departments");
            }
        }
        private Department MapDepartmentItems(dynamic result)
        {
            return new Department
            {
                Id = result[0].Id,
                Name = result[0].Name,
                IsActive = result[0].IsActive,
                IsEnabled = result[0].IsEnabled,
                CreatedOn = result[0].CreatedOn,
                DeletedOn = result[0].DeletedOn,
            };
        }
    }
}
