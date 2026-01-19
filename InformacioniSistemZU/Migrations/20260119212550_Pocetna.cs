using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformacioniSistemZU.Migrations
{
    /// <inheritdoc />
    public partial class Pocetna : Migration
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LekarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacijenti_Lekari_LekarId",
                        column: x => x.LekarId,
                        principalTable: "Lekari",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pregledi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DijagnozaId = table.Column<int>(type: "int", nullable: false),
                    LekarId = table.Column<int>(type: "int", nullable: true),
                    PacijentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregledi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pregledi_Dijagnoze_DijagnozaId",
                        column: x => x.DijagnozaId,
                        principalTable: "Dijagnoze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pregledi_Lekari_LekarId",
                        column: x => x.LekarId,
                        principalTable: "Lekari",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pregledi_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lekari_SpecijalnostId",
                table: "Lekari",
                column: "SpecijalnostId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacijenti_LekarId",
                table: "Pacijenti",
                column: "LekarId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_DijagnozaId",
                table: "Pregledi",
                column: "DijagnozaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_LekarId",
                table: "Pregledi",
                column: "LekarId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_PacijentId",
                table: "Pregledi",
                column: "PacijentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pregledi");

            migrationBuilder.DropTable(
                name: "Dijagnoze");

            migrationBuilder.DropTable(
                name: "Pacijenti");

            migrationBuilder.DropTable(
                name: "Lekari");

            migrationBuilder.DropTable(
                name: "Specijalnosti");
        }
    }
}
