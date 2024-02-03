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
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserClaim_ApplicationUser_UserId",
                table: "ApplicationUserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserLogin_ApplicationUser_UserId",
                table: "ApplicationUserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRole_ApplicationRole_RoleId",
                table: "ApplicationUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRole_ApplicationUser_UserId",
                table: "ApplicationUserRole");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "ApplicationUserRole",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ApplicationUserRole",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ApplicationUserRole",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "ApplicationUserRole",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "ApplicationUserRole",
                newName: "modified_time");

            migrationBuilder.RenameColumn(
                name: "IsPersistent",
                table: "ApplicationUserRole",
                newName: "is_persistent");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "ApplicationUserRole",
                newName: "deleted_time");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "ApplicationUserRole",
                newName: "created_time");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserRole_UserId",
                table: "ApplicationUserRole",
                newName: "IX_ApplicationUserRole_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserRole_RoleId",
                table: "ApplicationUserRole",
                newName: "IX_ApplicationUserRole_role_id");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "ApplicationUserLogin",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ApplicationUserLogin",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ApplicationUserLogin",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ProviderKey",
                table: "ApplicationUserLogin",
                newName: "provider_key");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "ApplicationUserLogin",
                newName: "modified_time");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "ApplicationUserLogin",
                newName: "login_provider");

            migrationBuilder.RenameColumn(
                name: "IsPersistent",
                table: "ApplicationUserLogin",
                newName: "is_persistent");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "ApplicationUserLogin",
                newName: "deleted_time");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "ApplicationUserLogin",
                newName: "created_time");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserLogin_UserId",
                table: "ApplicationUserLogin",
                newName: "IX_ApplicationUserLogin_user_id");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "ApplicationUserClaim",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ApplicationUserClaim",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ApplicationUserClaim",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "ApplicationUserClaim",
                newName: "modified_time");

            migrationBuilder.RenameColumn(
                name: "IsPersistent",
                table: "ApplicationUserClaim",
                newName: "is_persistent");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "ApplicationUserClaim",
                newName: "deleted_time");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "ApplicationUserClaim",
                newName: "created_time");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "ApplicationUserClaim",
                newName: "claim_value");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "ApplicationUserClaim",
                newName: "claim_type");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserClaim_UserId",
                table: "ApplicationUserClaim",
                newName: "IX_ApplicationUserClaim_user_id");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "ApplicationUser",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ApplicationUser",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "ApplicationUser",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "ApplicationUser",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ApplicationUser",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "ApplicationUser",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ApplicationUser",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "ApplicationUser",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                table: "ApplicationUser",
                newName: "two_factor_enabled");

            migrationBuilder.RenameColumn(
                name: "SecurityStampDate",
                table: "ApplicationUser",
                newName: "security_stamp_date");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenEndDate",
                table: "ApplicationUser",
                newName: "refresh_token_end_date");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberApproved",
                table: "ApplicationUser",
                newName: "phone_number_approved");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "ApplicationUser",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                table: "ApplicationUser",
                newName: "normalized_name");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "ApplicationUser",
                newName: "modified_time");

            migrationBuilder.RenameColumn(
                name: "LockoutEndDateUtc",
                table: "ApplicationUser",
                newName: "lockout_end_date_utc");

            migrationBuilder.RenameColumn(
                name: "LockoutEnabled",
                table: "ApplicationUser",
                newName: "lockout_enabled");

            migrationBuilder.RenameColumn(
                name: "IsPersistent",
                table: "ApplicationUser",
                newName: "is_persistent");

            migrationBuilder.RenameColumn(
                name: "EmailApproved",
                table: "ApplicationUser",
                newName: "email_approved");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "ApplicationUser",
                newName: "deleted_time");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "ApplicationUser",
                newName: "created_time");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "ApplicationUser",
                newName: "access_failed_count");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ApplicationRole",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "ApplicationRole",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ApplicationRole",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "ApplicationRole",
                newName: "modified_time");

            migrationBuilder.RenameColumn(
                name: "IsPersistent",
                table: "ApplicationRole",
                newName: "is_persistent");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "ApplicationRole",
                newName: "deleted_time");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "ApplicationRole",
                newName: "created_time");

            migrationBuilder.AlterColumn<bool>(
                name: "active",
                table: "ApplicationUserRole",
                type: "boolean",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "ApplicationUserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<bool>(
                name: "active",
                table: "ApplicationUserLogin",
                type: "boolean",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "ApplicationUserLogin",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<bool>(
                name: "active",
                table: "ApplicationUserClaim",
                type: "boolean",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "ApplicationUserClaim",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "ApplicationUser",
                type: "text",
                nullable: false,
                defaultValue: "Unspecified",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "active",
                table: "ApplicationUser",
                type: "boolean",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "ApplicationUser",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<bool>(
                name: "active",
                table: "ApplicationRole",
                type: "boolean",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "ApplicationRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true),
                    ThumbnailPath = table.Column<string>(type: "text", nullable: true),
                    StoragePath = table.Column<string>(type: "text", nullable: true),
                    Length = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MetaData = table.Column<string>(type: "text", nullable: true),
                    IsPersistent = table.Column<bool>(type: "boolean", nullable: false),
                    created_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "((CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text) AT TIME ZONE 'UTC'::text)"),
                    deleted_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApplicationRole",
                columns: new[] { "id", "active", "created_time", "deleted_time", "is_persistent", "modified_time", "name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), true, new DateTime(2024, 2, 3, 6, 3, 54, 337, DateTimeKind.Utc).AddTicks(2535), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SuperUser" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), true, new DateTime(2024, 2, 3, 6, 3, 54, 337, DateTimeKind.Utc).AddTicks(2564), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), true, new DateTime(2024, 2, 3, 6, 3, 54, 337, DateTimeKind.Utc).AddTicks(2577), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), true, new DateTime(2024, 2, 3, 6, 3, 54, 337, DateTimeKind.Utc).AddTicks(2590), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NewsAnnouncementModule" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), true, new DateTime(2024, 2, 3, 6, 3, 54, 337, DateTimeKind.Utc).AddTicks(2603), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GrantSupportModule" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), true, new DateTime(2024, 2, 3, 6, 3, 54, 337, DateTimeKind.Utc).AddTicks(2616), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GrowingSuggestionModule" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), true, new DateTime(2024, 2, 3, 6, 3, 54, 337, DateTimeKind.Utc).AddTicks(2629), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CooperativesModule" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "id", "access_failed_count", "active", "created_time", "deleted_time", "description", "email", "email_approved", "is_persistent", "lockout_enabled", "lockout_end_date_utc", "modified_time", "name", "normalized_name", "password", "phone_number", "phone_number_approved", "RefreshToken", "refresh_token_end_date", "security_stamp_date", "two_factor_enabled", "user_name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 0L, true, new DateTime(2024, 2, 3, 6, 3, 54, 337, DateTimeKind.Utc).AddTicks(9899), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "burakhansamli0.0.0.0@gmail.com", true, true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root", "ROOT", "f3f5e898ed41cd8e0b3785bc5bba537deffe3889e525b30e72f947a27c2d2caf986f73663a308e97ba6f24323ce2929e6afe4b86204d93617c16000dd574a8e5", null, true, null, null, new DateTime(2024, 2, 3, 6, 3, 54, 337, DateTimeKind.Utc).AddTicks(9876), true, "root" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 0L, true, new DateTime(2024, 2, 3, 6, 3, 54, 337, DateTimeKind.Utc).AddTicks(9948), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", "ADMIN", "99ec526fe3e3f956acb4712b6bca88d918a3eb6d3e0a17634667e2775aad07ec1f8f84f8bbbf227eb5e0574177b13c8c30cc71b2d8e9bda722c023a81b754601", null, true, null, null, new DateTime(2024, 2, 3, 6, 3, 54, 337, DateTimeKind.Utc).AddTicks(9936), true, "admin" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserClaim",
                columns: new[] { "id", "active", "claim_type", "claim_value", "created_time", "deleted_time", "is_persistent", "modified_time", "user_id" },
                values: new object[,]
                {
                    { new Guid("3faf837f-6c9e-4616-ada0-c581f08453c5"), true, "ProfilePhoto", "asset/image/user.png", new DateTime(2024, 2, 3, 6, 3, 54, 337, DateTimeKind.Utc).AddTicks(5369), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("89fccf50-1d36-4505-9fd5-ef7e05757c0f"), true, "ProfilePhoto", "asset/image/user.png", new DateTime(2024, 2, 3, 6, 3, 54, 337, DateTimeKind.Utc).AddTicks(5397), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRole",
                columns: new[] { "id", "active", "created_time", "deleted_time", "is_persistent", "modified_time", "role_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("64ff86d1-7191-4e98-b525-e7a3af3d3d29"), true, new DateTime(2024, 2, 3, 6, 3, 54, 338, DateTimeKind.Utc).AddTicks(7192), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("d9f1e0a9-62b5-4749-a9cf-9dfe3e728082"), true, new DateTime(2024, 2, 3, 6, 3, 54, 338, DateTimeKind.Utc).AddTicks(7219), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.AddForeignKey(
                name: "applicationuserclaim_fk",
                table: "ApplicationUserClaim",
                column: "user_id",
                principalTable: "ApplicationUser",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "applicationuserlogin_fk",
                table: "ApplicationUserLogin",
                column: "user_id",
                principalTable: "ApplicationUser",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "applicationuserrole_fk",
                table: "ApplicationUserRole",
                column: "user_id",
                principalTable: "ApplicationUser",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "applicationuserrole_fk_1",
                table: "ApplicationUserRole",
                column: "role_id",
                principalTable: "ApplicationRole",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "applicationuserclaim_fk",
                table: "ApplicationUserClaim");

            migrationBuilder.DropForeignKey(
                name: "applicationuserlogin_fk",
                table: "ApplicationUserLogin");

            migrationBuilder.DropForeignKey(
                name: "applicationuserrole_fk",
                table: "ApplicationUserRole");

            migrationBuilder.DropForeignKey(
                name: "applicationuserrole_fk_1",
                table: "ApplicationUserRole");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DeleteData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

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

            migrationBuilder.DeleteData(
                table: "ApplicationUserClaim",
                keyColumn: "id",
                keyValue: new Guid("3faf837f-6c9e-4616-ada0-c581f08453c5"));

            migrationBuilder.DeleteData(
                table: "ApplicationUserClaim",
                keyColumn: "id",
                keyValue: new Guid("89fccf50-1d36-4505-9fd5-ef7e05757c0f"));

            migrationBuilder.DeleteData(
                table: "ApplicationUserRole",
                keyColumn: "id",
                keyValue: new Guid("64ff86d1-7191-4e98-b525-e7a3af3d3d29"));

            migrationBuilder.DeleteData(
                table: "ApplicationUserRole",
                keyColumn: "id",
                keyValue: new Guid("d9f1e0a9-62b5-4749-a9cf-9dfe3e728082"));

            migrationBuilder.DeleteData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "ApplicationRole",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "ApplicationUser",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "ApplicationUser",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.RenameColumn(
                name: "active",
                table: "ApplicationUserRole",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ApplicationUserRole",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "ApplicationUserRole",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "ApplicationUserRole",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "modified_time",
                table: "ApplicationUserRole",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "is_persistent",
                table: "ApplicationUserRole",
                newName: "IsPersistent");

            migrationBuilder.RenameColumn(
                name: "deleted_time",
                table: "ApplicationUserRole",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "created_time",
                table: "ApplicationUserRole",
                newName: "CreatedTime");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserRole_user_id",
                table: "ApplicationUserRole",
                newName: "IX_ApplicationUserRole_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserRole_role_id",
                table: "ApplicationUserRole",
                newName: "IX_ApplicationUserRole_RoleId");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "ApplicationUserLogin",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ApplicationUserLogin",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "ApplicationUserLogin",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "provider_key",
                table: "ApplicationUserLogin",
                newName: "ProviderKey");

            migrationBuilder.RenameColumn(
                name: "modified_time",
                table: "ApplicationUserLogin",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "login_provider",
                table: "ApplicationUserLogin",
                newName: "LoginProvider");

            migrationBuilder.RenameColumn(
                name: "is_persistent",
                table: "ApplicationUserLogin",
                newName: "IsPersistent");

            migrationBuilder.RenameColumn(
                name: "deleted_time",
                table: "ApplicationUserLogin",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "created_time",
                table: "ApplicationUserLogin",
                newName: "CreatedTime");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserLogin_user_id",
                table: "ApplicationUserLogin",
                newName: "IX_ApplicationUserLogin_UserId");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "ApplicationUserClaim",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ApplicationUserClaim",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "ApplicationUserClaim",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "modified_time",
                table: "ApplicationUserClaim",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "is_persistent",
                table: "ApplicationUserClaim",
                newName: "IsPersistent");

            migrationBuilder.RenameColumn(
                name: "deleted_time",
                table: "ApplicationUserClaim",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "created_time",
                table: "ApplicationUserClaim",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "claim_value",
                table: "ApplicationUserClaim",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claim_type",
                table: "ApplicationUserClaim",
                newName: "ClaimType");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserClaim_user_id",
                table: "ApplicationUserClaim",
                newName: "IX_ApplicationUserClaim_UserId");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "ApplicationUser",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ApplicationUser",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "ApplicationUser",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "ApplicationUser",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "ApplicationUser",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "ApplicationUser",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ApplicationUser",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "ApplicationUser",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "two_factor_enabled",
                table: "ApplicationUser",
                newName: "TwoFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "security_stamp_date",
                table: "ApplicationUser",
                newName: "SecurityStampDate");

            migrationBuilder.RenameColumn(
                name: "refresh_token_end_date",
                table: "ApplicationUser",
                newName: "RefreshTokenEndDate");

            migrationBuilder.RenameColumn(
                name: "phone_number_approved",
                table: "ApplicationUser",
                newName: "PhoneNumberApproved");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "ApplicationUser",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "normalized_name",
                table: "ApplicationUser",
                newName: "NormalizedName");

            migrationBuilder.RenameColumn(
                name: "modified_time",
                table: "ApplicationUser",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "lockout_end_date_utc",
                table: "ApplicationUser",
                newName: "LockoutEndDateUtc");

            migrationBuilder.RenameColumn(
                name: "lockout_enabled",
                table: "ApplicationUser",
                newName: "LockoutEnabled");

            migrationBuilder.RenameColumn(
                name: "is_persistent",
                table: "ApplicationUser",
                newName: "IsPersistent");

            migrationBuilder.RenameColumn(
                name: "email_approved",
                table: "ApplicationUser",
                newName: "EmailApproved");

            migrationBuilder.RenameColumn(
                name: "deleted_time",
                table: "ApplicationUser",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "created_time",
                table: "ApplicationUser",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "access_failed_count",
                table: "ApplicationUser",
                newName: "AccessFailedCount");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ApplicationRole",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "ApplicationRole",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ApplicationRole",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "modified_time",
                table: "ApplicationRole",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "is_persistent",
                table: "ApplicationRole",
                newName: "IsPersistent");

            migrationBuilder.RenameColumn(
                name: "deleted_time",
                table: "ApplicationRole",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "created_time",
                table: "ApplicationRole",
                newName: "CreatedTime");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "ApplicationUserRole",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "ApplicationUserRole",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "ApplicationUserLogin",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "ApplicationUserLogin",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "ApplicationUserClaim",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "ApplicationUserClaim",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "ApplicationUser",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "Unspecified");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "ApplicationUser",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "ApplicationUser",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "ApplicationRole",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "ApplicationRole",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserClaim_ApplicationUser_UserId",
                table: "ApplicationUserClaim",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserLogin_ApplicationUser_UserId",
                table: "ApplicationUserLogin",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRole_ApplicationRole_RoleId",
                table: "ApplicationUserRole",
                column: "RoleId",
                principalTable: "ApplicationRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRole_ApplicationUser_UserId",
                table: "ApplicationUserRole",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
