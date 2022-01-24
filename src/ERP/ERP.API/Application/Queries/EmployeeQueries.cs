namespace ERP.API.Application.Queries
{
    using Dapper;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;

    public class EmployeeQueries
        : IEmployeeQueries
    {
        private string _connectionString = string.Empty;

        public EmployeeQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }


        public async Task<Employee> GetEmployeeAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"select *
                        FROM dbo.Employees e                        
                        WHERE e.Id=@id"
                        , new { id }
                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapEmployeeItems(result);
            }
        }

        private Employee MapEmployeeItems(dynamic result)
        {
            return new Employee
            {
                Id = result[0].Id,
                FirstName = result[0].FirstName,
                MiddleName = result[0].MiddleName,
                LastName = result[0].LastName,
            };
        }
    }
}
