using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Domain.src.Entities;

namespace WageFlow.Application.src.Interfaces
{
    public interface IWageFlowDbContext
    {
        DbSet<Payments> Payments { get; set; }
        DbSet<Payments_Type> Payments_Type { get; set; }
        DbSet<Post> Post { get; set; }
        DbSet<Salary_Payment> Salary_Payment { get; set; }
        DbSet<Salary_Payment_Payments> Salary_Payment_Payments { get; set; }
        DbSet<Staff> Staff { get; set; }
        DbSet<User> User { get; set; }
        DbSet<Work_Entry> Work_Entry { get; set; }
        DbSet<Work_Entry_Salary_Payment> Work_Entry_Salary_Payment { get; set; }
        DbSet<Work_Type> Work_Type { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
