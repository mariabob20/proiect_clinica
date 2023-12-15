using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiect_clinica.Data;
using proiect_clinica.Models;

namespace proiect_clinica.Pages.Calificari
{
    public class EditModel : PageModel
    {
        private readonly proiect_clinica.Data.proiect_clinicaContext _context;

        public EditModel(proiect_clinica.Data.proiect_clinicaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Calificare Calificare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Calificare == null)
            {
                return NotFound();
            }

            var calificare =  await _context.Calificare.FirstOrDefaultAsync(m => m.ID == id);
            if (calificare == null)
            {
                return NotFound();
            }
            Calificare = calificare;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Calificare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificareExists(Calificare.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CalificareExists(int id)
        {
          return (_context.Calificare?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
