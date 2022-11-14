using BlazorAppXXX.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppXXX.Data
{
    public class EmployeeService
    {
        private readonly MyContext _context;
        public EmployeeService(IDbContextFactory<MyContext> contextFactory)
        {
            // initial database context
            _context = contextFactory.CreateDbContext();
        }


        public async Task<List<Employee>> GetEmployees() {

            return await _context.Employees.ToListAsync();
        }
    }
}