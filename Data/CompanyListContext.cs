using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CompanyList.Models;

namespace CompanyList.Data
{
    public class CompanyListContext : DbContext
    {
        public CompanyListContext (DbContextOptions<CompanyListContext> options)
            : base(options)
        {
        }

        public DbSet<CompanyList.Models.Company> Company { get; set; }
    }
}
