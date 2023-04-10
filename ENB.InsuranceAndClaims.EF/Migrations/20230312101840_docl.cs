using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.InsuranceAndClaims.EF.Migrations
{
    public partial class docl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimDocument_ClaimHeader_ClaimHeaderId",
                table: "ClaimDocument");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a59d6f3-5bdb-4d50-ba5a-86a1bf99f84e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "251e2dd4-1802-44ef-a7d1-aee040b0b326");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d12cb331-abe9-4782-9b29-abb9c726cc8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e339acb6-9d2b-4b21-892a-62e8c1d5f978");

            migrationBuilder.AlterColumn<int>(
                name: "ClaimHeaderId",
                table: "ClaimDocument",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "ClaimDocument",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PolicyId",
                table: "ClaimDocument",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1841cf6b-e4f8-4e7c-b669-f60512bfd14e", "dd0c1f62-c1dd-462e-b840-91247548ffa5", "Administrator", "ADMINISTRATOR" },
                    { "a3218da5-a903-4d69-904d-e682690e8e33", "a63a44bb-64df-422a-b70a-3cc645829fb3", "Visitor", "VISITOR" },
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDocument_CustomerId",
                table: "ClaimDocument",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDocument_PolicyId",
                table: "ClaimDocument",
                column: "PolicyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimDocument_ClaimHeader_ClaimHeaderId",
                table: "ClaimDocument",
                column: "ClaimHeaderId",
                principalTable: "ClaimHeader",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimDocument_Customers_CustomerId",
                table: "ClaimDocument",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimDocument_Policy_PolicyId",
                table: "ClaimDocument",
                column: "PolicyId",
                principalTable: "Policy",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimDocument_ClaimHeader_ClaimHeaderId",
                table: "ClaimDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimDocument_Customers_CustomerId",
                table: "ClaimDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimDocument_Policy_PolicyId",
                table: "ClaimDocument");

            migrationBuilder.DropIndex(
                name: "IX_ClaimDocument_CustomerId",
                table: "ClaimDocument");

            migrationBuilder.DropIndex(
                name: "IX_ClaimDocument_PolicyId",
                table: "ClaimDocument");

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

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ClaimDocument");

            migrationBuilder.DropColumn(
                name: "PolicyId",
                table: "ClaimDocument");

            migrationBuilder.AlterColumn<int>(
                name: "ClaimHeaderId",
                table: "ClaimDocument",
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
                    { "0a59d6f3-5bdb-4d50-ba5a-86a1bf99f84e", "6ac0e20e-664f-4851-96bd-465a27c37231", "Visitor", "VISITOR" },
                    { "251e2dd4-1802-44ef-a7d1-aee040b0b326", "ed24305f-8c73-4561-8983-99efe258ce49", "Administrator", "ADMINISTRATOR" },
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimDocument_ClaimHeader_ClaimHeaderId",
                table: "ClaimDocument",
                column: "ClaimHeaderId",
                principalTable: "ClaimHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
