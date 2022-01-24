namespace ERP.API.Application.Queries
{
    using Dapper;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;

    public class NationalityQueries
        : INationalityQueries
    {
        private string _connectionString = string.Empty;

        public NationalityQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }


        public async Task<Nationality> GetNationalityAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"select *
                        FROM dbo.Nationalities e                        
                        WHERE e.Id=@id"
                        , new { id }
                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapNationalityItems(result);
            }
        }
        public async Task<IEnumerable<Nationality>> GetNationalitiesAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<Nationality>("SELECT * FROM dbo.Nationalities");
            }
        }
        private Nationality MapNationalityItems(dynamic result)
        {
            return new Nationality
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
