using ERP.Domain.SeedWork;
using System.Threading.Tasks;

namespace ERP.Domain.AggregatesModel.PositionAggregate
{
    public interface IPositionRepository : IRepository<Position>
    {
        Position Add(Position entity);
        Position Update(Position entity);
        Task<Position> FindByIdAsync(int id);
    }
}
