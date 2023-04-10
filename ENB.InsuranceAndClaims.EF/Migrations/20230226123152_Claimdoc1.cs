using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.InsuranceAndClaims.EF.Migrations
{
    public partial class Claimdoc1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ClaimDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimHeaderId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    Ref_Document_Type = table.Column<int>(type: "int", nullable: false),
                    Other_Details = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimDocument_ClaimHeader_ClaimHeaderId",
                        column: x => x.ClaimHeaderId,
                        principalTable: "ClaimHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimDocument_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0aa335d5-c5a7-4f90-9055-e5beb1fc1785", "8f983a5c-af4f-4448-a4dd-ab777ad1f246", "Visitor", "VISITOR" },
                    { "402eb33f-f516-42d5-87b3-974bd1eddb26", "24830e1f-7525-4f5c-8a7b-6362be74e4e1", "Administrator", "ADMINISTRATOR" },
                    
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDocument_ClaimHeaderId",
                table: "ClaimDocument",
                column: "ClaimHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDocument_StaffId",
                table: "ClaimDocument",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimDocument");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "307a1cf3-641f-4d02-a29c-82d9c14f0d02", "e07a6e4f-7eed-42d4-ab48-fa360c909b67", "Administrator", "ADMINISTRATOR" },
                    { "4ebe9d0b-3d9e-450d-a07f-145c9c997b8a", "571091cf-1895-472c-94d1-d15b5ddeca61", "Visitor", "VISITOR" },
                    { "7bf16fb4-289d-4288-825a-3e9818381616", "7afbc97b-d1ce-4410-bb7b-257dc1f1aba4", "Administrator", "ADMINISTRATOR" },
                    { "cef0c71c-6c1e-4072-b8fc-a9f2dc79d0a4", "c6dbd0e8-3b27-4c9e-b213-24bbdc37cd9d", "Visitor", "VISITOR" }
                });
        }
    }
}
