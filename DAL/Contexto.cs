using Adenawell_ValentinAP1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace Adenawell_ValentinAP1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }


    public DbSet<ViajesEspaciales> ViajesEspaciales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ViajesEspaciales>().HasData(
            new ViajesEspaciales
            {
                ViajeId = 1,
                Nombre = "Misión a Marte",
                Fecha = new DateTime(2026, 05, 20),
                Costo = 1500000.00m
            },
            new ViajesEspaciales
            {
                ViajeId = 2,
                Nombre = "Tour Lunar",
                Fecha = new DateTime(2026, 08, 15),
                Costo = 500000.00m
            },
            new ViajesEspaciales
            {
                ViajeId = 3,
                Nombre = "Exploración de Europa (Júpiter)",
                Fecha = new DateTime(2027, 12, 01),
                Costo = 9999999.99m
            }
        );
    }
}