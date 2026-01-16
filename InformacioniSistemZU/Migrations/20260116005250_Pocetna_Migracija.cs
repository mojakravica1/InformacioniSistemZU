using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformacioniSistemZU.Migrations
{
    /// <inheritdoc />
    public partial class Pocetna_Migracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dijagnoze",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dijagnoze", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacijenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jmbg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pol = table.Column<byte>(type: "tinyint", nullable: false),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    LekarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pregledi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DijagnozaId = table.Column<int>(type: "int", nullable: false),
                    PacijentId = table.Column<int>(type: "int", nullable: false),
                    LekarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregledi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specijalnosti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specijalnosti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lekari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jmbg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pol = table.Column<byte>(type: "tinyint", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    SpecijalnostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lekari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lekari_Specijalnosti_SpecijalnostId",
                        column: x => x.SpecijalnostId,
                        principalTable: "Specijalnosti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lekari_SpecijalnostId",
                table: "Lekari",
                column: "SpecijalnostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dijagnoze");

            migrationBuilder.DropTable(
                name: "Lekari");

            migrationBuilder.DropTable(
                name: "Pacijenti");

            migrationBuilder.DropTable(
                name: "Pregledi");

            migrationBuilder.DropTable(
                name: "Specijalnosti");
        }
    }
}
