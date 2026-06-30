using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JobJobCategory",
                keyColumns: new[] { "CategoriesId", "JobsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "JobJobCategory",
                keyColumns: new[] { "CategoriesId", "JobsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "JobJobCategory",
                keyColumns: new[] { "CategoriesId", "JobsId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "graduate@test.com", "Test Graduate", "", "graduate" },
                    { 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "employer@test.com", "Test Employer", "", "employer" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Color", "CompanyId", "CreatedAt", "Description", "Location", "LocationType", "Salary", "Skills", "Title" },
                values: new object[,]
                {
                    { 1, "#4F46E5", 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "We are looking for a skilled Full Stack Developer to join our team...", "Riyadh", "عن بعد", 8000m, null, "Full Stack Developer" },
                    { 2, "#7C3AED", 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Join our creative team as a UI/UX Designer...", "Jeddah", "في الموقع", 7000m, null, "UI/UX Designer" },
                    { 3, "#EC4899", 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Seeking a Marketing Specialist to join our team...", "Dammam", "عن بعد", 6000m, null, "Marketing Specialist" }
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
        }
    }
}
