using ClassIronDome.Models;
using ClassIronDome.Utils;
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
            if (!DefenceAmmunitions.Any())
            {
                DefenceAmmunition def1 = new DefenceAmmunition { Name = "Iron Dome Missile", Amount = 100 };
                DefenceAmmunition def2 = new DefenceAmmunition { Name = "Patriot Missile", Amount = 50 };
                DefenceAmmunitions.AddRange(def1, def2);
                SaveChanges();
            }
            if (!TerrorOrgs.Any())
            {
                TerrorOrgs.AddRange(
                new TerrorOrg { Name = "Hamas", Location = "Lebanon", Distance = 70 },
                new TerrorOrg { Name = "Hezbollah", Location = "Lebanon", Distance = 100 },
                new TerrorOrg { Name = "Hothi", Location = "Yeman", Distance = 2377 },
                new TerrorOrg { Name = "Iran", Location = "Iran", Distance = 1600 }
                );
                SaveChanges();
            }

            if (!ThreatAmmunitions.Any())
            {
                ThreatAmmunitions.AddRange(
                    new ThreatAmmunition { Name = "Balisti", Speed = 18000 },
                    new ThreatAmmunition { Name = "Rocket", Speed = 880 },
                    new ThreatAmmunition { Name = "Catbam", Speed = 300 }
                    );
                SaveChanges();
            }
            if (!Threats.Any())
            {
                TerrorOrg? hamas = TerrorOrgs.FirstOrDefault(to => to.Name == "Hamas");
                ThreatAmmunition? rocket = ThreatAmmunitions.FirstOrDefault(ta => ta.Name == "Rocket");
                if (hamas != null && rocket != null)
                {

                    Threats.AddRange(
                        new Threat
                        {
                            Org = hamas,
                            Type = rocket,
                            ThreatAmount = 100
                        }

                        );
                    SaveChanges();
                }
            }
        }

        public IronDomeDbContext(DbContextOptions<IronDomeDbContext> options) : base(options)
        {
            Console.WriteLine("Database Exists: " + Database.EnsureCreated());
            Seed();
        }
    }
}
