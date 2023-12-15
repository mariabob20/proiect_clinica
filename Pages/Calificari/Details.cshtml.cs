using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_clinica.Data;
using proiect_clinica.Models;

namespace proiect_clinica.Pages.Calificari
{
    public class DetailsModel : PageModel
    {
        private readonly proiect_clinica.Data.proiect_clinicaContext _context;

        public DetailsModel(proiect_clinica.Data.proiect_clinicaContext context)
        {
            _context = context;
        }

      public Calificare Calificare { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Calificare == null)
            {
                return NotFound();
            }

            var calificare = await _context.Calificare.FirstOrDefaultAsync(m => m.ID == id);
            if (calificare == null)
            {
                return NotFound();
            }
            else 
            {
                Calificare = calificare;
            }
            return Page();
        }
    }
}
