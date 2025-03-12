using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System
{
    public class employeedbcontext:DbContext
    {
        
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SHIVA-ARUGULA-1;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

    }
}
