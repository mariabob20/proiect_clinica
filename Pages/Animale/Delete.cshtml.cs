using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_clinica.Data;
using proiect_clinica.Models;

namespace proiect_clinica.Pages.Animale
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly proiect_clinica.Data.proiect_clinicaContext _context;

        public DeleteModel(proiect_clinica.Data.proiect_clinicaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Animal Animal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Animale == null)
            {
                return NotFound();
            }

            var animal = await _context.Animale.FirstOrDefaultAsync(m => m.ID == id);

            if (animal == null)
            {
                return NotFound();
            }
            else 
            {
                Animal = animal;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Animale == null)
            {
                return NotFound();
            }
            var animal = await _context.Animale.FindAsync(id);

            if (animal != null)
            {
                Animal = animal;
                _context.Animale.Remove(Animal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
