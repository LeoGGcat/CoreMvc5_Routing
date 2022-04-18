using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreMvc5_Routing.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Category", "ImageUrl", "Name", "Price", "SoldNumber", "Year" },
                values: new object[,]
                {
                    { 1001, "Mercedes", "轎車", "Mercedes_AMG_S63.jpg", "AMG S63", 145695m, 120, 2017 },
                    { 1002, "Audi", "轎車", "Audi_S8.jpg", "S8", 116875m, 200, 2016 },
                    { 1003, "BMW", "轎車", "BMW_M3.jpg", "M3", 66495m, 85, 2016 },
                    { 1004, "AlfaRomeo", "轎車", "AlfaRomeo_GiuliaQuadrifoglio.jpg", "Giulia Quadrifoglio", 73595m, 62, 2015 },
                    { 1005, "Mercedes", "SUV", "MercedesBenz_GLS.jpg", "GLS Class", 68045m, 250, 2014 },
                    { 1006, "Porsche", "SUV", "Porsche_Cayenne.jpg", "Cayenne", 60650m, 160, 2017 },
                    { 1007, "Honda", "SUV", "Honda_CRV.jpg", "CR-V", 24985m, 1200, 2017 },
                    { 1008, "Bugatti", "跑車", "Bugatti_Chiron.jpg", "Chiron", 2998000m, 10, 2017 },
                    { 1009, "Lamborghini", "跑車", "Lamborghini_Huracan.jpg", "Huracan", 203295m, 30, 2015 },
                    { 1010, "Porsche", "跑車", "Porsche_718Boxster.jpg", "718 Boxster", 57050m, 49, 2014 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1010);
        }
    }
}
