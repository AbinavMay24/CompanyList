using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyList.Data;
using CompanyList.Models;

namespace CompanyList.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly CompanyList.Data.CompanyListContext _context;

        public IndexModel(CompanyList.Data.CompanyListContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get; set; }

        //Modified 
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        //Modified 
        [BindProperty(SupportsGet = true)]
        public string OrderFilter { get; set; }

        public async Task OnGetAsync()
        {
            //Modified 
            var companies = from m in _context.Company
                            select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                Company = await companies.Where(s => s.Title.StartsWith(SearchString)).ToListAsync();

                if (OrderFilter == "Ascending")
                {
                    Company = Company.OrderBy(x => x.Title).ToList();
                }
                else
                {
                    Company = Company.OrderByDescending(x => x.Title).ToList();
                }
            }
            else
            {
                Company = await _context.Company.ToListAsync();

                if (OrderFilter == "Ascending")
                {
                    Company = Company.OrderBy(x => x.Title).ToList();
                }
                else
                {
                    Company = Company.OrderByDescending(x => x.Title).ToList();
                }
            }
        }
    }
}
