using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prueba_Clases;

    public class ApiPruebaContext : DbContext
    {
        public ApiPruebaContext (DbContextOptions<ApiPruebaContext> options)
            : base(options)
        {
        }

        public DbSet<Prueba_Clases.Raza> Razas { get; set; } = default!;

public DbSet<Prueba_Clases.Especie> Especies { get; set; } = default!;

public DbSet<Prueba_Clases.Animal> Animals { get; set; } = default!;
    }
