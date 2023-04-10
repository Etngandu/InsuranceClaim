using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.InsuranceAndClaims.EF.Migrations
{
    public partial class Modifcust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6608b7ee-3240-48fd-a0d9-4ac98bf06235");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c21cd593-5a64-4275-bfe2-37f3787bf6dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c41e95c9-afc8-403e-b3a4-e12deda0140e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d44a71ef-eb6b-45a1-9d1a-db5e9111fc9f");

            migrationBuilder.DropColumn(
                name: "Card_expiry_date",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Credit_card_Number",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03908e41-079b-4978-a13b-11b16f39ceea", "087c852a-6815-4d9c-9987-29f768c67bf7", "Visitor", "VISITOR" },                  
                    { "b7689320-1f09-4ee3-86b4-393c6a282100", "124a1fca-eb74-44e3-9dda-5936b51d6544", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Card_expiry_date",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Credit_card_Number",
                table: "Customers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6608b7ee-3240-48fd-a0d9-4ac98bf06235", "d02854b6-bb53-4196-8558-9871241fe31a", "Administrator", "ADMINISTRATOR" },
                    { "c21cd593-5a64-4275-bfe2-37f3787bf6dc", "85076e98-45dd-4aca-8c54-7452524bfa0a", "Visitor", "VISITOR" }
                });
        }
    }
}
