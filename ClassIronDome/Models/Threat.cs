using ClassIronDome.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassIronDome.Models
{
    public class Threat
    {



        [Key]
        public int Id { get; set; }

        [NotMapped]
        public int responseTime
        {
            get
            {
                return (Org.Distance / Type.Speed) * 3600;
            }
        }

        public TerrorOrg Org { get; set; }
        public ThreatAmmunition Type { get; set; }

        public int ThreatAmount { get; set; }
        public THREAT_STATUS Status { get; set; }
        public DateTime FiredAt { get; set; }
    }
}
