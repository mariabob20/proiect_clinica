using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiect_clinica.Data;
using proiect_clinica.Models;

namespace proiect_clinica.Pages.Calificari
{
    public class CreateModel : PageModel
    {
        private readonly proiect_clinica.Data.proiect_clinicaContext _context;

        public CreateModel(proiect_clinica.Data.proiect_clinicaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Calificare Calificare { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Calificare == null || Calificare == null)
            {
                return Page();
            }

            _context.Calificare.Add(Calificare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
