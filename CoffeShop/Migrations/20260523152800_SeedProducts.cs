using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeShop.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Detail", "ImageUrl", "IsTrendingProduct", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Cà phê đen đậm đà truyền thống Việt Nam, pha phin thủ công.", "https://upload.wikimedia.org/wikipedia/commons/4/45/A_small_cup_of_coffee.JPG", true, "Cà phê đen", 25000m },
                    { 2, "Cà phê phin kết hợp sữa đặc ngọt ngào, hương vị đặc trưng.", "https://upload.wikimedia.org/wikipedia/commons/4/45/A_small_cup_of_coffee.JPG", true, "Cà phê sữa", 30000m },
                    { 3, "Cà phê sữa tỉ lệ sữa nhiều hơn, nhẹ nhàng và béo ngậy.", "https://upload.wikimedia.org/wikipedia/commons/4/45/A_small_cup_of_coffee.JPG", false, "Bạc xỉu", 32000m },
                    { 4, "Espresso pha với sữa nóng đánh bọt mịn, phong cách Ý.", "https://upload.wikimedia.org/wikipedia/commons/4/45/A_small_cup_of_coffee.JPG", true, "Cappuccino", 55000m },
                    { 5, "Espresso với lượng lớn sữa nóng, vị nhẹ và thơm.", "https://upload.wikimedia.org/wikipedia/commons/4/45/A_small_cup_of_coffee.JPG", false, "Latte", 60000m },
                    { 6, "Cà phê ủ lạnh 12 giờ, vị đậm mượt mà không chua.", "https://upload.wikimedia.org/wikipedia/commons/4/45/A_small_cup_of_coffee.JPG", true, "Cold Brew", 65000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
