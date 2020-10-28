using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyList.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyList.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CompanyListContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CompanyListContext>>()))
            {
                // Look for any movies.
                if (context.Company.Any())
                {
                    return;   // DB has been seeded
                }

                context.Company.AddRange(
                    new Company
                    {
                        Title = "Nestle"
                    },

                    new Company
                    {
                        Title = "Open Text"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}