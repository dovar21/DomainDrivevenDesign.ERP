using Microsoft.EntityFrameworkCore;
using ERP.Domain.SeedWork;
using ERP.Domain.Exceptions;
using System.Linq;
using System;
using System.Threading.Tasks;
using ERP.Domain.AggregatesModel.GenderAggregate;

namespace ERP.Infrastructure.Repositories
{
    public class GenderRepository
        : IGenderRepository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public GenderRepository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Gender Add(Gender entity)
        {
            return  _context.Genders.Add(entity).Entity;
               
        }

        public async Task<Gender> FindByIdAsync(int id)
        {
            var entity = await _context.Genders
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();

            return entity;
        }

        public Gender Update(Gender entity)
        {
            return _context.Genders
                   .Update(entity)
                   .Entity;
        }
    }
}
