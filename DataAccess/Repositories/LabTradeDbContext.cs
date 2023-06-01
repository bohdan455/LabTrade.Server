using DataAccess.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class LabTradeDbContext : IdentityDbContext<Seller>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Seller>()
                .Property(b => b.Balance)
                .HasDefaultValue(0);
        }
        public LabTradeDbContext(DbContextOptions<LabTradeDbContext> options) : base(options)
        {
            
        }
    }
}
