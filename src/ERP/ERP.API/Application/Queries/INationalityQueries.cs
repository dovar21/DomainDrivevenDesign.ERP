namespace ERP.API.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INationalityQueries
    {
        Task<IEnumerable<Nationality>> GetNationalitiesAsync();
        Task<Nationality> GetNationalityAsync(int id);
    }
}
