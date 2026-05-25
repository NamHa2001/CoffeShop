using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeShop.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Detail", "ImageUrl" },
                values: new object[] { "A bold and rich espresso-based coffee...", "/assets/images/mohammad-amirahmadi-tk2ifgn60xo-unsplash-815x1019.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Detail", "ImageUrl" },
                values: new object[] { "Vietnamese coffee is known for its intense flavor...", "/assets/images/nathan-dumlao-nbjho6wmrww-unsplash-815x1223.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Detail", "ImageUrl" },
                values: new object[] { "A classic British-style coffee blend...", "/assets/images/anna-bratiychuk-3w2aurzeesu-unsplash-815x1223.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Detail", "ImageUrl" },
                values: new object[] { "Indian filter coffee is a traditional South Indian beverage...", "/assets/images/jeremy-yap-jn-hagwe4yw-unsplash-815x1223.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Detail", "ImageUrl" },
                values: new object[] { "A unique coffee blend inspired by Russian traditions...", "/assets/images/tetiana-shyshkina-4lqjr8gu-bg-unsplash-815x1222.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Detail", "ImageUrl" },
                values: new object[] { "French roast coffee is characterized by its dark, smoky flavor...", "/assets/images/giancarlo-duarte-rthw0pwclhw-unsplash-815x543.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Detail", "ImageUrl" },
                values: new object[] { "Name product", "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Detail", "ImageUrl" },
                values: new object[] { "Vietnamese product", "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Detail", "ImageUrl" },
                values: new object[] { "UK product", "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Detail", "ImageUrl" },
                values: new object[] { "India product", "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Detail", "ImageUrl" },
                values: new object[] { "Russian product", "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Detail", "ImageUrl" },
                values: new object[] { "France product", "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp" });
        }
    }
}
