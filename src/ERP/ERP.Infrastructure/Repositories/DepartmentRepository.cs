using Microsoft.EntityFrameworkCore;
using ERP.Domain.SeedWork;
using ERP.Domain.Exceptions;
using System.Linq;
using System;
using System.Threading.Tasks;
using ERP.Domain.AggregatesModel.DepartmentAggregate;

namespace ERP.Infrastructure.Repositories
{
    public class DepartmentRepository
        : IDepartmentRepository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public DepartmentRepository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Department Add(Department entity)
        {
            return  _context.Departments.Add(entity).Entity;
               
        }

        public async Task<Department> FindByIdAsync(int id)
        {
            var entity = await _context.Departments
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();

            return entity;
        }

        public Department Update(Department entity)
        {
            return _context.Departments
                   .Update(entity)
                   .Entity;
        }
    }
}
