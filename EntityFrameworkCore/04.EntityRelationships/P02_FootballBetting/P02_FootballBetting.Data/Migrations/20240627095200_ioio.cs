using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P02_FootballBetting.Data.Migrations
{
    public partial class ioio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_PlayerStatistics_PlayerStatisticGameId_PlayerStatisticPlayerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerStatistics_PlayerStatisticGameId_PlayerStatisticPlayerId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerStatisticGameId_PlayerStatisticPlayerId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Games_PlayerStatisticGameId_PlayerStatisticPlayerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PlayerStatisticGameId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerStatisticPlayerId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerStatisticGameId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PlayerStatisticPlayerId",
                table: "Games");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerStatisticGameId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerStatisticPlayerId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerStatisticGameId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerStatisticPlayerId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerStatisticGameId_PlayerStatisticPlayerId",
                table: "Players",
                columns: new[] { "PlayerStatisticGameId", "PlayerStatisticPlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerStatisticGameId_PlayerStatisticPlayerId",
                table: "Games",
                columns: new[] { "PlayerStatisticGameId", "PlayerStatisticPlayerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_PlayerStatistics_PlayerStatisticGameId_PlayerStatisticPlayerId",
                table: "Games",
                columns: new[] { "PlayerStatisticGameId", "PlayerStatisticPlayerId" },
                principalTable: "PlayerStatistics",
                principalColumns: new[] { "GameId", "PlayerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerStatistics_PlayerStatisticGameId_PlayerStatisticPlayerId",
                table: "Players",
                columns: new[] { "PlayerStatisticGameId", "PlayerStatisticPlayerId" },
                principalTable: "PlayerStatistics",
                principalColumns: new[] { "GameId", "PlayerId" });
        }
    }
}
