using ERP.Domain.SeedWork;
using System.Threading.Tasks;

namespace ERP.Domain.AggregatesModel.DepartmentAggregate
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Department Add(Department entity);
        Department Update(Department entity);
        Task<Department> FindByIdAsync(int id);
    }
}
