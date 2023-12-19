using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiect_clinica.Data;
using proiect_clinica.Models;

namespace proiect_clinica.Pages.Animale
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly proiect_clinica.Data.proiect_clinicaContext _context;

        public CreateModel(proiect_clinica.Data.proiect_clinicaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeComplet");
            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Animale == null || Animal == null)
            {
                return Page();
            }

            _context.Animale.Add(Animal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
