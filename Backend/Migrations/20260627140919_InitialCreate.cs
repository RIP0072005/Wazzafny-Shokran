using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_JobCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "JobCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Color", "CreatedAt", "Description", "Industry", "Location", "Logo", "Name" },
                values: new object[,]
                {
                    { 1, "#4F46E5", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Leading tech company specializing in software solutions.", "Technology", "Riyadh", null, "R2 Tech Solutions" },
                    { 2, "#7C3AED", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Creative agency for branding and design.", "Design", "Jeddah", null, "Creative Lab" },
                    { 3, "#EC4899", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Digital marketing and advertising agency.", "Marketing", "Dammam", null, "Digital Way" },
                    { 4, "#10B981", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Financial technology and innovation hub.", "Finance", "Riyadh", null, "FinTech Hub" }
                });

            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, "Programming", "برمجة" },
                    { 2, "Marketing", "تسويق" },
                    { 3, "Design", "تصميم" },
                    { 4, "Accounting", "محاسبة" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "Color", "CompanyId", "CreatedAt", "Description", "Location", "LocationType", "Salary", "Skills", "Title" },
                values: new object[,]
                {
                    { 1, 1, "#4F46E5", 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "We are looking for a skilled Full Stack Developer to join our team...", "Riyadh", "عن بعد", 8000m, null, "Full Stack Developer" },
                    { 2, 3, "#7C3AED", 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Join our creative team as a UI/UX Designer...", "Jeddah", "في الموقع", 7000m, null, "UI/UX Designer" },
                    { 3, 2, "#EC4899", 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Seeking a Marketing Specialist to join our team...", "Dammam", "عن بعد", 6000m, null, "Marketing Specialist" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "JobCategories");
        }
    }
}
