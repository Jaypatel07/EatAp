using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace EatAp.Models {
    public class Menu {
        [Key]
        public int MenuId {get;set;}

        [Required]
        [MinLength(2)]
        public string Name {get;set;}
        [Required]
        [MaxLength(255)]
        public string Description {get; set;}
        [Required]
        public double Price {get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("Admin")]
        public int? AdminId {get;set;}
        public List<Admin> Admins {get;set;}

        public Menu() {
            Admins = new List<Admin>();
        }

    }
}