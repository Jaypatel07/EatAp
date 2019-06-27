using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace EatAp.Models {
    public class Review {
        [Key]
        public int ReviewId {get;set;}

        [Required]
        [MinLength(2)]
        public string Name {get;set;}
        [Required]
        [MaxLength(255)]
        public string ReviewDesc {get; set;}
        [Required]
        public int RestaurantId {get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int UserId {get;set;}
        public User User {get;set;}
        
        public List<RestaurantNReview> RestaurantNReview {get;set;}

        public Review() {
            RestaurantNReview = new List<RestaurantNReview>();
        }
    }
}