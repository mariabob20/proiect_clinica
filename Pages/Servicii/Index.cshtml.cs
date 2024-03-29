﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_clinica.Data;
using proiect_clinica.Models;

namespace proiect_clinica.Pages.Servicii
{
    public class IndexModel : PageModel
    {
        private readonly proiect_clinica.Data.proiect_clinicaContext _context;

        public IndexModel(proiect_clinica.Data.proiect_clinicaContext context)
        {
            _context = context;
        }

        public IList<Serviciu> Serviciu { get;set; } = default!;

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;

            IQueryable<Serviciu> serviciuIQ = _context.Serviciu.Include(b => b.Angajat);

            if (!String.IsNullOrEmpty(searchString))
            {
                serviciuIQ = serviciuIQ.Where(s => s.Nume.Contains(searchString));
            }

            Serviciu = await serviciuIQ.ToListAsync();
        }
    }
}
