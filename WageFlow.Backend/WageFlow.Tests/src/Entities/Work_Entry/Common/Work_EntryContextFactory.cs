using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Persistence.src.Data;

namespace WageFlow.Tests.src.Entities.Work_Entry.Common
{
    public class Work_EntryContextFactory
    {
        public static int id_work_entry_for_delete = 3;
        public static int id_work_entry_for_update = 4;

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

            context.Work_Type.AddRange(
                new Domain.src.Entities.Work_Type
                {
                    id_work_type = 1,
                    name_work_type = "Имя 1",
                    amount_work_type = 1
                },

                new Domain.src.Entities.Work_Type
                {
                    id_work_type = 2,
                    name_work_type = "Имя 2",
                    amount_work_type = 2
                },

                new Domain.src.Entities.Work_Type
                {
                    id_work_type = 3,
                    name_work_type = "Имя 3",
                    amount_work_type = 3
                },

                new Domain.src.Entities.Work_Type
                {
                    id_work_type = 4,
                    name_work_type = "Имя 4",
                    amount_work_type = 4
                });

            context.Work_Entry.AddRange(
                new Domain.src.Entities.Work_Entry
                {
                    id_work_entry = 1,
                    quantity_work_entry = 1,
                    date_work_entry = DateOnly.FromDateTime(DateTime.Now),
                    id_staff = 1,
                    id_work_type = 1
                },

                new Domain.src.Entities.Work_Entry
                {
                    id_work_entry = 2,
                    quantity_work_entry = 2,
                    date_work_entry = DateOnly.FromDateTime(DateTime.Now),
                    id_staff = 2,
                    id_work_type = 2
                },

                new Domain.src.Entities.Work_Entry
                {
                    id_work_entry = id_work_entry_for_update,
                    quantity_work_entry = 3,
                    date_work_entry = DateOnly.FromDateTime(DateTime.Now),
                    id_staff = 3,
                    id_work_type = 3
                },

                new Domain.src.Entities.Work_Entry
                {
                    id_work_entry = id_work_entry_for_delete,
                    quantity_work_entry = 4,
                    date_work_entry = DateOnly.FromDateTime(DateTime.Now),
                    id_staff = 4,
                    id_work_type = 4
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
