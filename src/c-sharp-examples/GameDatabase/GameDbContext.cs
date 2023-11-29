using GameDatabase.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GameDatabase;

public class GameDbContext : DbContext
{
    public DbSet<CharacterDbModel> Characters { get; set; }
    
    public DbSet<FightDbModel> Fights { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CharacterDbModel>().HasKey(x => x.Id);
        modelBuilder.Entity<CharacterDbModel>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<CharacterDbModel>().Property(x => x.Damage).IsRequired();
        modelBuilder.Entity<CharacterDbModel>().Property(x => x.Armor).IsRequired();
        modelBuilder.Entity<CharacterDbModel>().Property(x => x.Hp).IsRequired();

        modelBuilder.Entity<FightDbModel>().HasKey(x => x.Id);
        modelBuilder.Entity<FightDbModel>().Property(x => x.AttackerId).IsRequired();
        modelBuilder.Entity<FightDbModel>().Property(x => x.DefenderId).IsRequired();
        modelBuilder.Entity<FightDbModel>().Property(x => x.Result).IsRequired();
        modelBuilder.Entity<FightDbModel>().Property(x => x.Time).IsRequired();
        
        modelBuilder.Entity<FightDbModel>().HasOne(x => x.Attacker);
        modelBuilder.Entity<FightDbModel>().HasOne(x => x.Defender);

        base.OnModelCreating(modelBuilder);
    }
    
    public GameDbContext() : base(
        GetOptions("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=GamesDb"))
    {
    }

    public GameDbContext(string connectionString) : base(GetOptions(connectionString))
    {
    }

    private static DbContextOptions GetOptions(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GameDbContext>();
        optionsBuilder.UseNpgsql(connectionString);
        return optionsBuilder.Options;
    }
}