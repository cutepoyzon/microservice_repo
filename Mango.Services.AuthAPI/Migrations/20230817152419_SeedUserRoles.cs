using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mango.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "89487ac5-28eb-4d3d-afe1-429fe32f582c", null, "ApplicationRole", "CUSTOMER", null },
                    { "d08f86fc-a412-4753-914c-f75ab58e5aea", null, "ApplicationRole", "ADMIN", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "89487ac5-28eb-4d3d-afe1-429fe32f5822", 0, "3d109f00-5269-46a7-9a57-fa94e114911d", "testcustomer@gmail.com", false, false, null, "Aaron Vikes", "TESTCUSTOMER@GMAIL.COM", "TESTCUSTOMER@GMAIL.COM", "AQAAAAIAAYagAAAAEMv/5ff3qJaYH+T03ukkrjq2Rkqwf78PkJD3LJWNWrZDmqkmwPHX6abzS8cdROw6qQ==", "0544852149", false, "77056af6-cc05-4e95-bb71-869531fe7a76", false, "testcustomer@gmail.com" },
                    { "d08f86fc-a412-4753-914c-f75ab58e5aec", 0, "14549151-6a9c-4829-b9ab-0f2704ba3094", "testadmin@gmail.com", false, false, null, "Ian Vixen", "TESTADMIN@GMAIL.COM", "TESTADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEMv/5ff3qJaYH+T03ukkrjq2Rkqwf78PkJD3LJWNWrZDmqkmwPHX6abzS8cdROw6qQ==", "0554852149", false, "7351ee73-c9c4-4a36-a7be-1310b3235bf9", false, "testadmin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { "89487ac5-28eb-4d3d-afe1-429fe32f582c", "89487ac5-28eb-4d3d-afe1-429fe32f5822", "ApplicationUserRole" },
                    { "d08f86fc-a412-4753-914c-f75ab58e5aea", "d08f86fc-a412-4753-914c-f75ab58e5aec", "ApplicationUserRole" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "89487ac5-28eb-4d3d-afe1-429fe32f582c", "89487ac5-28eb-4d3d-afe1-429fe32f5822" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d08f86fc-a412-4753-914c-f75ab58e5aea", "d08f86fc-a412-4753-914c-f75ab58e5aec" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89487ac5-28eb-4d3d-afe1-429fe32f582c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d08f86fc-a412-4753-914c-f75ab58e5aea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89487ac5-28eb-4d3d-afe1-429fe32f5822");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d08f86fc-a412-4753-914c-f75ab58e5aec");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

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
    }
}
