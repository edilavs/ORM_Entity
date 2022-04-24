using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StadiumEF.Data.Entities
{
    class StadiumDbContext:DbContext
    {
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=VALIDAPC;Database=StadiumEF;Trusted_Connection=TRUE;");
        }

    }
}
