using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthSystem.Migrations
{
    /// <inheritdoc />
    public partial class relationshipdefination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Information",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Information_UserId",
                table: "Information",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Information_AspNetUsers_UserId",
                table: "Information",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Information_AspNetUsers_UserId",
                table: "Information");

            migrationBuilder.DropIndex(
                name: "IX_Information_UserId",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Information");
        }
    }
}
