using DuszaTKVGameLib;
using Microsoft.EntityFrameworkCore;

namespace BettingGameAPI.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(x => x.Bets)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
            builder.Entity<User>().Navigation(x => x.Bets).AutoInclude();

            builder.Entity<User>()
                .HasMany(x => x.Games)
                .WithOne(x => x.Organiser)
                .HasForeignKey(x => x.OrganiserId);
            builder.Entity<User>().Navigation(x => x.Games).AutoInclude();

            builder.Entity<Event>()
                .HasOne(x => x.Game)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.GameId);
            builder.Entity<Event>().Navigation(x => x.Game).AutoInclude();

            builder.Entity<Event>()
                .HasMany(x => x.Bets)
                .WithOne(x => x.Event)
                .HasForeignKey(x => x.EventId);
            builder.Entity<Event>().Navigation(x => x.Bets).AutoInclude();

            builder.Entity<Game>()
                .HasMany(x => x.Bets)
                .WithOne(x => x.Game)
                .HasForeignKey(x => x.GameId);
            builder.Entity<Game>().Navigation(x => x.Bets).AutoInclude();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
    }
}
