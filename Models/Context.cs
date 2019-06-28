using Microsoft.EntityFrameworkCore;

namespace EatAp.Models {
    public class Context : DbContext {
        public Context (DbContextOptions<Context> options) : base (options) {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<RestaurantNReview> RestaurantNReviews { get; set; }

    }

}

