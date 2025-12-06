using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeIdeas.RouteFlow.API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update_App : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USR_ControlRol_USR_Control_ControlIdControl",
                schema: "ONE",
                table: "USR_ControlRol");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_ControlRol_USR_Rol_Rol",
                schema: "ONE",
                table: "USR_ControlRol");

            migrationBuilder.DropIndex(
                name: "IX_USR_ControlRol_ControlIdControl",
                schema: "ONE",
                table: "USR_ControlRol");

            migrationBuilder.DropColumn(
                name: "ControlIdControl",
                schema: "ONE",
                table: "USR_ControlRol");

            migrationBuilder.AddForeignKey(
                name: "FK_USR_ControlRol_USR_Rol_Rol",
                schema: "ONE",
                table: "USR_ControlRol",
                column: "Rol",
                principalSchema: "ONE",
                principalTable: "USR_Rol",
                principalColumn: "Rol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USR_ControlRol_USR_Rol_Rol",
                schema: "ONE",
                table: "USR_ControlRol");

            migrationBuilder.AddColumn<int>(
                name: "ControlIdControl",
                schema: "ONE",
                table: "USR_ControlRol",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "FK_USR_ControlRol_USR_Rol_Rol",
                schema: "ONE",
                table: "USR_ControlRol",
                column: "Rol",
                principalSchema: "ONE",
                principalTable: "USR_Rol",
                principalColumn: "Rol",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
