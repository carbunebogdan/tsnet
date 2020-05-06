using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Asp_Carbune_Vasile_Bogdan_Rp.Models;

namespace Asp_Carbune_Vasile_Bogdan_Rp.Data
{
    public class Asp_Carbune_Vasile_Bogdan_RpContext : DbContext
    {
        public Asp_Carbune_Vasile_Bogdan_RpContext (DbContextOptions<Asp_Carbune_Vasile_Bogdan_RpContext> options)
            : base(options)
        {
        }

        public DbSet<Asp_Carbune_Vasile_Bogdan_Rp.Models.Movie> Movie { get; set; }
    }
}
