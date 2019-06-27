using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace EatAp.Models {
    public class User {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "First Name:")]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name:")]
        [MinLength(2)]
        public string LastName { get; set; }
        [Required]
        [DataType (DataType.EmailAddress)]
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Required]
        [DataType (DataType.Password)]
        [RegularExpression("^(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", 
        ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [MinLength(8)]
        [Display(Name = "Password:")]
        public string Password { get; set; }
        [NotMapped]
        [Compare ("Password")]
        [DataType (DataType.Password)]
        [Display(Name = "Confirm Password:")]
        public string ConfirmPW { get; set; }
      
    
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<RestaurantNReview> Reviews {get;set;}

        public User() {
            Reviews = new List<RestaurantNReview>();
        }



    }
}