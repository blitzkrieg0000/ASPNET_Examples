using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UI.Migrations
{
    /// <inheritdoc />
    public partial class mig02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUserRole",
                keyColumn: "id",
                keyValue: new Guid("b19356ba-5e39-4abf-ad63-030df5717a9a"));

            migrationBuilder.DeleteData(
                table: "ApplicationUserRole",
                keyColumn: "id",
                keyValue: new Guid("fd4aef32-60a7-4b4b-9801-9b22a0e0a33c"));

            migrationBuilder.UpdateData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "created_time",
                value: new DateTime(2024, 2, 10, 20, 51, 33, 631, DateTimeKind.Utc).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "created_time",
                value: new DateTime(2024, 2, 10, 20, 51, 33, 631, DateTimeKind.Utc).AddTicks(8893));

            migrationBuilder.UpdateData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "created_time",
                value: new DateTime(2024, 2, 10, 20, 51, 33, 631, DateTimeKind.Utc).AddTicks(8906));

            migrationBuilder.InsertData(
                table: "ApplicationRole",
                columns: new[] { "id", "active", "created_time", "deleted_time", "is_persistent", "modified_time", "name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000004"), true, new DateTime(2024, 2, 10, 20, 51, 33, 631, DateTimeKind.Utc).AddTicks(8918), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), true, new DateTime(2024, 2, 10, 20, 51, 33, 631, DateTimeKind.Utc).AddTicks(8931), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), true, new DateTime(2024, 2, 10, 20, 51, 33, 631, DateTimeKind.Utc).AddTicks(8945), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HumanResources" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), true, new DateTime(2024, 2, 10, 20, 51, 33, 631, DateTimeKind.Utc).AddTicks(8958), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee" }
                });

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "created_time",
                value: new DateTime(2024, 2, 10, 20, 51, 33, 632, DateTimeKind.Utc).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "created_time",
                value: new DateTime(2024, 2, 10, 20, 51, 33, 632, DateTimeKind.Utc).AddTicks(1662));

            migrationBuilder.InsertData(
                table: "ApplicationUserRole",
                columns: new[] { "id", "active", "created_time", "deleted_time", "is_persistent", "modified_time", "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("cf706864-1a4c-40d2-85db-312d4d70fd33"), true, new DateTime(2024, 2, 10, 20, 51, 33, 632, DateTimeKind.Utc).AddTicks(8879), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f55c0f25-61e6-46ef-b606-f65225e0c469"), true, new DateTime(2024, 2, 10, 20, 51, 33, 632, DateTimeKind.Utc).AddTicks(8906), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "EmployeeType",
                columns: new[] { "id", "active", "application_role_id", "created_time", "deleted_time", "is_persistent", "modified_time", "name" },
                values: new object[,]
                {
                    { new Guid("523d0c26-45cc-4b30-9053-b944c916c1c2"), true, new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2024, 2, 10, 20, 51, 33, 633, DateTimeKind.Utc).AddTicks(8817), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HumanResources" },
                    { new Guid("6d734f0b-b599-41f0-b117-8aaa8d21ffa1"), true, new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2024, 2, 10, 20, 51, 33, 633, DateTimeKind.Utc).AddTicks(8829), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee" },
                    { new Guid("a39cb0fb-3a97-4a0b-bb0a-b8fc19471f3b"), true, new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 2, 10, 20, 51, 33, 633, DateTimeKind.Utc).AddTicks(8804), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT" },
                    { new Guid("bbc359c0-6321-4056-a5a8-f52a3e348671"), true, new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2024, 2, 10, 20, 51, 33, 633, DateTimeKind.Utc).AddTicks(8750), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUserRole",
                keyColumn: "id",
                keyValue: new Guid("cf706864-1a4c-40d2-85db-312d4d70fd33"));

            migrationBuilder.DeleteData(
                table: "ApplicationUserRole",
                keyColumn: "id",
                keyValue: new Guid("f55c0f25-61e6-46ef-b606-f65225e0c469"));

            migrationBuilder.DeleteData(
                table: "EmployeeType",
                keyColumn: "id",
                keyValue: new Guid("523d0c26-45cc-4b30-9053-b944c916c1c2"));

            migrationBuilder.DeleteData(
                table: "EmployeeType",
                keyColumn: "id",
                keyValue: new Guid("6d734f0b-b599-41f0-b117-8aaa8d21ffa1"));

            migrationBuilder.DeleteData(
                table: "EmployeeType",
                keyColumn: "id",
                keyValue: new Guid("a39cb0fb-3a97-4a0b-bb0a-b8fc19471f3b"));

            migrationBuilder.DeleteData(
                table: "EmployeeType",
                keyColumn: "id",
                keyValue: new Guid("bbc359c0-6321-4056-a5a8-f52a3e348671"));

            migrationBuilder.DeleteData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.UpdateData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "created_time",
                value: new DateTime(2024, 2, 10, 19, 59, 36, 70, DateTimeKind.Utc).AddTicks(252));

            migrationBuilder.UpdateData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "created_time",
                value: new DateTime(2024, 2, 10, 19, 59, 36, 70, DateTimeKind.Utc).AddTicks(275));

            migrationBuilder.UpdateData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "created_time",
                value: new DateTime(2024, 2, 10, 19, 59, 36, 70, DateTimeKind.Utc).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "created_time",
                value: new DateTime(2024, 2, 10, 19, 59, 36, 70, DateTimeKind.Utc).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "created_time",
                value: new DateTime(2024, 2, 10, 19, 59, 36, 70, DateTimeKind.Utc).AddTicks(3113));

            migrationBuilder.InsertData(
                table: "ApplicationUserRole",
                columns: new[] { "id", "active", "created_time", "deleted_time", "is_persistent", "modified_time", "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("b19356ba-5e39-4abf-ad63-030df5717a9a"), true, new DateTime(2024, 2, 10, 19, 59, 36, 70, DateTimeKind.Utc).AddTicks(9549), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("fd4aef32-60a7-4b4b-9801-9b22a0e0a33c"), true, new DateTime(2024, 2, 10, 19, 59, 36, 70, DateTimeKind.Utc).AddTicks(9578), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") }
                });
        }
    }
}
