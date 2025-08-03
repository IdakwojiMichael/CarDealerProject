using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealerProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCarAndInquiryModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Inquiries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Inquiries");
        }
    }
}
