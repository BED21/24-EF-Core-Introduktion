using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerIntro
{
    public class CookbookContext : DbContext
    {
        public CookbookContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishIngredient> Ingredients { get; set; }


    }
}
