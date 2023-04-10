using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.InsuranceAndClaims.EF.Migrations
{
    public partial class clmprsc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimProcessing_ClaimHeader_ClaimHeaderId",
                table: "ClaimProcessing");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1841cf6b-e4f8-4e7c-b669-f60512bfd14e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3218da5-a903-4d69-904d-e682690e8e33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1a21d02-a2c9-44c4-8b6c-7292f6584764");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f25bf814-8954-4f95-a3f8-64722c61593e");

            migrationBuilder.AlterColumn<int>(
                name: "ClaimHeaderId",
                table: "ClaimProcessing",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "ClaimProcessing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PolicyId",
                table: "ClaimProcessing",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48f68e3d-1de5-41f8-a0a2-e363d3e77474", "dc00d0e3-58bd-4c62-ae4c-c85ed0f8c26d", "Visitor", "VISITOR" },
                    { "cde034e6-68ad-4dc2-b5a6-0026c60da4fb", "c0ced14b-87b2-4bc2-b244-584ef3814822", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimProcessing_CustomerId",
                table: "ClaimProcessing",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimProcessing_PolicyId",
                table: "ClaimProcessing",
                column: "PolicyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimProcessing_ClaimHeader_ClaimHeaderId",
                table: "ClaimProcessing",
                column: "ClaimHeaderId",
                principalTable: "ClaimHeader",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimProcessing_Customers_CustomerId",
                table: "ClaimProcessing",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimProcessing_Policy_PolicyId",
                table: "ClaimProcessing",
                column: "PolicyId",
                principalTable: "Policy",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimProcessing_ClaimHeader_ClaimHeaderId",
                table: "ClaimProcessing");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimProcessing_Customers_CustomerId",
                table: "ClaimProcessing");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimProcessing_Policy_PolicyId",
                table: "ClaimProcessing");

            migrationBuilder.DropIndex(
                name: "IX_ClaimProcessing_CustomerId",
                table: "ClaimProcessing");

            migrationBuilder.DropIndex(
                name: "IX_ClaimProcessing_PolicyId",
                table: "ClaimProcessing");

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

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ClaimProcessing");

            migrationBuilder.DropColumn(
                name: "PolicyId",
                table: "ClaimProcessing");

            migrationBuilder.AlterColumn<int>(
                name: "ClaimHeaderId",
                table: "ClaimProcessing",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1841cf6b-e4f8-4e7c-b669-f60512bfd14e", "dd0c1f62-c1dd-462e-b840-91247548ffa5", "Administrator", "ADMINISTRATOR" },
                    { "a3218da5-a903-4d69-904d-e682690e8e33", "a63a44bb-64df-422a-b70a-3cc645829fb3", "Visitor", "VISITOR" },
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimProcessing_ClaimHeader_ClaimHeaderId",
                table: "ClaimProcessing",
                column: "ClaimHeaderId",
                principalTable: "ClaimHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
