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
    public class CreateModel : AngajatCalificarePageModel
    {
        private readonly proiect_clinicaContext _context;

        public CreateModel(proiect_clinicaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Inițializăm AssignedCalificareList pentru a afișa lista de calificări
            var angajat = new Angajat();
            PopulateAssignedCalificare(_context, angajat);
            return Page();
        }

        [BindProperty]
        public Angajat Angajat { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCalificari)
        {
            if (string.IsNullOrEmpty(Angajat.Adresa))
            {
                // Setează adresa cu o valoare implicită sau arată o eroare
                Angajat.Adresa = "Adresa implicită"; // sau orice altă valoare adecvată
            }

            if (selectedCalificari != null)
            {
                Angajat.AngajatCalificari = new List<AngajatCalificare>();
                foreach (var cal in selectedCalificari)
                {
                    var calToAdd = new AngajatCalificare
                    {
                        CalificareID = int.Parse(cal)
                    };
                    Angajat.AngajatCalificari.Add(calToAdd);
                }
            }

            if (!ModelState.IsValid)
            {
                PopulateAssignedCalificare(_context, Angajat);
                return Page();
            }

            _context.Angajat.Add(Angajat);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
