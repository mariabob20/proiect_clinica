using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_clinica.Data;
using proiect_clinica.Models;

namespace proiect_clinica.Pages.Animale
{
    public class DetailsModel : PageModel
    {
        private readonly proiect_clinica.Data.proiect_clinicaContext _context;

        public DetailsModel(proiect_clinica.Data.proiect_clinicaContext context)
        {
            _context = context;
        }

        public Animal Animal { get; set; } = default!;
        public Client Client { get; set; } = default!; // Adăugăm și informații despre client

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
                // Încarcăm informațiile despre clientul asociat animalului
                Client = await _context.Client.FirstOrDefaultAsync(c => c.ID == Animal.ClientID);
            }
            return Page();
        }
    }
}