using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proiect_clinica.Models;

namespace proiect_clinica.Data
{
    public class proiect_clinicaContext : DbContext
    {
        public proiect_clinicaContext(DbContextOptions<proiect_clinicaContext> options)
            : base(options)
        {
        }

        public DbSet<proiect_clinica.Models.Serviciu> Serviciu { get; set; } = default!;

        public DbSet<proiect_clinica.Models.Angajat>? Angajat { get; set; }
        public DbSet<Calificare> Calificare { get; set; }
        public DbSet<Client>? Client { get; set; }
        public DbSet<Programare>? Programare { get; set; }
        public DbSet<Animal> Animale { get; set; }
    }
}
