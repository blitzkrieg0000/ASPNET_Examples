using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UI.Migrations
{
    /// <inheritdoc />
    public partial class mig01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationRole",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    created_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)"),
                    modified_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_persistent = table.Column<bool>(type: "boolean", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRole", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    created_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)"),
                    modified_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_persistent = table.Column<bool>(type: "boolean", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DataProtectionKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FriendlyName = table.Column<string>(type: "text", nullable: true),
                    Xml = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProtectionKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)"),
                    modified_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_persistent = table.Column<bool>(type: "boolean", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserRole",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)"),
                    modified_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_persistent = table.Column<bool>(type: "boolean", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRole", x => x.id);
                    table.ForeignKey(
                        name: "applicationuserrole_fk",
                        column: x => x.user_id,
                        principalTable: "ApplicationUser",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "applicationuserrole_fk_1",
                        column: x => x.role_id,
                        principalTable: "ApplicationRole",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    employee_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    mail = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    created_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)"),
                    modified_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_persistent = table.Column<bool>(type: "boolean", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employee_ApplicationUser_id",
                        column: x => x.id,
                        principalTable: "ApplicationUser",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeType_employee_type_id",
                        column: x => x.employee_type_id,
                        principalTable: "EmployeeType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OffWork",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    off_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)"),
                    off_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)"),
                    MyProperty = table.Column<int>(type: "integer", nullable: false),
                    is_approved = table.Column<bool>(type: "boolean", nullable: false),
                    created_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)"),
                    modified_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_persistent = table.Column<bool>(type: "boolean", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OffWork", x => x.id);
                    table.ForeignKey(
                        name: "FK_OffWork_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationRole",
                columns: new[] { "id", "active", "created_time", "deleted_time", "is_persistent", "modified_time", "name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), true, new DateTime(2024, 2, 9, 15, 9, 37, 159, DateTimeKind.Utc).AddTicks(9504), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SuperUser" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), true, new DateTime(2024, 2, 9, 15, 9, 37, 159, DateTimeKind.Utc).AddTicks(9523), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), true, new DateTime(2024, 2, 9, 15, 9, 37, 159, DateTimeKind.Utc).AddTicks(9536), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "id", "active", "created_time", "deleted_time", "email", "is_persistent", "modified_time", "password", "phone_number", "user_name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), true, new DateTime(2024, 2, 9, 15, 9, 37, 160, DateTimeKind.Utc).AddTicks(2190), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "burakhansamli0.0.0.0@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "f3f5e898ed41cd8e0b3785bc5bba537deffe3889e525b30e72f947a27c2d2caf986f73663a308e97ba6f24323ce2929e6afe4b86204d93617c16000dd574a8e5", null, "root" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), true, new DateTime(2024, 2, 9, 15, 9, 37, 160, DateTimeKind.Utc).AddTicks(2208), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "99ec526fe3e3f956acb4712b6bca88d918a3eb6d3e0a17634667e2775aad07ec1f8f84f8bbbf227eb5e0574177b13c8c30cc71b2d8e9bda722c023a81b754601", null, "admin" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRole",
                columns: new[] { "id", "active", "created_time", "deleted_time", "is_persistent", "modified_time", "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("2dc03c58-3ca9-4948-a652-af50c74060f3"), true, new DateTime(2024, 2, 9, 15, 9, 37, 160, DateTimeKind.Utc).AddTicks(8652), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a77f3d4a-061b-458a-8d49-8dedd52e04fd"), true, new DateTime(2024, 2, 9, 15, 9, 37, 160, DateTimeKind.Utc).AddTicks(8679), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRole_role_id",
                table: "ApplicationUserRole",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRole_user_id",
                table: "ApplicationUserRole",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_employee_type_id",
                table: "Employee",
                column: "employee_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_OffWork_EmployeeId",
                table: "OffWork",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRole");

            migrationBuilder.DropTable(
                name: "DataProtectionKeys");

            migrationBuilder.DropTable(
                name: "OffWork");

            migrationBuilder.DropTable(
                name: "ApplicationRole");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "EmployeeType");
        }
    }
}
