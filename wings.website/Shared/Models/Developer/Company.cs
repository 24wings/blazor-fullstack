using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace wings.website.Shared.Models
{
   public class Company
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        [Required]
        public string code { get; set; }

        public string avatarUrl { get; set; }

        //public DateTime createAt { get; set; } = DateTime.Now;

        public bool isActive { get; set; } = false;

    }
}
