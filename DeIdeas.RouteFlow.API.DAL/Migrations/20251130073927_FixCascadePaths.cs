using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeIdeas.RouteFlow.API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadePaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USR_ControlRol_USR_Control_IdControl",
                schema: "ONE",
                table: "USR_ControlRol");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_DetTypeUser_USR_User_User",
                schema: "ONE",
                table: "USR_DetTypeUser");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_User_USR_TypeUser_IdTypeUser",
                schema: "ONE",
                table: "USR_User");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_UserRol_USR_Rol_Rol",
                schema: "ONE",
                table: "USR_UserRol");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_UserRol_USR_User_User",
                schema: "ONE",
                table: "USR_UserRol");

            migrationBuilder.AddColumn<string>(
                name: "RolNavigationRol",
                schema: "ONE",
                table: "USR_UserRol",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserNavigationUser",
                schema: "ONE",
                table: "USR_UserRol",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "USR_TypeUserIdTypeUser",
                schema: "ONE",
                table: "USR_User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNavigationUser",
                schema: "ONE",
                table: "USR_DetTypeUser",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ControlIdControl",
                schema: "ONE",
                table: "USR_ControlRol",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_USR_UserRol_RolNavigationRol",
                schema: "ONE",
                table: "USR_UserRol",
                column: "RolNavigationRol");

            migrationBuilder.CreateIndex(
                name: "IX_USR_UserRol_UserNavigationUser",
                schema: "ONE",
                table: "USR_UserRol",
                column: "UserNavigationUser");

            migrationBuilder.CreateIndex(
                name: "IX_USR_User_USR_TypeUserIdTypeUser",
                schema: "ONE",
                table: "USR_User",
                column: "USR_TypeUserIdTypeUser");

            migrationBuilder.CreateIndex(
                name: "IX_USR_DetTypeUser_UserNavigationUser",
                schema: "ONE",
                table: "USR_DetTypeUser",
                column: "UserNavigationUser");

            migrationBuilder.CreateIndex(
                name: "IX_USR_ControlRol_ControlIdControl",
                schema: "ONE",
                table: "USR_ControlRol",
                column: "ControlIdControl");

            migrationBuilder.AddForeignKey(
                name: "FK_USR_ControlRol_USR_Control_ControlIdControl",
                schema: "ONE",
                table: "USR_ControlRol",
                column: "ControlIdControl",
                principalSchema: "ONE",
                principalTable: "USR_Control",
                principalColumn: "IdControl",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USR_ControlRol_USR_Control_IdControl",
                schema: "ONE",
                table: "USR_ControlRol",
                column: "IdControl",
                principalSchema: "ONE",
                principalTable: "USR_Control",
                principalColumn: "IdControl");

            migrationBuilder.AddForeignKey(
                name: "FK_USR_DetTypeUser_USR_User_User",
                schema: "ONE",
                table: "USR_DetTypeUser",
                column: "User",
                principalSchema: "ONE",
                principalTable: "USR_User",
                principalColumn: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_USR_DetTypeUser_USR_User_UserNavigationUser",
                schema: "ONE",
                table: "USR_DetTypeUser",
                column: "UserNavigationUser",
                principalSchema: "ONE",
                principalTable: "USR_User",
                principalColumn: "User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USR_User_USR_TypeUser_IdTypeUser",
                schema: "ONE",
                table: "USR_User",
                column: "IdTypeUser",
                principalSchema: "ONE",
                principalTable: "USR_TypeUser",
                principalColumn: "IdTypeUser");

            migrationBuilder.AddForeignKey(
                name: "FK_USR_User_USR_TypeUser_USR_TypeUserIdTypeUser",
                schema: "ONE",
                table: "USR_User",
                column: "USR_TypeUserIdTypeUser",
                principalSchema: "ONE",
                principalTable: "USR_TypeUser",
                principalColumn: "IdTypeUser");

            migrationBuilder.AddForeignKey(
                name: "FK_USR_UserRol_USR_Rol_Rol",
                schema: "ONE",
                table: "USR_UserRol",
                column: "Rol",
                principalSchema: "ONE",
                principalTable: "USR_Rol",
                principalColumn: "Rol");

            migrationBuilder.AddForeignKey(
                name: "FK_USR_UserRol_USR_Rol_RolNavigationRol",
                schema: "ONE",
                table: "USR_UserRol",
                column: "RolNavigationRol",
                principalSchema: "ONE",
                principalTable: "USR_Rol",
                principalColumn: "Rol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USR_UserRol_USR_User_User",
                schema: "ONE",
                table: "USR_UserRol",
                column: "User",
                principalSchema: "ONE",
                principalTable: "USR_User",
                principalColumn: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_USR_UserRol_USR_User_UserNavigationUser",
                schema: "ONE",
                table: "USR_UserRol",
                column: "UserNavigationUser",
                principalSchema: "ONE",
                principalTable: "USR_User",
                principalColumn: "User",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USR_ControlRol_USR_Control_ControlIdControl",
                schema: "ONE",
                table: "USR_ControlRol");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_ControlRol_USR_Control_IdControl",
                schema: "ONE",
                table: "USR_ControlRol");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_DetTypeUser_USR_User_User",
                schema: "ONE",
                table: "USR_DetTypeUser");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_DetTypeUser_USR_User_UserNavigationUser",
                schema: "ONE",
                table: "USR_DetTypeUser");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_User_USR_TypeUser_IdTypeUser",
                schema: "ONE",
                table: "USR_User");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_User_USR_TypeUser_USR_TypeUserIdTypeUser",
                schema: "ONE",
                table: "USR_User");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_UserRol_USR_Rol_Rol",
                schema: "ONE",
                table: "USR_UserRol");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_UserRol_USR_Rol_RolNavigationRol",
                schema: "ONE",
                table: "USR_UserRol");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_UserRol_USR_User_User",
                schema: "ONE",
                table: "USR_UserRol");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_UserRol_USR_User_UserNavigationUser",
                schema: "ONE",
                table: "USR_UserRol");

            migrationBuilder.DropIndex(
                name: "IX_USR_UserRol_RolNavigationRol",
                schema: "ONE",
                table: "USR_UserRol");

            migrationBuilder.DropIndex(
                name: "IX_USR_UserRol_UserNavigationUser",
                schema: "ONE",
                table: "USR_UserRol");

            migrationBuilder.DropIndex(
                name: "IX_USR_User_USR_TypeUserIdTypeUser",
                schema: "ONE",
                table: "USR_User");

            migrationBuilder.DropIndex(
                name: "IX_USR_DetTypeUser_UserNavigationUser",
                schema: "ONE",
                table: "USR_DetTypeUser");

            migrationBuilder.DropIndex(
                name: "IX_USR_ControlRol_ControlIdControl",
                schema: "ONE",
                table: "USR_ControlRol");

            migrationBuilder.DropColumn(
                name: "RolNavigationRol",
                schema: "ONE",
                table: "USR_UserRol");

            migrationBuilder.DropColumn(
                name: "UserNavigationUser",
                schema: "ONE",
                table: "USR_UserRol");

            migrationBuilder.DropColumn(
                name: "USR_TypeUserIdTypeUser",
                schema: "ONE",
                table: "USR_User");

            migrationBuilder.DropColumn(
                name: "UserNavigationUser",
                schema: "ONE",
                table: "USR_DetTypeUser");

            migrationBuilder.DropColumn(
                name: "ControlIdControl",
                schema: "ONE",
                table: "USR_ControlRol");

            migrationBuilder.AddForeignKey(
                name: "FK_USR_ControlRol_USR_Control_IdControl",
                schema: "ONE",
                table: "USR_ControlRol",
                column: "IdControl",
                principalSchema: "ONE",
                principalTable: "USR_Control",
                principalColumn: "IdControl",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USR_DetTypeUser_USR_User_User",
                schema: "ONE",
                table: "USR_DetTypeUser",
                column: "User",
                principalSchema: "ONE",
                principalTable: "USR_User",
                principalColumn: "User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USR_User_USR_TypeUser_IdTypeUser",
                schema: "ONE",
                table: "USR_User",
                column: "IdTypeUser",
                principalSchema: "ONE",
                principalTable: "USR_TypeUser",
                principalColumn: "IdTypeUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USR_UserRol_USR_Rol_Rol",
                schema: "ONE",
                table: "USR_UserRol",
                column: "Rol",
                principalSchema: "ONE",
                principalTable: "USR_Rol",
                principalColumn: "Rol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USR_UserRol_USR_User_User",
                schema: "ONE",
                table: "USR_UserRol",
                column: "User",
                principalSchema: "ONE",
                principalTable: "USR_User",
                principalColumn: "User",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
