using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase;

public class DuelsContext : DbContext
{
    public DbSet<Character> Characters { get; set; }

    public DbSet<DuelResult> DuelResults { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>().HasKey(x => x.Id);
        modelBuilder.Entity<Character>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<Character>().Property(x => x.Race).IsRequired();


        modelBuilder.Entity<DuelResult>().HasKey(x => x.Id);
        modelBuilder.Entity<DuelResult>()
            .HasOne(x => x.Challenger)
            .WithMany(x => x.ChallengedDuels)
            .HasForeignKey(x => x.ChallengerId);

        modelBuilder.Entity<DuelResult>()
            .HasOne(x => x.Receiver)
            .WithMany(x => x.ReceivedDuels)
            .HasForeignKey(x => x.ReceiverId);

        base.OnModelCreating(modelBuilder);
    }
    
    public DuelsContext() : base(
        GetOptions("User ID=postgres;Password=зщыепкуы;Server=localhost;Port=5432;Database=DuelsDb"))
    {
    }

    public DuelsContext(string connectionString) : base(GetOptions(connectionString))
    {
    }

    private static DbContextOptions GetOptions(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DuelsContext>();
        optionsBuilder.UseNpgsql(connectionString);
        return optionsBuilder.Options;
    }
}