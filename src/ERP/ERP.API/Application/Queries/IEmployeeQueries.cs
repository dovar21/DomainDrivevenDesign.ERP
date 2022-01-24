namespace ERP.API.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmployeeQueries
    {
        Task<Employee> GetEmployeeAsync(int id);
    }
}
