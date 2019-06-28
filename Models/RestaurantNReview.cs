using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EatAp.Models {
    public class RestaurantNReview {
        public int RestaurantNReviewId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}