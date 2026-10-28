using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerieA.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_update_property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchCards_Teams_TeamId",
                table: "MatchCards");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchGoals_Teams_TeamId",
                table: "MatchGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchSubstitutions_Teams_TeamId",
                table: "MatchSubstitutions");

            migrationBuilder.DropIndex(
                name: "IX_MatchSubstitutions_TeamId",
                table: "MatchSubstitutions");

            migrationBuilder.DropIndex(
                name: "IX_MatchGoals_TeamId",
                table: "MatchGoals");

            migrationBuilder.DropIndex(
                name: "IX_MatchCards_TeamId",
                table: "MatchCards");

            migrationBuilder.AlterColumn<string>(
                name: "LogoUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "MatchStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LiveMinute",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatistics_MatchId",
                table: "MatchStatistics",
                column: "MatchId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchStatistics_Matches_MatchId",
                table: "MatchStatistics",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchStatistics_Matches_MatchId",
                table: "MatchStatistics");

            migrationBuilder.DropIndex(
                name: "IX_MatchStatistics_MatchId",
                table: "MatchStatistics");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "MatchStatistics");

            migrationBuilder.AlterColumn<string>(
                name: "LogoUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LiveMinute",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchSubstitutions_TeamId",
                table: "MatchSubstitutions",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGoals_TeamId",
                table: "MatchGoals",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchCards_TeamId",
                table: "MatchCards",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchCards_Teams_TeamId",
                table: "MatchCards",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchGoals_Teams_TeamId",
                table: "MatchGoals",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchSubstitutions_Teams_TeamId",
                table: "MatchSubstitutions",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
