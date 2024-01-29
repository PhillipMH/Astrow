using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Astrow_Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

namespace Astrow_Domain.DBContext
{
    public class Astrow_DomainContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public Astrow_DomainContext() { }
        public Astrow_DomainContext(DbContextOptions<Astrow_DomainContext> options) : base(options) { }
        public DbSet<Students> Students { get; set; } = null!;
        public DbSet<Teachers> Teachers { get; set; } = null!;
        public DbSet<RegisterSick> registerSicks { get; set; } = null!;
        public DbSet<RegisterArrivedAndLeft> registerArrivedAndLeft { get; set; } = null!;
    }
}
