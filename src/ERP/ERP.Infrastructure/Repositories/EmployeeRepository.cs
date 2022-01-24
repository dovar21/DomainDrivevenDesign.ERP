using Microsoft.EntityFrameworkCore;
using ERP.Domain.SeedWork;
using ERP.Domain.Exceptions;
using System.Linq;
using System;
using System.Threading.Tasks;
using ERP.Domain.AggregatesModel.EmployeeAggregate;

namespace ERP.Infrastructure.Repositories
{
    public class EmployeeRepository
        : IEmployeeRepository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public EmployeeRepository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Employee Add(Employee entity)
        {
            return  _context.Employees.Add(entity).Entity;
               
        }

        public async Task<Employee> FindByIdAsync(int id)
        {
            var entity = await _context.Employees
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();

            return entity;
        }

        public Employee Update(Employee entity)
        {
            return _context.Employees
                   .Update(entity)
                   .Entity;
        }
    }
}
