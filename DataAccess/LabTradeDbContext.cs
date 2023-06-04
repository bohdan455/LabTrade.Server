using DataAccess.Entities.Lab;
using DataAccess.Entities.Money;
using DataAccess.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LabTradeDbContext : IdentityDbContext<Seller>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
        public DbSet<LabFile> Files { get; set; }
        
        public LabTradeDbContext(DbContextOptions<LabTradeDbContext> options) : base(options)
        {

        }
    }
}
