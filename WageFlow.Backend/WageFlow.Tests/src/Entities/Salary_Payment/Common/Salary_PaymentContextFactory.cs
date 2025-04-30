using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Domain.src.Entities;
using WageFlow.Persistence.src.Data;

namespace WageFlow.Tests.src.Entities.Salary_Payment.Common
{
    public class Salary_PaymentContextFactory
    {
        public static int id_salary_payment_for_delete = 3;
        public static int id_salary_payment_for_update = 4;

        public static WageFlowDbContext Create()
        {
            var options = new DbContextOptionsBuilder<WageFlowDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new WageFlowDbContext(options);
            context.Database.EnsureCreated();

            context.Staff.AddRange(
                new Domain.src.Entities.Staff
                {
                    id_staff = 1,
                    lastname_staff = "1",
                    name_staff = "1",
                    patronymic_staff = "1",
                    email_staff = "1",
                    id_post = 1
                },

                new Domain.src.Entities.Staff
                {
                    id_staff = 2,
                    lastname_staff = "2",
                    name_staff = "2",
                    patronymic_staff = "2",
                    email_staff = "2",
                    id_post = 1
                },

                new Domain.src.Entities.Staff
                {
                    id_staff = 3,
                    lastname_staff = "3",
                    name_staff = "3",
                    patronymic_staff = "3",
                    email_staff = "3",
                    id_post = 1
                },

                new Domain.src.Entities.Staff
                {
                    id_staff = 4,
                    lastname_staff = "4",
                    name_staff = "4",
                    patronymic_staff = "4",
                    email_staff = "4",
                    id_post = 1
                });

            context.Salary_Payment.AddRange(
                new Domain.src.Entities.Salary_Payment
                {
                    id_salary_payment = 1,
                    amount_salary_payment = 1,
                    start_date_salary_payment = DateOnly.FromDateTime(DateTime.Now),
                    end_date_salary_payment = DateOnly.FromDateTime(DateTime.Now),
                    date_salary_payment = DateOnly.FromDateTime(DateTime.Now),
                    id_staff = 1
                },

                new Domain.src.Entities.Salary_Payment
                {
                    id_salary_payment = 2,
                    amount_salary_payment = 2,
                    start_date_salary_payment = DateOnly.FromDateTime(DateTime.Now),
                    end_date_salary_payment = DateOnly.FromDateTime(DateTime.Now),
                    date_salary_payment = DateOnly.FromDateTime(DateTime.Now),
                    id_staff = 2
                },

                new Domain.src.Entities.Salary_Payment

                {
                    id_salary_payment = id_salary_payment_for_update,
                    amount_salary_payment = 3,
                    start_date_salary_payment = DateOnly.FromDateTime(DateTime.Now),
                    end_date_salary_payment = DateOnly.FromDateTime(DateTime.Now),
                    date_salary_payment = DateOnly.FromDateTime(DateTime.Now),
                    id_staff = 3
                },

                new Domain.src.Entities.Salary_Payment
                {
                    id_salary_payment = id_salary_payment_for_delete,
                    amount_salary_payment = 4,
                    start_date_salary_payment = DateOnly.FromDateTime(DateTime.Now),
                    end_date_salary_payment = DateOnly.FromDateTime(DateTime.Now),
                    date_salary_payment = DateOnly.FromDateTime(DateTime.Now),
                    id_staff = 4
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(WageFlowDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
