using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "IdentificationType",
                table: "Users",
                newName: "TypeIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TypeIdentificationId",
                table: "Users",
                column: "TypeIdentificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TypeIdentifications_TypeIdentificationId",
                table: "Users",
                column: "TypeIdentificationId",
                principalTable: "TypeIdentifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_TypeIdentifications_TypeIdentificationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TypeIdentificationId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "TypeIdentificationId",
                table: "Users",
                newName: "IdentificationType");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
