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
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int? UserId {get;set;}
        public List<User> UserReview {get;set;}

        [ForeignKey("Admin")]
        public int? AdminId {get;set;}
        public List<Admin> AdminReviews {get;set;}

        public Review() {
            AdminReviews = new List<Admin>();
            UserReview = new List<User>();
        }

    }
}