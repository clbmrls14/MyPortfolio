using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPortfolio.API.Migrations
{
    public partial class getProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechnologies_ProjectId",
                table: "ProjectTechnologies",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlatforms_ProjectId",
                table: "ProjectPlatforms",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPlatforms_Projects_ProjectId",
                table: "ProjectPlatforms",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTechnologies_Projects_ProjectId",
                table: "ProjectTechnologies",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPlatforms_Projects_ProjectId",
                table: "ProjectPlatforms");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTechnologies_Projects_ProjectId",
                table: "ProjectTechnologies");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTechnologies_ProjectId",
                table: "ProjectTechnologies");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPlatforms_ProjectId",
                table: "ProjectPlatforms");
        }
    }
}
