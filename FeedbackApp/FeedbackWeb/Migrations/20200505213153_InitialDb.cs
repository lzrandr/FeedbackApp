using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackWeb.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: false),
                    FeedbackWriterName = table.Column<string>(nullable: false),
                    FeedbackWriterEmail = table.Column<string>(nullable: false),
                    Feedback = table.Column<string>(maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CourseId",
                table: "Feedbacks",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
