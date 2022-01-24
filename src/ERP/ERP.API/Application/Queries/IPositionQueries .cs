namespace ERP.API.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPositionQueries
    {
        Task<IEnumerable<Position>> GetPositionsAsync();
        Task<Position> GetPositionAsync(int id);
    }
}
