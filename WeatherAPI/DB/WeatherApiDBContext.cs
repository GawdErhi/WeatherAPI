using Microsoft.EntityFrameworkCore;
using WeatherAPI.Models;

namespace WeatherAPI.DB
{
    public class WeatherApiDBContext : DbContext
    {
        public DbSet<Atmosphere> Atmospheres { get; set; }

        public DbSet<Astronomy> Astronomies { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Condition> Conditions { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Wind> Winds { get; set; }

        public DbSet<WeatherObservation> WeatherObservations { get; set; }


        public WeatherApiDBContext()
        {

        }

        public WeatherApiDBContext(DbContextOptions<WeatherApiDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=WeatherAPIDataStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherObservation>(x =>
            {
                x.Property(x => x.Id).UseIdentityColumn();
                x.HasOne(x => x.Astronomy);
                x.HasOne(x => x.Atmosphere);
                x.HasOne(x => x.Wind);
                x.HasOne(x => x.Condition);
                x.HasOne(x => x.City);
            });

            modelBuilder.Entity<Wind>(x =>
            {
                x.Property(x => x.Id).UseIdentityColumn();
            });

            modelBuilder.Entity<Condition>(x =>
            {
                x.Property(x => x.Id).UseIdentityColumn();
            });

            modelBuilder.Entity<Astronomy>(x =>
            {
                x.Property(x => x.Id).UseIdentityColumn();
            });

            modelBuilder.Entity<Atmosphere>(x =>
            {
                x.Property(x => x.Id).UseIdentityColumn();
            });

            modelBuilder.Entity<Country>(x =>
            {
                x.Property(x => x.Id).UseIdentityColumn();
                x.HasMany(x => x.Cities);
            });

            modelBuilder.Entity<City>(x =>
            {
                x.Property(x => x.Id).UseIdentityColumn();
                x.HasOne(x => x.Country);
            });
        }
    }
}
