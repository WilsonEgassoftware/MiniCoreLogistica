using Microsoft.EntityFrameworkCore;
using MiniCoreLogistica.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;

namespace MiniCoreLogistica.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Repartidor> Repartidores { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Envio> Envios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Zonas
            modelBuilder.Entity<Zona>().HasData(
                new Zona
                {
                    id_zona = 1,
                    nombre_zona = "Norte",
                    tarifa_por_kg = 1.50m
                },
                new Zona
                {
                    id_zona = 2,
                    nombre_zona = "Sur",
                    tarifa_por_kg = 2.00m
                }
            );

            // Seed Repartidores
            modelBuilder.Entity<Repartidor>().HasData(
                new Repartidor
                {
                    id_repartidor = 1,
                    nombre = "Andrés",
                    email = "andres@logistica.com"
                },
                new Repartidor
                {
                    id_repartidor = 2,
                    nombre = "Camila",
                    email = "camila@logistica.com"
                },
                new Repartidor
                {
                    id_repartidor = 3,
                    nombre = "Luis",
                    email = "luis@logistica.com"
                }
            );

            // Seed Envíos
            modelBuilder.Entity<Envio>().HasData(
                new Envio
                {
                    id_envio = 1,
                    id_repartidor = 1,
                    id_zona = 1,
                    peso_kg = 12.0m,
                    fecha_envio = new DateTime(2025, 5, 10)
                },
                new Envio
                {
                    id_envio = 2,
                    id_repartidor = 1,
                    id_zona = 1,
                    peso_kg = 20.0m,
                    fecha_envio = new DateTime(2025, 5, 15)
                },
                new Envio
                {
                    id_envio = 3,
                    id_repartidor = 2,
                    id_zona = 2,
                    peso_kg = 18.0m,
                    fecha_envio = new DateTime(2025, 5, 20)
                }
            );
        }
    }
}