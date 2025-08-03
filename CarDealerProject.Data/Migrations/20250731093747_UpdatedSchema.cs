using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealerProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_CarId",
                table: "Inquiries",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiries_Cars_CarId",
                table: "Inquiries",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inquiries_Cars_CarId",
                table: "Inquiries");

            migrationBuilder.DropIndex(
                name: "IX_Inquiries_CarId",
                table: "Inquiries");
        }
    }
}
