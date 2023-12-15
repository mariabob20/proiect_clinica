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
    public class IndexModel : PageModel
    {
        private readonly proiect_clinica.Data.proiect_clinicaContext _context;

        public IndexModel(proiect_clinica.Data.proiect_clinicaContext context)
        {
            _context = context;
        }

        public IList<Angajat> Angajat { get; set; } = default!;
        public AngajatData AngajatD { get; set; }
        public int AngajatID { get; set; }
        public int CalificareID { get; set; }

        public async Task OnGetAsync(int? id, int? calificareID)
        {
            AngajatD = new AngajatData();

            AngajatD.Angajati = await _context.Angajat
                .Include(a => a.AngajatCalificari)
                .ThenInclude(ac => ac.Calificare)
                .AsNoTracking()
                .OrderBy(a => a.Nume)
                .ToListAsync();

            if (id != null)
            {
                AngajatID = id.Value;
                Angajat angajat = AngajatD.Angajati
                    .Where(i => i.ID == id.Value).Single();
                AngajatD.Calificari = angajat.AngajatCalificari.Select(s => s.Calificare);
            }
        }
    }
}