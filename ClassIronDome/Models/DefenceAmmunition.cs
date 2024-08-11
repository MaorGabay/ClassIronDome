using System.ComponentModel.DataAnnotations;

namespace ClassIronDome.Models
{
    public class DefenceAmmunition
    {
        [Key]
        public int Id { get; set; }

        public string Name {  get; set; }
        
        public int Amount { get; set; }
    }
}
