namespace ERP.API.Application.Queries
{
    using Dapper;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;

    public class GenderQueries
        : IGenderQueries
    {
        private string _connectionString = string.Empty;

        public GenderQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }


        public async Task<Gender> GetGenderAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"select *
                        FROM dbo.Genders e                        
                        WHERE e.Id=@id"
                        , new { id }
                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapGenderItems(result);
            }
        }
        public async Task<IEnumerable<Gender>> GetGendersAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<Gender>("SELECT * FROM dbo.Genders");
            }
        }
        private Gender MapGenderItems(dynamic result)
        {
            return new Gender
            {
                Id = result[0].Id,
                Name = result[0].Name,
                IsEnabled = result[0].IsEnabled,
                CreatedOn = result[0].CreatedOn,
                DeletedOn = result[0].DeletedOn,
            };
        }
    }
}
