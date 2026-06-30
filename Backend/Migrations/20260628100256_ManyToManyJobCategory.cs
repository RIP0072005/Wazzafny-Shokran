using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyJobCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobCategories_CategoryId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Jobs");

            migrationBuilder.CreateTable(
                name: "JobJobCategory",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    JobsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobJobCategory", x => new { x.CategoriesId, x.JobsId });
                    table.ForeignKey(
                        name: "FK_JobJobCategory_JobCategories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "JobCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobJobCategory_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "JobJobCategory",
                columns: new[] { "CategoriesId", "JobsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 3 },
                    { 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobJobCategory_JobsId",
                table: "JobJobCategory",
                column: "JobsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobJobCategory");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobCategories_CategoryId",
                table: "Jobs",
                column: "CategoryId",
                principalTable: "JobCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
