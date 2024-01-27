using Microsoft.EntityFrameworkCore;

namespace Taco_Food_Truck
{
    public class TacoDbContext :DbContext
    {
            public TacoDbContext(DbContextOptions<TacoDbContext> options) : base(options)
            { }

            public DbSet<Models.Taco> Tacos { get; set; }

            public DbSet<Models.Drink> Drinks { get; set; }
        }
    }
