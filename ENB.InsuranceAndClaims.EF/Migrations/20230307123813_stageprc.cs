using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.InsuranceAndClaims.EF.Migrations
{
    public partial class stageprc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "ParentClaimStageId",
                table: "ClaimProcessingStage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a59d6f3-5bdb-4d50-ba5a-86a1bf99f84e", "6ac0e20e-664f-4851-96bd-465a27c37231", "Visitor", "VISITOR" },
                    { "251e2dd4-1802-44ef-a7d1-aee040b0b326", "ed24305f-8c73-4561-8983-99efe258ce49", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "ParentClaimStageId",
                table: "ClaimProcessingStage",
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
                    { "05021702-9952-4849-8092-69c4e1e5f4a0", "80c0c939-85cd-4a28-9d8f-4064b8cabf1d", "Visitor", "VISITOR" },
                    { "4e7bbef2-7160-4e09-95c6-69353f90807a", "f69c03ec-57d8-4aff-bec2-4238d13351de", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
