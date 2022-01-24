namespace ERP.API.Application.Queries
{
    using Dapper;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;

    public class PositionQueries
        : IPositionQueries
    {
        private string _connectionString = string.Empty;

        public PositionQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }


        public async Task<Position> GetPositionAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"select *
                        FROM dbo.Positions e                        
                        WHERE e.Id=@id"
                        , new { id }
                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapPositionItems(result);
            }
        }
        public async Task<IEnumerable<Position>> GetPositionsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<Position>("SELECT * FROM dbo.Positions");
            }
        }
        private Position MapPositionItems(dynamic result)
        {
            return new Position
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
