using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCTask2.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Minit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salary = table.Column<decimal>(type: "money", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    supervisorSSN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_supervisorSSN",
                        column: x => x.supervisorSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "departmentLocations",
                columns: table => new
                {
                    location = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeptNumber = table.Column<int>(type: "int", nullable: false),
                    departmentLocationDeptNumber = table.Column<int>(type: "int", nullable: true),
                    departmentLocationlocation = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departmentLocations", x => new { x.DeptNumber, x.location });
                    table.ForeignKey(
                        name: "FK_departmentLocations_Departments_DeptNumber",
                        column: x => x.DeptNumber,
                        principalTable: "Departments",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_departmentLocations_departmentLocations_departmentLocationDeptNumber_departmentLocationlocation",
                        columns: x => new { x.departmentLocationDeptNumber, x.departmentLocationlocation },
                        principalTable: "departmentLocations",
                        principalColumns: new[] { "DeptNumber", "location" });
                });

            migrationBuilder.CreateTable(
                name: "Dependants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpSSN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependants", x => x.id);
                    table.ForeignKey(
                        name: "FK_Dependants_Employees_EmpSSN",
                        column: x => x.EmpSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deptNum = table.Column<int>(type: "int", nullable: false),
                    departmentLocationDeptNumber = table.Column<int>(type: "int", nullable: true),
                    departmentLocationlocation = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProNumber);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_deptNum",
                        column: x => x.deptNum,
                        principalTable: "Departments",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_departmentLocations_departmentLocationDeptNumber_departmentLocationlocation",
                        columns: x => new { x.departmentLocationDeptNumber, x.departmentLocationlocation },
                        principalTable: "departmentLocations",
                        principalColumns: new[] { "DeptNumber", "location" });
                });

            migrationBuilder.CreateTable(
                name: "worksOns",
                columns: table => new
                {
                    EmpSSN = table.Column<int>(type: "int", nullable: false),
                    projNum = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeesSSN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_worksOns", x => new { x.EmpSSN, x.projNum });
                    table.ForeignKey(
                        name: "FK_worksOns_Employees_EmployeesSSN",
                        column: x => x.EmployeesSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                    table.ForeignKey(
                        name: "FK_worksOns_Projects_projNum",
                        column: x => x.projNum,
                        principalTable: "Projects",
                        principalColumn: "ProNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departmentLocations_departmentLocationDeptNumber_departmentLocationlocation",
                table: "departmentLocations",
                columns: new[] { "departmentLocationDeptNumber", "departmentLocationlocation" });

            migrationBuilder.CreateIndex(
                name: "IX_Dependants_EmpSSN",
                table: "Dependants",
                column: "EmpSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_supervisorSSN",
                table: "Employees",
                column: "supervisorSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_departmentLocationDeptNumber_departmentLocationlocation",
                table: "Projects",
                columns: new[] { "departmentLocationDeptNumber", "departmentLocationlocation" });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_deptNum",
                table: "Projects",
                column: "deptNum");

            migrationBuilder.CreateIndex(
                name: "IX_worksOns_EmployeesSSN",
                table: "worksOns",
                column: "EmployeesSSN");

            migrationBuilder.CreateIndex(
                name: "IX_worksOns_projNum",
                table: "worksOns",
                column: "projNum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependants");

            migrationBuilder.DropTable(
                name: "worksOns");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "departmentLocations");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
