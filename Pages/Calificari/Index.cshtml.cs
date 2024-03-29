﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly proiect_clinica.Data.proiect_clinicaContext _context;

        public IndexModel(proiect_clinica.Data.proiect_clinicaContext context)
        {
            _context = context;
        }

        public IList<Calificare> Calificare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Calificare != null)
            {
                Calificare = await _context.Calificare.ToListAsync();
            }
        }
    }
}
