using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace piyoz.uz.Migrations
{
    /// <inheritdoc />
    public partial class CarRentingUpdatingTheWholeDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Cars",
                newName: "DailyRate");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cars",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "ManufacturedYear",
                table: "Cars",
                newName: "Year");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Cars",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "Cars",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarId = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Make",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Cars",
                newName: "ManufacturedYear");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Cars",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DailyRate",
                table: "Cars",
                newName: "Price");

            migrationBuilder.AddColumn<int>(
                name: "Brand",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
