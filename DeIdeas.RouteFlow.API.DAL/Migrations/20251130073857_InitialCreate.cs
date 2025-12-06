using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeIdeas.RouteFlow.API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ONE");

            migrationBuilder.CreateTable(
                name: "USR_Rol",
                schema: "ONE",
                columns: table => new
                {
                    Rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    User = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_Rol", x => x.Rol);
                });

            migrationBuilder.CreateTable(
                name: "USR_TypeUser",
                schema: "ONE",
                columns: table => new
                {
                    IdTypeUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_TypeUser", x => x.IdTypeUser);
                });

            migrationBuilder.CreateTable(
                name: "USR_User",
                schema: "ONE",
                columns: table => new
                {
                    User = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdTypeUser = table.Column<int>(type: "int", nullable: false),
                    ADObjectId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_User", x => x.User);
                    table.ForeignKey(
                        name: "FK_USR_User_USR_TypeUser_IdTypeUser",
                        column: x => x.IdTypeUser,
                        principalSchema: "ONE",
                        principalTable: "USR_TypeUser",
                        principalColumn: "IdTypeUser",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "USR_Config",
                schema: "ONE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_Config", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USR_Config_USR_User_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "ONE",
                        principalTable: "USR_User",
                        principalColumn: "User",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "USR_Control",
                schema: "ONE",
                columns: table => new
                {
                    IdControl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMaestro = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    User = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_Control", x => x.IdControl);
                    table.ForeignKey(
                        name: "FK_USR_Control_USR_User_User",
                        column: x => x.User,
                        principalSchema: "ONE",
                        principalTable: "USR_User",
                        principalColumn: "User",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "USR_DetTypeUser",
                schema: "ONE",
                columns: table => new
                {
                    IdTypeUser = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_DetTypeUser", x => new { x.User, x.IdTypeUser });
                    table.ForeignKey(
                        name: "FK_USR_DetTypeUser_USR_TypeUser_IdTypeUser",
                        column: x => x.IdTypeUser,
                        principalSchema: "ONE",
                        principalTable: "USR_TypeUser",
                        principalColumn: "IdTypeUser",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_USR_DetTypeUser_USR_User_User",
                        column: x => x.User,
                        principalSchema: "ONE",
                        principalTable: "USR_User",
                        principalColumn: "User",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "USR_UserRol",
                schema: "ONE",
                columns: table => new
                {
                    User = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_UserRol", x => new { x.User, x.Rol });
                    table.ForeignKey(
                        name: "FK_USR_UserRol_USR_Rol_Rol",
                        column: x => x.Rol,
                        principalSchema: "ONE",
                        principalTable: "USR_Rol",
                        principalColumn: "Rol",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_USR_UserRol_USR_User_User",
                        column: x => x.User,
                        principalSchema: "ONE",
                        principalTable: "USR_User",
                        principalColumn: "User",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "USR_ControlRol",
                schema: "ONE",
                columns: table => new
                {
                    IdControl = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_ControlRol", x => new { x.IdControl, x.Rol });
                    table.ForeignKey(
                        name: "FK_USR_ControlRol_USR_Control_IdControl",
                        column: x => x.IdControl,
                        principalSchema: "ONE",
                        principalTable: "USR_Control",
                        principalColumn: "IdControl",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_USR_ControlRol_USR_Rol_Rol",
                        column: x => x.Rol,
                        principalSchema: "ONE",
                        principalTable: "USR_Rol",
                        principalColumn: "Rol",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USR_Config_IdUser",
                schema: "ONE",
                table: "USR_Config",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_USR_Control_User",
                schema: "ONE",
                table: "USR_Control",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_USR_ControlRol_Rol",
                schema: "ONE",
                table: "USR_ControlRol",
                column: "Rol");

            migrationBuilder.CreateIndex(
                name: "IX_USR_DetTypeUser_IdTypeUser",
                schema: "ONE",
                table: "USR_DetTypeUser",
                column: "IdTypeUser");

            migrationBuilder.CreateIndex(
                name: "IX_USR_User_ADObjectId",
                schema: "ONE",
                table: "USR_User",
                column: "ADObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USR_User_IdTypeUser",
                schema: "ONE",
                table: "USR_User",
                column: "IdTypeUser");

            migrationBuilder.CreateIndex(
                name: "IX_USR_UserRol_Rol",
                schema: "ONE",
                table: "USR_UserRol",
                column: "Rol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USR_Config",
                schema: "ONE");

            migrationBuilder.DropTable(
                name: "USR_ControlRol",
                schema: "ONE");

            migrationBuilder.DropTable(
                name: "USR_DetTypeUser",
                schema: "ONE");

            migrationBuilder.DropTable(
                name: "USR_UserRol",
                schema: "ONE");

            migrationBuilder.DropTable(
                name: "USR_Control",
                schema: "ONE");

            migrationBuilder.DropTable(
                name: "USR_Rol",
                schema: "ONE");

            migrationBuilder.DropTable(
                name: "USR_User",
                schema: "ONE");

            migrationBuilder.DropTable(
                name: "USR_TypeUser",
                schema: "ONE");
        }
    }
}
