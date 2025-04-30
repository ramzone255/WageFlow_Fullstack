using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Domain.src.Entities;
using WageFlow.Persistence.src.Data;

namespace WageFlow.Tests.src.Entities.Payments.Common
{
    public class PaymentsContextFactory
    {
        public static int id_payments_for_delete = 3;
        public static int id_payments_for_update = 4;

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

            context.Payments_Type.AddRange(
                new Domain.src.Entities.Payments_Type
                {
                    id_payments_type = 1,
                    name_payments_type = "1"
                },

                new Domain.src.Entities.Payments_Type
                {
                    id_payments_type = 2,
                    name_payments_type = "2"
                },

                new Domain.src.Entities.Payments_Type
                {
                    id_payments_type = 3,
                    name_payments_type = "3"
                },

                new Domain.src.Entities.Payments_Type
                {
                    id_payments_type = 4,
                    name_payments_type = "4"
                });

            context.Payments.AddRange(
                new Domain.src.Entities.Payments
                {
                    id_payments = 1,
                    amount_payments = 1,
                    comment = "Комментарий 1",
                    date_payments = DateOnly.FromDateTime(DateTime.Now),
                    id_staff = 1,
                    id_payments_type = 1
                },

                new Domain.src.Entities.Payments
                {
                    id_payments = 2,
                    amount_payments = 2,
                    comment = "Комментарий 2",
                    date_payments = DateOnly.FromDateTime(DateTime.Now),
                    id_staff = 2,
                    id_payments_type = 2
                },

                new Domain.src.Entities.Payments

                {
                    id_payments = id_payments_for_update,
                    amount_payments = 3,
                    comment = "Комментарий 3",
                    date_payments = DateOnly.FromDateTime(DateTime.Now),
                    id_staff = 3,
                    id_payments_type = 3
                },

                new Domain.src.Entities.Payments
                {
                    id_payments = id_payments_for_delete,
                    amount_payments = 4,
                    comment = "Комментарий 4",
                    date_payments = DateOnly.FromDateTime(DateTime.Now),
                    id_staff = 4,
                    id_payments_type = 4
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
