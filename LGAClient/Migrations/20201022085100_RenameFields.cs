using Microsoft.EntityFrameworkCore.Migrations;

namespace LGAClient.Migrations
{
    public partial class RenameFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelationshipType",
                table: "ClientCategories");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "ClientCategories",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ClientCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Owner" },
                    { 2, "CoOwner" },
                    { 3, "ThirdParty" }
                });

            migrationBuilder.InsertData(
                table: "ClientRelationshipTypes",
                columns: new[] { "Id", "RelationshipType" },
                values: new object[,]
                {
                    { 1, "Spouse" },
                    { 2, "Siblings" },
                    { 3, "Beneficiary" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClientCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClientRelationshipTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientRelationshipTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClientRelationshipTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "ClientCategories");

            migrationBuilder.AddColumn<string>(
                name: "RelationshipType",
                table: "ClientCategories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
