using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mango.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "89487ac5-28eb-4d3d-afe1-429fe32f5822", 0, "92c76218-0487-417d-88b6-7a90678f3a9f", "testcustomer@gmail.com", false, false, null, "Aaron Vikes", "TESTCUSTOMER@GMAIL.COM", "TESTCUSTOMER@GMAIL.COM", "AQAAAAIAAYagAAAAEMv/5ff3qJaYH+T03ukkrjq2Rkqwf78PkJD3LJWNWrZDmqkmwPHX6abzS8cdROw6qQ==", "0544852149", false, "ba0a3ae7-a645-4f6a-8325-fbdcad0a4611", false, "testcustomer@gmail.com" },
                    { "d08f86fc-a412-4753-914c-f75ab58e5aec", 0, "0df50608-ec02-4468-a19f-2ead5cb222aa", "testadmin@gmail.com", false, false, null, "Ian Vixen", "TESTADMIN@GMAIL.COM", "TESTADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEMv/5ff3qJaYH+T03ukkrjq2Rkqwf78PkJD3LJWNWrZDmqkmwPHX6abzS8cdROw6qQ==", "0554852149", false, "b54546dc-bb18-4ddd-bf62-2a68388ae479", false, "testadmin@gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89487ac5-28eb-4d3d-afe1-429fe32f5822");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d08f86fc-a412-4753-914c-f75ab58e5aec");
        }
    }
}
