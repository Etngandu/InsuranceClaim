using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.InsuranceAndClaims.EF.Migrations
{
    public partial class claimprcss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50bf1027-a074-4268-b8c2-ad18dd4c5143");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6112afe9-157f-45c1-8b9d-ef68e5f75ff6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88c68830-d4ee-495f-8526-097f3db230e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbe0ca1a-85e7-4874-9428-30da5c4da1d0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05021702-9952-4849-8092-69c4e1e5f4a0", "80c0c939-85cd-4a28-9d8f-4064b8cabf1d", "Visitor", "VISITOR" },
                    { "4e7bbef2-7160-4e09-95c6-69353f90807a", "f69c03ec-57d8-4aff-bec2-4238d13351de", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05021702-9952-4849-8092-69c4e1e5f4a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e7bbef2-7160-4e09-95c6-69353f90807a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d570dab-f609-49e4-a74b-7d95045a5a6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be8e673e-03fa-4577-91c1-3d4acf88bd5d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50bf1027-a074-4268-b8c2-ad18dd4c5143", "3aa8f7ca-47d2-428c-8142-3c50fdb9585d", "Administrator", "ADMINISTRATOR" },
                    { "6112afe9-157f-45c1-8b9d-ef68e5f75ff6", "25748639-cda8-4814-98c7-caa69a293077", "Visitor", "VISITOR" },
                });
        }
    }
}
