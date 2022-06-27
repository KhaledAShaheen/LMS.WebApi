using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.DAL.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Copies = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEntities_BookEntities_BookId",
                        column: x => x.BookId,
                        principalTable: "BookEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEntities_BookId",
                table: "UserEntities",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEntities");

            migrationBuilder.DropTable(
                name: "BookEntities");
        }
    }
}
