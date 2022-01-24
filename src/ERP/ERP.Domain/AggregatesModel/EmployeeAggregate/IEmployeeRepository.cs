using ERP.Domain.SeedWork;
using System.Threading.Tasks;

namespace ERP.Domain.AggregatesModel.EmployeeAggregate
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee Add(Employee entity);
        Employee Update(Employee entity);
        Task<Employee> FindByIdAsync(int id);
    }
}
