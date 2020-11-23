using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinoMVC.Models
{
    public class DinoDbContext : DbContext
    {
        public DinoDbContext(DbContextOptions<DinoDbContext> opt) : base(opt)
        {

        }
        public DbSet<Dino> Dino { get; set; }
    }
}
