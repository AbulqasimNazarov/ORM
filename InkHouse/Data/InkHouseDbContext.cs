using InkHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace InkHouse.Data;

public class InkHouseDbContext : DbContext
{
    public DbSet<Painter> Painters { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Painting> Paintings { get; set; }

    public InkHouseDbContext(DbContextOptions<InkHouseDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Painter>()
            .HasOne(p => p.Country)
            .WithMany(c => c.Painters)
            .HasForeignKey(p => p.CountryId);

        modelBuilder.Entity<Painting>()
            .HasOne(p => p.Painter)
            .WithMany(p => p.Paintings)
            .HasForeignKey(p => p.PainterId);


        base.OnModelCreating(modelBuilder);
        var franceId = Guid.NewGuid();
        var germanyId = Guid.NewGuid();
        var englandId = Guid.NewGuid();

        var marcelRussoId = Guid.NewGuid();
        var henriCelineId = Guid.NewGuid();
        var francoisDupontId = Guid.NewGuid();

        modelBuilder.Entity<Country>().HasData(
        new Country { CountryId = franceId, Name = "Франция" },
        new Country { CountryId = germanyId, Name = "Германия" },
        new Country { CountryId = englandId, Name = "Англия" }
        );

        // Seed data for Painter
        modelBuilder.Entity<Painter>().HasData(
            new Painter { Id = marcelRussoId, Name = "Марсель", Surname = "Руссо", Birthdate = new DateTime(1970, 1, 1), CountryId = franceId },
            new Painter { Id = henriCelineId, Name = "Анри", Surname = "Селин", Birthdate = new DateTime(1980, 2, 2), CountryId = germanyId },
            new Painter { Id = francoisDupontId, Name = "Франсуа", Surname = "Дюпон", Birthdate = new DateTime(1990, 3, 3), CountryId = englandId }
        );

        // Seed data for Painting
        modelBuilder.Entity<Painting>().HasData(
            new Painting { PaintingId = new Guid("f8a8c851-2cbc-48c2-a439-bdc494d6329a"), Name = "Охота Амура", Image = "Assets/PaintingImg/f8a8c851-2cbc-48c2-a439-bdc494d6329a.jpg", Title = "Холст, масло (50х80)", Price = 14500, PainterId = marcelRussoId },
            new Painting { PaintingId = new Guid("27bad295-e53c-4060-8fb5-57681f1e4354"), Name = "Дама с собачкой", Image = "Assets/PaintingImg/27bad295-e53c-4060-8fb5-57681f1e4354.jpg", Title = "Акрил, бумага (50х80)", Price = 16500, PainterId = henriCelineId },
            new Painting { PaintingId = new Guid("7cea2648-a8fc-4cca-9730-85bf83ac437c"), Name = "Процедура", Image = "Assets/PaintingImg/7cea2648-a8fc-4cca-9730-85bf83ac437c.jpg", Title = "Цветная литография (40х60)", Price = 20000, PainterId = francoisDupontId }
        );

    }
}
