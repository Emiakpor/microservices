using Microsoft.EntityFrameworkCore;
using PlatFormService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatFormService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Platform> Platforms { get; set; }
    }
}
