using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiningPredictionAPI.Data
{
    public class CurrentPriceContext : DbContext
    {
        public CurrentPriceContext(DbContextOptions<CurrentPriceContext> options) : base(options)
        {

        }

        public DbSet<CurrentPrice> CurrentPrices { get; set; }
    }

}
