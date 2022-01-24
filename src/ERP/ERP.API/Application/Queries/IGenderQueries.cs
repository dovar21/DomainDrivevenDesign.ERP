namespace ERP.API.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenderQueries
    {
        Task<IEnumerable<Gender>> GetGendersAsync();
        Task<Gender> GetGenderAsync(int id);
    }
}