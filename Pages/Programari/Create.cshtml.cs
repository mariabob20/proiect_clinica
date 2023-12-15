using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiect_clinica.Data;

namespace proiect_clinica.Pages.Programari
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
            var serviciuList = _context.Serviciu
                .Include(b => b.Angajat)
            .Select(x => new
                    {
                       x.ID,
                ServiciuNume = x.Nume + " - " + x.Angajat.Nume + " " + x.Angajat.Prenume
                    });
            ViewData["ServiciuID"] = new SelectList(serviciuList, "ID", "ServiciuNume");
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeComplet");
            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Programare == null || Programare == null)
            {
                return Page();
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
