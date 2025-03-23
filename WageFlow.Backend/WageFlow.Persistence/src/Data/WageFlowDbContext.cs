using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Interfaces;
using WageFlow.Domain.src.Entities;
using WageFlow.Persistence.src.EntityTypeConfigurations;

namespace WageFlow.Persistence.src.Data
{
    public class WageFlowDbContext : DbContext, IWageFlowDbContext
    {
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Payments_Type> Payments_Type { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Salary_Payment> Salary_Payment { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Work_Entry> Work_Entry { get; set; }
        public DbSet<Work_Type> Work_Type { get; set; }

        public WageFlowDbContext(DbContextOptions<WageFlowDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PaymentsConfiguration());
            builder.ApplyConfiguration(new Payments_TypeConfiguration());
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new Salary_PaymentConfiguration());
            builder.ApplyConfiguration(new StaffConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new Work_EntryConfiguration());
            builder.ApplyConfiguration(new Work_TypeConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
