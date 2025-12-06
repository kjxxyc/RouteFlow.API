using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeIdeas.RouteFlow.API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixDetTypeUserRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USR_DetTypeUser_USR_TypeUser_IdTypeUser",
                schema: "ONE",
                table: "USR_DetTypeUser");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_DetTypeUser_USR_User_UserNavigationUser",
                schema: "ONE",
                table: "USR_DetTypeUser");

            migrationBuilder.DropIndex(
                name: "IX_USR_DetTypeUser_UserNavigationUser",
                schema: "ONE",
                table: "USR_DetTypeUser");

            migrationBuilder.DropColumn(
                name: "UserNavigationUser",
                schema: "ONE",
                table: "USR_DetTypeUser");

            migrationBuilder.AddForeignKey(
                name: "FK_USR_DetTypeUser_USR_TypeUser_IdTypeUser",
                schema: "ONE",
                table: "USR_DetTypeUser",
                column: "IdTypeUser",
                principalSchema: "ONE",
                principalTable: "USR_TypeUser",
                principalColumn: "IdTypeUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USR_DetTypeUser_USR_TypeUser_IdTypeUser",
                schema: "ONE",
                table: "USR_DetTypeUser");

            migrationBuilder.AddColumn<string>(
                name: "UserNavigationUser",
                schema: "ONE",
                table: "USR_DetTypeUser",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_USR_DetTypeUser_UserNavigationUser",
                schema: "ONE",
                table: "USR_DetTypeUser",
                column: "UserNavigationUser");

            migrationBuilder.AddForeignKey(
                name: "FK_USR_DetTypeUser_USR_TypeUser_IdTypeUser",
                schema: "ONE",
                table: "USR_DetTypeUser",
                column: "IdTypeUser",
                principalSchema: "ONE",
                principalTable: "USR_TypeUser",
                principalColumn: "IdTypeUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USR_DetTypeUser_USR_User_UserNavigationUser",
                schema: "ONE",
                table: "USR_DetTypeUser",
                column: "UserNavigationUser",
                principalSchema: "ONE",
                principalTable: "USR_User",
                principalColumn: "User",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
