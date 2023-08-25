using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mango.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89487ac5-28eb-4d3d-afe1-429fe32f5822");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d08f86fc-a412-4753-914c-f75ab58e5aec");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a57ff9a-9377-4358-b937-8cb7060e5c3d", null, "ApplicationRole", "CUSTOMER", null },
                    { "68e773c2-1d0f-4cd9-a615-8adad20a5cf2", null, "ApplicationRole", "ADMIN", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e1203e0c-891d-4a0b-99ef-a6d8cfce9707", 0, "14da4541-3814-4589-875d-e4bceec4c00a", "testadmin@gmail.com", false, false, null, "Ian Vixen", "TESTADMIN@GMAIL.COM", "TESTADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEMv/5ff3qJaYH+T03ukkrjq2Rkqwf78PkJD3LJWNWrZDmqkmwPHX6abzS8cdROw6qQ==", "0554852149", false, "35e3d6eb-a09a-4cd6-90a1-db9eb55210d0", false, "testadmin@gmail.com" },
                    { "f4faa027-de0b-45fe-b5bf-baa216f7f249", 0, "49711daf-d619-428c-ac2d-6179b455ea67", "testcustomer@gmail.com", false, false, null, "Aaron Vikes", "TESTCUSTOMER@GMAIL.COM", "TESTCUSTOMER@GMAIL.COM", "AQAAAAIAAYagAAAAEMv/5ff3qJaYH+T03ukkrjq2Rkqwf78PkJD3LJWNWrZDmqkmwPHX6abzS8cdROw6qQ==", "0544852149", false, "cbde1b40-0449-407c-a16e-80152811879e", false, "testcustomer@gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a57ff9a-9377-4358-b937-8cb7060e5c3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68e773c2-1d0f-4cd9-a615-8adad20a5cf2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1203e0c-891d-4a0b-99ef-a6d8cfce9707");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f4faa027-de0b-45fe-b5bf-baa216f7f249");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "89487ac5-28eb-4d3d-afe1-429fe32f5822", 0, "92c76218-0487-417d-88b6-7a90678f3a9f", "testcustomer@gmail.com", false, false, null, "Aaron Vikes", "TESTCUSTOMER@GMAIL.COM", "TESTCUSTOMER@GMAIL.COM", "AQAAAAIAAYagAAAAEMv/5ff3qJaYH+T03ukkrjq2Rkqwf78PkJD3LJWNWrZDmqkmwPHX6abzS8cdROw6qQ==", "0544852149", false, "ba0a3ae7-a645-4f6a-8325-fbdcad0a4611", false, "testcustomer@gmail.com" },
                    { "d08f86fc-a412-4753-914c-f75ab58e5aec", 0, "0df50608-ec02-4468-a19f-2ead5cb222aa", "testadmin@gmail.com", false, false, null, "Ian Vixen", "TESTADMIN@GMAIL.COM", "TESTADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEMv/5ff3qJaYH+T03ukkrjq2Rkqwf78PkJD3LJWNWrZDmqkmwPHX6abzS8cdROw6qQ==", "0554852149", false, "b54546dc-bb18-4ddd-bf62-2a68388ae479", false, "testadmin@gmail.com" }
                });
        }
    }
}
