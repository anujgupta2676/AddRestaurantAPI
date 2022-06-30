using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddRestaurantAPI.Models
{
    public class AddRestaurantDbContext : DbContext
    {
        public AddRestaurantDbContext(DbContextOptions<AddRestaurantDbContext> options) : base(options)
        {

        }

        public DbSet<AddRestaurant> AddRestaurant { get; set; }
        
    }
}
