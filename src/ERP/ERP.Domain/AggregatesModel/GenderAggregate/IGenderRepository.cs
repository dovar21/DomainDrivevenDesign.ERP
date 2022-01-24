using ERP.Domain.SeedWork;
using System.Threading.Tasks;

namespace ERP.Domain.AggregatesModel.GenderAggregate
{
    public interface IGenderRepository : IRepository<Gender>
    {
        Gender Add(Gender entity);
        Gender Update(Gender entity);
        Task<Gender> FindByIdAsync(int id);
    }
}
