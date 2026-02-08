using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutPost.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSenderAndRecipentToParcel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "r_address",
                table: "Parcels",
                newName: "r_Address");

            migrationBuilder.RenameColumn(
                name: "dateOfCreation",
                table: "Parcels",
                newName: "DateOfCreation");

            migrationBuilder.AddColumn<string>(
                name: "r_Email",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "r_Name",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "r_Phone_number",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "s_Address",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "s_Email",
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
                name: "s_Phone_number",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "r_Email",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "r_Name",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "r_Phone_number",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "s_Address",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "s_Email",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "s_Name",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "s_Phone_number",
                table: "Parcels");

            migrationBuilder.RenameColumn(
                name: "r_Address",
                table: "Parcels",
                newName: "r_address");

            migrationBuilder.RenameColumn(
                name: "DateOfCreation",
                table: "Parcels",
                newName: "dateOfCreation");
        }
    }
}
