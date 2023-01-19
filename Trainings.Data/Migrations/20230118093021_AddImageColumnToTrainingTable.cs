using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trainings.Data.Migrations
{
    public partial class AddImageColumnToTrainingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Trainings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Trainings");
        }
    }
}
