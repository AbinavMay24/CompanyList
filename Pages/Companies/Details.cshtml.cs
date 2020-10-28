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
    public class DetailsModel : PageModel
    {
        private readonly CompanyList.Data.CompanyListContext _context;

        public DetailsModel(CompanyList.Data.CompanyListContext context)
        {
            _context = context;
        }

        public Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company = await _context.Company.FirstOrDefaultAsync(m => m.ID == id);

            if (Company == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
