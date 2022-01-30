using Microsoft.EntityFrameworkCore.Migrations;

namespace bArt_Test_task.Migrations
{
    public partial class Adding1toMForIncidentAndAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IncidentId",
                table: "Account",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_IncidentId",
                table: "Account",
                column: "IncidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Incident_IncidentId",
                table: "Account",
                column: "IncidentId",
                principalTable: "Incident",
                principalColumn: "IncidentName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Incident_IncidentId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_IncidentId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "IncidentId",
                table: "Account");
        }
    }
}
