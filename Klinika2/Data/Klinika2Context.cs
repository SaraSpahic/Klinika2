using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Klinika2.Models;

namespace Klinika2.Data
{
    public class Klinika2Context : DbContext
    {
        public Klinika2Context (DbContextOptions<Klinika2Context> options)
            : base(options)
        {
        }

        public DbSet<Klinika2.Models.Patients> Patients { get; set; }

        public DbSet<Klinika2.Models.Ljekar> Ljekar { get; set; }

        public DbSet<Klinika2.Models.Prijem> Prijem { get; set; }

        public DbSet<Klinika2.Models.Nalaz> Nalaz { get; set; }
    }
}
