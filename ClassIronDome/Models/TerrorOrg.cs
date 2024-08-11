﻿using System.ComponentModel.DataAnnotations;

namespace ClassIronDome.Models
{
    public class TerrorOrg
    {
        [Key]
        public int Id { get; set; }
        public int Distance { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }    
    }
}
