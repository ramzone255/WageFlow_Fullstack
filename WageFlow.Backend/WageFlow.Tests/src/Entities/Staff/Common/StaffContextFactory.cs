using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Persistence.src.Data;

namespace WageFlow.Tests.src.Entities.Staff.Common
{
    public class StaffContextFactory
    {
        public static int id_staff_for_delete = 3;
        public static int id_staff_for_update = 4;

        public static WageFlowDbContext Create()
        {
            var options = new DbContextOptionsBuilder<WageFlowDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new WageFlowDbContext(options);
            context.Database.EnsureCreated();


            context.Post.AddRange(
                new Domain.src.Entities.Post
                {
                    id_post = 1,
                    name_post = "1"
                },

                new Domain.src.Entities.Post
                {
                    id_post = 2,
                    name_post = "2"
                },

                new Domain.src.Entities.Post
                {
                    id_post = 3,
                    name_post = "3"
                },

                new Domain.src.Entities.Post
                {
                    id_post = 4,
                    name_post = "4"
                });

            context.Staff.AddRange(
                new Domain.src.Entities.Staff
                {
                    id_staff = 1,
                    lastname_staff = "Фамилия 1",
                    name_staff = "Имя 1",
                    patronymic_staff = "Отчество 1",
                    email_staff = "Почта 1",
                    id_post = 1
                },

                new Domain.src.Entities.Staff
                {
                    id_staff = 2,
                    lastname_staff = "Фамилия 2",
                    name_staff = "Имя 2",
                    patronymic_staff = "Отчество 2",
                    email_staff = "Почта 2",
                    id_post = 2
                },

                new Domain.src.Entities.Staff

                {
                    id_staff = id_staff_for_update,
                    lastname_staff = "Фамилия 3",
                    name_staff = "Имя 3",
                    patronymic_staff = "Отчество 3",
                    email_staff = "Почта 3",
                    id_post = 3
                },

                new Domain.src.Entities.Staff
                {
                    id_staff = id_staff_for_delete,
                    lastname_staff = "Фамилия 4",
                    name_staff = "Имя 4",
                    patronymic_staff = "Отчество 4",
                    email_staff = "Почта 4",
                    id_post = 4
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
