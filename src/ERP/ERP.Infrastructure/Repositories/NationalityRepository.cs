using Microsoft.EntityFrameworkCore;
using ERP.Domain.SeedWork;
using ERP.Domain.Exceptions;
using System.Linq;
using System;
using System.Threading.Tasks;
using ERP.Domain.AggregatesModel.EmployeeAggregate;

namespace ERP.Infrastructure.Repositories
{
    public class NationalityRepository
        : INationalityRepository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public NationalityRepository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Nationality Add(Nationality entity)
        {
            return  _context.Nationalities.Add(entity).Entity;
               
        }

        public async Task<Nationality> FindByIdAsync(int id)
        {
            var entity = await _context.Nationalities
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();

            return entity;
        }

        public Nationality Update(Nationality entity)
        {
            return _context.Nationalities
                   .Update(entity)
                   .Entity;
        }
    }
}
