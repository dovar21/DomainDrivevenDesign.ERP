using Microsoft.EntityFrameworkCore;
using ERP.Domain.SeedWork;
using ERP.Domain.Exceptions;
using System.Linq;
using System;
using System.Threading.Tasks;
using ERP.Domain.AggregatesModel.PositionAggregate;

namespace ERP.Infrastructure.Repositories
{
    public class PositionRepository
        : IPositionRepository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public PositionRepository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Position Add(Position entity)
        {
            return  _context.Positions.Add(entity).Entity;
               
        }

        public async Task<Position> FindByIdAsync(int id)
        {
            var entity = await _context.Positions
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();

            return entity;
        }

        public Position Update(Position entity)
        {
            return _context.Positions
                   .Update(entity)
                   .Entity;
        }
    }
}
