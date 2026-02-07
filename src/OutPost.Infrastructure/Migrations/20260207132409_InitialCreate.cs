using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutPost.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parcels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    dateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    s_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    s_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    s_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    s_phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    r_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    r_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    r_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    r_phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_TrackingNumber",
                table: "Parcels",
                column: "TrackingNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcels");
        }
    }
}
