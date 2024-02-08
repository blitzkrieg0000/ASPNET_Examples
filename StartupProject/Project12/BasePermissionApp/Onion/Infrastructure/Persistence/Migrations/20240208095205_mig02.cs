using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUserClaim",
                keyColumn: "id",
                keyValue: new Guid("6734ae9a-d0a9-40e7-9fcd-4d08c092d97d"));

            migrationBuilder.DeleteData(
                table: "ApplicationUserClaim",
                keyColumn: "id",
                keyValue: new Guid("a5d51d22-d786-4178-9cab-731cd03ffd02"));

            migrationBuilder.DeleteData(
                table: "ApplicationUserRole",
                keyColumn: "id",
                keyValue: new Guid("56291db2-e8a6-4581-9f6a-8b8576457875"));

            migrationBuilder.DeleteData(
                table: "ApplicationUserRole",
                keyColumn: "id",
                keyValue: new Guid("91446eab-8998-4729-8733-2cfa319f47df"));

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ApplicationMenu",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "ApplicationMenu",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ApplicationMenu",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "ApplicationMenu",
                newName: "modified_time");

            migrationBuilder.RenameColumn(
                name: "IsPersistent",
                table: "ApplicationMenu",
                newName: "is_persistent");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "ApplicationMenu",
                newName: "deleted_time");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "ApplicationMenu",
                newName: "created_time");

            migrationBuilder.AlterColumn<bool>(
                name: "active",
                table: "ApplicationMenu",
                type: "boolean",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "ApplicationMenu",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "created_time",
                value: new DateTime(2024, 2, 8, 9, 52, 4, 720, DateTimeKind.Utc).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "created_time",
                value: new DateTime(2024, 2, 8, 9, 52, 4, 720, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "created_time",
                value: new DateTime(2024, 2, 8, 9, 52, 4, 720, DateTimeKind.Utc).AddTicks(8835));

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "created_time", "security_stamp_date" },
                values: new object[] { new DateTime(2024, 2, 8, 9, 52, 4, 722, DateTimeKind.Utc).AddTicks(946), new DateTime(2024, 2, 8, 9, 52, 4, 722, DateTimeKind.Utc).AddTicks(921) });

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "created_time", "security_stamp_date" },
                values: new object[] { new DateTime(2024, 2, 8, 9, 52, 4, 722, DateTimeKind.Utc).AddTicks(992), new DateTime(2024, 2, 8, 9, 52, 4, 722, DateTimeKind.Utc).AddTicks(979) });

            migrationBuilder.InsertData(
                table: "ApplicationUserClaim",
                columns: new[] { "id", "active", "claim_type", "claim_value", "created_time", "deleted_time", "is_persistent", "modified_time", "user_id" },
                values: new object[,]
                {
                    { new Guid("d5d4be19-698c-4985-8b08-ced4e6fab1a3"), true, "ProfilePhoto", "asset/image/user.png", new DateTime(2024, 2, 8, 9, 52, 4, 721, DateTimeKind.Utc).AddTicks(6977), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("fc312c73-a0dc-4e4c-a290-69109e8f20b0"), true, "ProfilePhoto", "asset/image/user.png", new DateTime(2024, 2, 8, 9, 52, 4, 721, DateTimeKind.Utc).AddTicks(7004), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRole",
                columns: new[] { "id", "active", "created_time", "deleted_time", "is_persistent", "modified_time", "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("b1bebd91-81ed-4e72-8814-cc7c41737111"), true, new DateTime(2024, 2, 8, 9, 52, 4, 722, DateTimeKind.Utc).AddTicks(8622), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("f6b11333-b3ee-4f69-a5bb-131fa3eb2761"), true, new DateTime(2024, 2, 8, 9, 52, 4, 722, DateTimeKind.Utc).AddTicks(8593), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUserClaim",
                keyColumn: "id",
                keyValue: new Guid("d5d4be19-698c-4985-8b08-ced4e6fab1a3"));

            migrationBuilder.DeleteData(
                table: "ApplicationUserClaim",
                keyColumn: "id",
                keyValue: new Guid("fc312c73-a0dc-4e4c-a290-69109e8f20b0"));

            migrationBuilder.DeleteData(
                table: "ApplicationUserRole",
                keyColumn: "id",
                keyValue: new Guid("b1bebd91-81ed-4e72-8814-cc7c41737111"));

            migrationBuilder.DeleteData(
                table: "ApplicationUserRole",
                keyColumn: "id",
                keyValue: new Guid("f6b11333-b3ee-4f69-a5bb-131fa3eb2761"));

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ApplicationMenu",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "ApplicationMenu",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ApplicationMenu",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "modified_time",
                table: "ApplicationMenu",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "is_persistent",
                table: "ApplicationMenu",
                newName: "IsPersistent");

            migrationBuilder.RenameColumn(
                name: "deleted_time",
                table: "ApplicationMenu",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "created_time",
                table: "ApplicationMenu",
                newName: "CreatedTime");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "ApplicationMenu",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "ApplicationMenu",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)");

            migrationBuilder.UpdateData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "created_time",
                value: new DateTime(2024, 2, 8, 9, 48, 50, 710, DateTimeKind.Utc).AddTicks(8477));

            migrationBuilder.UpdateData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "created_time",
                value: new DateTime(2024, 2, 8, 9, 48, 50, 710, DateTimeKind.Utc).AddTicks(8499));

            migrationBuilder.UpdateData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "created_time",
                value: new DateTime(2024, 2, 8, 9, 48, 50, 710, DateTimeKind.Utc).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "created_time", "security_stamp_date" },
                values: new object[] { new DateTime(2024, 2, 8, 9, 48, 50, 712, DateTimeKind.Utc).AddTicks(715), new DateTime(2024, 2, 8, 9, 48, 50, 712, DateTimeKind.Utc).AddTicks(691) });

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "created_time", "security_stamp_date" },
                values: new object[] { new DateTime(2024, 2, 8, 9, 48, 50, 712, DateTimeKind.Utc).AddTicks(817), new DateTime(2024, 2, 8, 9, 48, 50, 712, DateTimeKind.Utc).AddTicks(804) });

            migrationBuilder.InsertData(
                table: "ApplicationUserClaim",
                columns: new[] { "id", "active", "claim_type", "claim_value", "created_time", "deleted_time", "is_persistent", "modified_time", "user_id" },
                values: new object[,]
                {
                    { new Guid("6734ae9a-d0a9-40e7-9fcd-4d08c092d97d"), true, "ProfilePhoto", "asset/image/user.png", new DateTime(2024, 2, 8, 9, 48, 50, 711, DateTimeKind.Utc).AddTicks(6903), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a5d51d22-d786-4178-9cab-731cd03ffd02"), true, "ProfilePhoto", "asset/image/user.png", new DateTime(2024, 2, 8, 9, 48, 50, 711, DateTimeKind.Utc).AddTicks(6930), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRole",
                columns: new[] { "id", "active", "created_time", "deleted_time", "is_persistent", "modified_time", "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("56291db2-e8a6-4581-9f6a-8b8576457875"), true, new DateTime(2024, 2, 8, 9, 48, 50, 712, DateTimeKind.Utc).AddTicks(8058), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("91446eab-8998-4729-8733-2cfa319f47df"), true, new DateTime(2024, 2, 8, 9, 48, 50, 712, DateTimeKind.Utc).AddTicks(8031), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") }
                });
        }
    }
}
