using Microsoft.EntityFrameworkCore;
using ProniaWebApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaWebApp.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Website Base Models
        public DbSet<Slider> Sliders { get; set; }
    }
}
