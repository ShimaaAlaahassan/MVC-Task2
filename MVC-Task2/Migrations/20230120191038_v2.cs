using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCTask2.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Departments_deptNum",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "deptNum",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Departments_deptNum",
                table: "Projects",
                column: "deptNum",
                principalTable: "Departments",
                principalColumn: "Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Departments_deptNum",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "deptNum",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Departments_deptNum",
                table: "Projects",
                column: "deptNum",
                principalTable: "Departments",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
