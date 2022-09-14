using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardGameApi.Migrations
{
    /// <inheritdoc />
    public partial class FirstIntital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardOne = table.Column<int>(type: "int", nullable: false),
                    CardTwo = table.Column<int>(type: "int", nullable: false),
                    CardThree = table.Column<int>(type: "int", nullable: false),
                    CardFour = table.Column<int>(type: "int", nullable: false),
                    CardFive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardHistories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardHistories");
        }
    }
}
