using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_clinica.Data;
using proiect_clinica.Models;

namespace proiect_clinica.Pages.Angajati
{
    public class EditModel : AngajatCalificarePageModel
    {
        private readonly proiect_clinicaContext _context;

        public EditModel(proiect_clinicaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Angajat Angajat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Angajat == null)
            {
                return NotFound();
            }

            Angajat = await _context.Angajat
                .Include(a => a.AngajatCalificari).ThenInclude(ac => ac.Calificare)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Angajat == null)
            {
                return NotFound();
            }

            PopulateAssignedCalificare(_context, Angajat);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCalificari)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajatToUpdate = await _context.Angajat
                .Include(a => a.AngajatCalificari)
                .ThenInclude(ac => ac.Calificare)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (angajatToUpdate == null)
            {
                return NotFound();
            }

            // Asigură-te că toate proprietățile necesare sunt actualizate
            if (await TryUpdateModelAsync<Angajat>(
                angajatToUpdate,
                "Angajat", // Prefixul pentru formular
                a => a.Nume, a => a.Prenume, a => a.Calificare, a => a.DataAngajare, a => a.Adresa))
            {
                UpdateAngajatCalificare(_context, selectedCalificari, angajatToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Dacă actualizarea a eșuat, repopulează lista de calificări atribuite
            PopulateAssignedCalificare(_context, angajatToUpdate);
            return Page();
        }
    }
}
