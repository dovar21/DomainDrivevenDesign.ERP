using ERP.Domain.SeedWork;
using System.Threading.Tasks;

namespace ERP.Domain.AggregatesModel.EmployeeAggregate
{
    public interface INationalityRepository : IRepository<Nationality>
    {
        Nationality Add(Nationality entity);
        Nationality Update(Nationality entity);
        Task<Nationality> FindByIdAsync(int id);
    }
}
