using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackWeb.Migrations
{
    public partial class BetterDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Teachers");

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Teachers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 1,
                column: "TeacherName",
                value: "Alin Bradut");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 2,
                column: "TeacherName",
                value: "Larisa Costache");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 3,
                column: "TeacherName",
                value: "George Trifan");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 4,
                column: "TeacherName",
                value: "Ovidiu Netoiu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Teachers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Teachers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Teachers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Alin", "Bradut" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Larisa", "Costache" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "George", "Trifan" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 4,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Ovidiu", "Netoiu" });
        }
    }
}
