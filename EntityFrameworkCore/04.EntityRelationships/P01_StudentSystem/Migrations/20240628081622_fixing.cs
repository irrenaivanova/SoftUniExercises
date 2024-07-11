using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P01_StudentSystem.Data.Migrations
{
    public partial class fixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Resources",
                type: "char(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(10)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Resources",
                type: "char(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(max)");
        }
    }
}
