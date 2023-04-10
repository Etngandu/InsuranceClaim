using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.InsuranceAndClaims.EF.Migrations
{
    public partial class clh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimHeader_Policy_PolicyId",
                table: "ClaimHeader");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0aa335d5-c5a7-4f90-9055-e5beb1fc1785");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "402eb33f-f516-42d5-87b3-974bd1eddb26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b92bca48-13fc-4fa5-8ae0-277b3587775c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2107fef-9035-46f1-8e62-963b28d3ce98");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "ClaimHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50bf1027-a074-4268-b8c2-ad18dd4c5143", "3aa8f7ca-47d2-428c-8142-3c50fdb9585d", "Administrator", "ADMINISTRATOR" },
                    { "6112afe9-157f-45c1-8b9d-ef68e5f75ff6", "25748639-cda8-4814-98c7-caa69a293077", "Visitor", "VISITOR" },
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimHeader_CustomerId",
                table: "ClaimHeader",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimHeader_Customers_CustomerId",
                table: "ClaimHeader",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimHeader_Policy_PolicyId",
                table: "ClaimHeader",
                column: "PolicyId",
                principalTable: "Policy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimHeader_Customers_CustomerId",
                table: "ClaimHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimHeader_Policy_PolicyId",
                table: "ClaimHeader");

            migrationBuilder.DropIndex(
                name: "IX_ClaimHeader_CustomerId",
                table: "ClaimHeader");

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

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ClaimHeader");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0aa335d5-c5a7-4f90-9055-e5beb1fc1785", "8f983a5c-af4f-4448-a4dd-ab777ad1f246", "Visitor", "VISITOR" },
                    { "402eb33f-f516-42d5-87b3-974bd1eddb26", "24830e1f-7525-4f5c-8a7b-6362be74e4e1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimHeader_Policy_PolicyId",
                table: "ClaimHeader",
                column: "PolicyId",
                principalTable: "Policy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
