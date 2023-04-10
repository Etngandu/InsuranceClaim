using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.InsuranceAndClaims.EF.Migrations
{
    public partial class ClaimDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03908e41-079b-4978-a13b-11b16f39ceea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6be9eb70-98bc-445b-a02c-c119a093ba02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80850b3e-81c6-4a25-b806-1ffc50227a83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7689320-1f09-4ee3-86b4-393c6a282100");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "307a1cf3-641f-4d02-a29c-82d9c14f0d02", "e07a6e4f-7eed-42d4-ab48-fa360c909b67", "Administrator", "ADMINISTRATOR" },                    
                    { "cef0c71c-6c1e-4072-b8fc-a9f2dc79d0a4", "c6dbd0e8-3b27-4c9e-b213-24bbdc37cd9d", "Visitor", "VISITOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "307a1cf3-641f-4d02-a29c-82d9c14f0d02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ebe9d0b-3d9e-450d-a07f-145c9c997b8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bf16fb4-289d-4288-825a-3e9818381616");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cef0c71c-6c1e-4072-b8fc-a9f2dc79d0a4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03908e41-079b-4978-a13b-11b16f39ceea", "087c852a-6815-4d9c-9987-29f768c67bf7", "Visitor", "VISITOR" },                    
                    { "b7689320-1f09-4ee3-86b4-393c6a282100", "124a1fca-eb74-44e3-9dda-5936b51d6544", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
