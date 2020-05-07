using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackWeb.Migrations
{
    public partial class ChangeIdNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Courses_CourseId",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "FeedbackId",
                table: "Feedbacks",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "TheFeedback",
                table: "Feedbacks",
                maxLength: 1500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Courses",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "FeedbackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseId");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Java", 1 },
                    { 2, "Python", 2 },
                    { 3, "Javascrip", 3 },
                    { 4, "PHP", 4 }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "FeedbackId", "CourseId", "FeedbackWriterEmail", "FeedbackWriterName", "TheFeedback" },
                values: new object[,]
                {
                    { 1, 1, "a@a.com", "Bogdan Tudorica", "Totul a fost bine" },
                    { 2, 1, "b@b.com", "Jan Constatin", "Nu totul a fost bine" },
                    { 3, 2, "c@c.com", "Lili Horinca", "Totul a fost bine" },
                    { 4, 2, "d@d.com", "Bogdan Sava", "Nu totul a fost bine" },
                    { 5, 3, "c@c.com", "Ioana Constatin", "Nu totul a fost bine" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Courses_CourseId",
                table: "Feedbacks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Courses_CourseId",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "TheFeedback",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "Feedbacks",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Java", 1 },
                    { 2, "Python", 2 },
                    { 3, "Javascrip", 3 },
                    { 4, "PHP", 4 }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "CourseId", "Feedback", "FeedbackWriterEmail", "FeedbackWriterName" },
                values: new object[,]
                {
                    { 1, 1, "Totul a fost bine", "a@a.com", "Bogdan Tudorica" },
                    { 2, 1, "Nu totul a fost bine", "b@b.com", "Jan Constatin" },
                    { 3, 2, "Totul a fost bine", "c@c.com", "Lili Horinca" },
                    { 4, 2, "Nu totul a fost bine", "d@d.com", "Bogdan Sava" },
                    { 5, 3, "Nu totul a fost bine", "c@c.com", "Ioana Constatin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Courses_CourseId",
                table: "Feedbacks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
