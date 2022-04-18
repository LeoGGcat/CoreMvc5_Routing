using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreMvc5_Routing.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "汽車廠牌製造商"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "汽車名稱"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "汽車售價"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "汽車分類"),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "汽車年份"),
                    SoldNumber = table.Column<int>(type: "int", nullable: false, comment: "汽車年度銷售數字")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
