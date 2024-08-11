using ClassIronDome.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ClassIronDome.Contexts
{
    public class IronDomeDbContext : DbContext
    {
        public DbSet<DefenceAmmunition> DefenceAmmunitions { get; set; }
        public DbSet<TerrorOrg> TerrorOrgs { get; set; }    
        public DbSet<Threat> Threats { get; set; }  
        public DbSet<ThreatAmmunition> ThreatAmmunitions { get; set; }  
        private void Seed()
        {

        }

        public IronDomeDbContext(DbContextOptions<IronDomeDbContext> options) : base(options)
        {
            Console.WriteLine("Database Exists: " + Database.EnsureCreated());
            Seed();
        }
    }
}
