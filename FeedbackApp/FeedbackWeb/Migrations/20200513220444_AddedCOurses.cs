using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackWeb.Migrations
{
    public partial class AddedCOurses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Teachers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "TeacherId");

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "ab@feedback.com", "Alin", "Bradut" },
                    { 2, "lc@feedback.com", "Larisa", "Costache" },
                    { 3, "gt@feedback.com", "George", "Trifan" },
                    { 4, "on@feedback.com", "Ovidiu", "Netoiu" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "ab@feedback.com", "Alin", "Bradut" },
                    { 2, "lc@feedback.com", "Larisa", "Costache" },
                    { 3, "gt@feedback.com", "George", "Trifan" },
                    { 4, "on@feedback.com", "Ovidiu", "Netoiu" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
