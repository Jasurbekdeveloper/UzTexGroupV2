using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UzTexGroupV2.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("08b9e0e9-cfe8-4445-9504-9439d028f568"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("4f0f288f-6f0b-415b-ae08-1ee81caf8574"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("f2ab55fb-16ee-4dac-bae5-71a91a35356a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("42799370-ac30-494a-a3fc-4ec9eaa390ee"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "News");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("14dd86e9-a6d1-4345-b07e-c0d785bb0093"), "uz", "Uzbek" },
                    { new Guid("1f7b2894-5460-47e2-9632-b452f5c20b79"), "en", "English" },
                    { new Guid("7c9a5183-0937-4757-9d41-e58e5b5d4fad"), "ru", "Russian" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "ExpiredRefreshToken", "FirstName", "LastName", "PasswordHash", "RefreshToken", "Salt", "UserRole" },
                values: new object[] { new Guid("26266427-7304-46d7-82ea-1ec13c9c7a59"), "elchinuralov07@gmail.com", null, "Elchin", "Uralov", "v7DrXBP/nQ3sHmWUgp6nkmBkJCeKxVK4+iljRqJfgDI=", null, "a9feaa2d-8692-4d2e-bf64-3d8200ad8c8b", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("14dd86e9-a6d1-4345-b07e-c0d785bb0093"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("1f7b2894-5460-47e2-9632-b452f5c20b79"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("7c9a5183-0937-4757-9d41-e58e5b5d4fad"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("26266427-7304-46d7-82ea-1ec13c9c7a59"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("08b9e0e9-cfe8-4445-9504-9439d028f568"), "uz", "Uzbek" },
                    { new Guid("4f0f288f-6f0b-415b-ae08-1ee81caf8574"), "ru", "Russian" },
                    { new Guid("f2ab55fb-16ee-4dac-bae5-71a91a35356a"), "en", "English" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "ExpiredRefreshToken", "FirstName", "LastName", "PasswordHash", "RefreshToken", "Salt", "UserRole" },
                values: new object[] { new Guid("42799370-ac30-494a-a3fc-4ec9eaa390ee"), "elchinuralov07@gmail.com", null, "Elchin", "Uralov", "v7DrXBP/nQ3sHmWUgp6nkmBkJCeKxVK4+iljRqJfgDI=", null, "a9feaa2d-8692-4d2e-bf64-3d8200ad8c8b", 1 });
        }
    }
}
