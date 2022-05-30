using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Auther",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Auther_CountryId",
                table: "Auther",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auther_Country_CountryId",
                table: "Auther",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auther_Country_CountryId",
                table: "Auther");

            migrationBuilder.DropIndex(
                name: "IX_Auther_CountryId",
                table: "Auther");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Auther");
        }
    }
}
