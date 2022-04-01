using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AndreAirlinesApi.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Passenger",
                newName: "Nome");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Passenger",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    Acronym = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.Acronym);
                    table.ForeignKey(
                        name: "FK_Airport_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Airship",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportDestinyAcronym = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AirportOriginAcronym = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AirshipId = table.Column<int>(type: "int", nullable: true),
                    HorarioEmbarque = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioDesembarque = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassengerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_AirportDestinyAcronym",
                        column: x => x.AirportDestinyAcronym,
                        principalTable: "Airport",
                        principalColumn: "Acronym",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_AirportOriginAcronym",
                        column: x => x.AirportOriginAcronym,
                        principalTable: "Airport",
                        principalColumn: "Acronym",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Airship_AirshipId",
                        column: x => x.AirshipId,
                        principalTable: "Airship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Passenger_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passenger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airport_AddressId",
                table: "Airport",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirportDestinyAcronym",
                table: "Flight",
                column: "AirportDestinyAcronym");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirportOriginAcronym",
                table: "Flight",
                column: "AirportOriginAcronym");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirshipId",
                table: "Flight",
                column: "AirshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_PassengerId",
                table: "Flight",
                column: "PassengerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropTable(
                name: "Airship");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Passenger",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Passenger",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);
        }
    }
}
