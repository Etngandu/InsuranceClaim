using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.InsuranceAndClaims.EF.Migrations
{
    public partial class outcome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48f68e3d-1de5-41f8-a0a2-e363d3e77474");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61bceec3-a15f-4e13-8af0-4e1f2868e530");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a930720-8e94-4382-88ad-ffa359eaaa49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cde034e6-68ad-4dc2-b5a6-0026c60da4fb");

            migrationBuilder.AddColumn<int>(
                name: "Stage_Outcome",
                table: "ClaimProcessing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23f4de02-1275-4d40-8afc-1d315ddc45e4", "f8c0aa8e-0f49-49c0-89f4-5e340212c15d", "Visitor", "VISITOR" },
                    { "6854b037-f94a-4df0-916e-c4cc91f11958", "3e35af9f-8419-4cac-942f-03d5ca40548f", "Administrator", "ADMINISTRATOR" },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23f4de02-1275-4d40-8afc-1d315ddc45e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6854b037-f94a-4df0-916e-c4cc91f11958");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79976b0c-84e3-46a7-9c84-058354154f4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea60f44b-3bf1-4f16-b858-df1c13c97da3");

            migrationBuilder.DropColumn(
                name: "Stage_Outcome",
                table: "ClaimProcessing");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48f68e3d-1de5-41f8-a0a2-e363d3e77474", "dc00d0e3-58bd-4c62-ae4c-c85ed0f8c26d", "Visitor", "VISITOR" },
                    { "cde034e6-68ad-4dc2-b5a6-0026c60da4fb", "c0ced14b-87b2-4bc2-b244-584ef3814822", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
