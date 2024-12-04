using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CanineConnect.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_631 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shelter_UserId",
                table: "Shelter");

            migrationBuilder.CreateIndex(
                name: "IX_Shelter_UserId",
                table: "Shelter",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shelter_UserId",
                table: "Shelter");

            migrationBuilder.CreateIndex(
                name: "IX_Shelter_UserId",
                table: "Shelter",
                column: "UserId");
        }
    }
}
