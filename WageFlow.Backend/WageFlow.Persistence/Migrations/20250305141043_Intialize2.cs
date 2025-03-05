using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WageFlow.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Intialize2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salary_Payment_Payments_Payments_id_payments",
                table: "Salary_Payment_Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Salary_Payment_Payments_Salary_Payment_id_salary_payment",
                table: "Salary_Payment_Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Entry_Salary_Payment_Salary_Payment_id_salary_payment",
                table: "Work_Entry_Salary_Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Entry_Salary_Payment_Work_Entry_id_work_entry",
                table: "Work_Entry_Salary_Payment");

            migrationBuilder.AlterColumn<int>(
                name: "id_work_entry",
                table: "Work_Entry_Salary_Payment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_salary_payment",
                table: "Work_Entry_Salary_Payment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_salary_payment",
                table: "Salary_Payment_Payments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_payments",
                table: "Salary_Payment_Payments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Salary_Payment_Payments_Payments_id_payments",
                table: "Salary_Payment_Payments",
                column: "id_payments",
                principalTable: "Payments",
                principalColumn: "id_payments",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salary_Payment_Payments_Salary_Payment_id_salary_payment",
                table: "Salary_Payment_Payments",
                column: "id_salary_payment",
                principalTable: "Salary_Payment",
                principalColumn: "id_salary_payment",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Entry_Salary_Payment_Salary_Payment_id_salary_payment",
                table: "Work_Entry_Salary_Payment",
                column: "id_salary_payment",
                principalTable: "Salary_Payment",
                principalColumn: "id_salary_payment",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Entry_Salary_Payment_Work_Entry_id_work_entry",
                table: "Work_Entry_Salary_Payment",
                column: "id_work_entry",
                principalTable: "Work_Entry",
                principalColumn: "id_work_entry",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salary_Payment_Payments_Payments_id_payments",
                table: "Salary_Payment_Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Salary_Payment_Payments_Salary_Payment_id_salary_payment",
                table: "Salary_Payment_Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Entry_Salary_Payment_Salary_Payment_id_salary_payment",
                table: "Work_Entry_Salary_Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Entry_Salary_Payment_Work_Entry_id_work_entry",
                table: "Work_Entry_Salary_Payment");

            migrationBuilder.AlterColumn<int>(
                name: "id_work_entry",
                table: "Work_Entry_Salary_Payment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "id_salary_payment",
                table: "Work_Entry_Salary_Payment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "id_salary_payment",
                table: "Salary_Payment_Payments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "id_payments",
                table: "Salary_Payment_Payments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Salary_Payment_Payments_Payments_id_payments",
                table: "Salary_Payment_Payments",
                column: "id_payments",
                principalTable: "Payments",
                principalColumn: "id_payments");

            migrationBuilder.AddForeignKey(
                name: "FK_Salary_Payment_Payments_Salary_Payment_id_salary_payment",
                table: "Salary_Payment_Payments",
                column: "id_salary_payment",
                principalTable: "Salary_Payment",
                principalColumn: "id_salary_payment");

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Entry_Salary_Payment_Salary_Payment_id_salary_payment",
                table: "Work_Entry_Salary_Payment",
                column: "id_salary_payment",
                principalTable: "Salary_Payment",
                principalColumn: "id_salary_payment");

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Entry_Salary_Payment_Work_Entry_id_work_entry",
                table: "Work_Entry_Salary_Payment",
                column: "id_work_entry",
                principalTable: "Work_Entry",
                principalColumn: "id_work_entry");
        }
    }
}
