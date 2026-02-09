using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutPost.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add3Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "s_Phone_number",
                table: "Parcels",
                newName: "s_PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "r_Phone_number",
                table: "Parcels",
                newName: "r_PhoneNumber");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Parcels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Parcels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_ClientId",
                table: "Parcels",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_SenderId",
                table: "Parcels",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Email",
                table: "Clients",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Clients_ClientId",
                table: "Parcels",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Clients_SenderId",
                table: "Parcels",
                column: "SenderId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Clients_ClientId",
                table: "Parcels");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Clients_SenderId",
                table: "Parcels");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Parcels_ClientId",
                table: "Parcels");

            migrationBuilder.DropIndex(
                name: "IX_Parcels_SenderId",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Parcels");

            migrationBuilder.RenameColumn(
                name: "s_PhoneNumber",
                table: "Parcels",
                newName: "s_Phone_number");

            migrationBuilder.RenameColumn(
                name: "r_PhoneNumber",
                table: "Parcels",
                newName: "r_Phone_number");
        }
    }
}
