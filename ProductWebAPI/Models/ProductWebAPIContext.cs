using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductWebAPI.Models
{
    public class ProductWebAPIContext : IdentityDbContext<IdentityUser>
    {
        public ProductWebAPIContext() : base("DefaultConnection") { }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public static ProductWebAPIContext Create()
        {
            return new ProductWebAPIContext();
        }
    }


}