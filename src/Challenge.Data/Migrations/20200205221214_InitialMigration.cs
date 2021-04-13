using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: true),
                    Pais = table.Column<string>(type: "varchar(50)", nullable: true),
                    Regiao = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SensorId = table.Column<Guid>(nullable: false),
                    Tempo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(10,5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_Sensores_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_SensorId",
                table: "Eventos",
                column: "SensorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Sensores");
        }
    }
}
