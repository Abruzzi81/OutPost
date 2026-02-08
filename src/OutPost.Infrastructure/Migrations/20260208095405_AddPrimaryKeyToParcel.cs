using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutPost.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryKeyToParcel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "r_Name",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "r_email",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "r_phone_number",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "s_Name",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "s_address",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "s_email",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "s_phone_number",
                table: "Parcels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "r_Name",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "r_email",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "r_phone_number",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "s_Name",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "s_address",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "s_email",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "s_phone_number",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
