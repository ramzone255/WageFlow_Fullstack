using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WageFlow.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments_Type",
                columns: table => new
                {
                    id_payments_type = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_payments_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments_Type", x => x.id_payments_type);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    id_post = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_post = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.id_post);
                });

            migrationBuilder.CreateTable(
                name: "Work_Type",
                columns: table => new
                {
                    id_work_type = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_work_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    amount_work_type = table.Column<float>(type: "real", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work_Type", x => x.id_work_type);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    id_staff = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lastname_staff = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name_staff = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    patronymic_staff = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email_staff = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_post = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.id_staff);
                    table.ForeignKey(
                        name: "FK_Staff_Post_id_post",
                        column: x => x.id_post,
                        principalTable: "Post",
                        principalColumn: "id_post",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    id_payments = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount_payments = table.Column<float>(type: "real", maxLength: 20, nullable: false),
                    comment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    date_payments = table.Column<DateOnly>(type: "date", nullable: false),
                    id_staff = table.Column<int>(type: "int", nullable: false),
                    id_payments_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.id_payments);
                    table.ForeignKey(
                        name: "FK_Payments_Payments_Type_id_payments_type",
                        column: x => x.id_payments_type,
                        principalTable: "Payments_Type",
                        principalColumn: "id_payments_type",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Staff_id_staff",
                        column: x => x.id_staff,
                        principalTable: "Staff",
                        principalColumn: "id_staff",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salary_Payment",
                columns: table => new
                {
                    id_salary_payment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount_salary_payment = table.Column<float>(type: "real", maxLength: 20, nullable: false),
                    start_date_salary_payment = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date_salary_payment = table.Column<DateOnly>(type: "date", nullable: false),
                    date_salary_payment = table.Column<DateOnly>(type: "date", nullable: false),
                    id_staff = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary_Payment", x => x.id_salary_payment);
                    table.ForeignKey(
                        name: "FK_Salary_Payment_Staff_id_staff",
                        column: x => x.id_staff,
                        principalTable: "Staff",
                        principalColumn: "id_staff",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    id_staff = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id_user);
                    table.ForeignKey(
                        name: "FK_User_Staff_id_staff",
                        column: x => x.id_staff,
                        principalTable: "Staff",
                        principalColumn: "id_staff",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Work_Entry",
                columns: table => new
                {
                    id_work_entry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity_work_entry = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    date_work_entry = table.Column<DateOnly>(type: "date", nullable: false),
                    id_staff = table.Column<int>(type: "int", nullable: false),
                    id_work_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work_Entry", x => x.id_work_entry);
                    table.ForeignKey(
                        name: "FK_Work_Entry_Staff_id_staff",
                        column: x => x.id_staff,
                        principalTable: "Staff",
                        principalColumn: "id_staff",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Work_Entry_Work_Type_id_work_type",
                        column: x => x.id_work_type,
                        principalTable: "Work_Type",
                        principalColumn: "id_work_type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salary_Payment_Payments",
                columns: table => new
                {
                    id_salary_payment_payments = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_payments = table.Column<int>(type: "int", nullable: true),
                    id_salary_payment = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary_Payment_Payments", x => x.id_salary_payment_payments);
                    table.ForeignKey(
                        name: "FK_Salary_Payment_Payments_Payments_id_payments",
                        column: x => x.id_payments,
                        principalTable: "Payments",
                        principalColumn: "id_payments");
                    table.ForeignKey(
                        name: "FK_Salary_Payment_Payments_Salary_Payment_id_salary_payment",
                        column: x => x.id_salary_payment,
                        principalTable: "Salary_Payment",
                        principalColumn: "id_salary_payment");
                });

            migrationBuilder.CreateTable(
                name: "Work_Entry_Salary_Payment",
                columns: table => new
                {
                    id_work_entry_salary_payment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_work_entry = table.Column<int>(type: "int", nullable: true),
                    id_salary_payment = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work_Entry_Salary_Payment", x => x.id_work_entry_salary_payment);
                    table.ForeignKey(
                        name: "FK_Work_Entry_Salary_Payment_Salary_Payment_id_salary_payment",
                        column: x => x.id_salary_payment,
                        principalTable: "Salary_Payment",
                        principalColumn: "id_salary_payment");
                    table.ForeignKey(
                        name: "FK_Work_Entry_Salary_Payment_Work_Entry_id_work_entry",
                        column: x => x.id_work_entry,
                        principalTable: "Work_Entry",
                        principalColumn: "id_work_entry");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_id_payments",
                table: "Payments",
                column: "id_payments",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_id_payments_type",
                table: "Payments",
                column: "id_payments_type");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_id_staff",
                table: "Payments",
                column: "id_staff");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Type_id_payments_type",
                table: "Payments_Type",
                column: "id_payments_type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_id_post",
                table: "Post",
                column: "id_post",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salary_Payment_id_salary_payment",
                table: "Salary_Payment",
                column: "id_salary_payment",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salary_Payment_id_staff",
                table: "Salary_Payment",
                column: "id_staff");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_Payment_Payments_id_payments",
                table: "Salary_Payment_Payments",
                column: "id_payments");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_Payment_Payments_id_salary_payment",
                table: "Salary_Payment_Payments",
                column: "id_salary_payment");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_Payment_Payments_id_salary_payment_payments",
                table: "Salary_Payment_Payments",
                column: "id_salary_payment_payments",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_id_post",
                table: "Staff",
                column: "id_post");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_id_staff",
                table: "Staff",
                column: "id_staff",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_id_staff",
                table: "User",
                column: "id_staff");

            migrationBuilder.CreateIndex(
                name: "IX_User_id_user",
                table: "User",
                column: "id_user",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Work_Entry_id_staff",
                table: "Work_Entry",
                column: "id_staff");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Entry_id_work_entry",
                table: "Work_Entry",
                column: "id_work_entry",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Work_Entry_id_work_type",
                table: "Work_Entry",
                column: "id_work_type");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Entry_Salary_Payment_id_salary_payment",
                table: "Work_Entry_Salary_Payment",
                column: "id_salary_payment");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Entry_Salary_Payment_id_work_entry",
                table: "Work_Entry_Salary_Payment",
                column: "id_work_entry");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Entry_Salary_Payment_id_work_entry_salary_payment",
                table: "Work_Entry_Salary_Payment",
                column: "id_work_entry_salary_payment",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Work_Type_id_work_type",
                table: "Work_Type",
                column: "id_work_type",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salary_Payment_Payments");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Work_Entry_Salary_Payment");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Salary_Payment");

            migrationBuilder.DropTable(
                name: "Work_Entry");

            migrationBuilder.DropTable(
                name: "Payments_Type");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Work_Type");

            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
