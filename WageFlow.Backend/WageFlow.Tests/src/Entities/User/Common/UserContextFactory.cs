using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Persistence.src.Data;

namespace WageFlow.Tests.src.Entities.User.Common
{
    public class UserContextFactory
    {

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
                    name_post = "Администратор"
                },

                new Domain.src.Entities.Post
                {
                    id_post = 2,
                    name_post = "Менеджер"
                },

                new Domain.src.Entities.Post
                {
                    id_post = 3,
                    name_post = "Сотрудник"
                });

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
                    id_post = 2
                },

                new Domain.src.Entities.Staff
                {
                    id_staff = 3,
                    lastname_staff = "3",
                    name_staff = "3",
                    patronymic_staff = "3",
                    email_staff = "3",
                    id_post = 3
                },

                new Domain.src.Entities.Staff
                {
                    id_staff = 4,
                    lastname_staff = "4",
                    name_staff = "4",
                    patronymic_staff = "4",
                    email_staff = "4",
                    id_post = 3
                });


            context.User.AddRange(
                new Domain.src.Entities.User
                {
                    id_user = 1,
                    user_name = "Ivan123",
                    user_password = "qwe123",
                    id_staff = 1
                },

                new Domain.src.Entities.User
                {
                    id_user = 2,
                    user_name = "Ivan456",
                    user_password = "qwe456",
                    id_staff = 2
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
