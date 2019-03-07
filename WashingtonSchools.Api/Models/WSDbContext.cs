using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashingtonSchools.Api.Models
{
    public class WSDbContext : DbContext
    {
        public WSDbContext(DbContextOptions<WSDbContext> options): base(options)
        {

        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
