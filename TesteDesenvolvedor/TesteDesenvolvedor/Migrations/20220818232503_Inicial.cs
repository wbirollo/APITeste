using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteDesenvolvedor.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cervejas",
                columns: table => new
                {
                    IdCervejas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cervejas", x => x.IdCervejas);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    IdVendas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalVenda = table.Column<double>(type: "float", nullable: false),
                    CashbackTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.IdVendas);
                });

            migrationBuilder.CreateTable(
                name: "ItensVenda",
                columns: table => new
                {
                    IdItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantidadeItem = table.Column<int>(type: "int", nullable: false),
                    CervejasId = table.Column<int>(type: "int", nullable: false),
                    TotalItem = table.Column<double>(type: "float", nullable: false),
                    CashbackItem = table.Column<double>(type: "float", nullable: false),
                    VendasIdVendas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensVenda", x => x.IdItem);
                    table.ForeignKey(
                        name: "FK_ItensVenda_Cervejas_CervejasId",
                        column: x => x.CervejasId,
                        principalTable: "Cervejas",
                        principalColumn: "IdCervejas",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensVenda_Vendas_VendasIdVendas",
                        column: x => x.VendasIdVendas,
                        principalTable: "Vendas",
                        principalColumn: "IdVendas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_CervejasId",
                table: "ItensVenda",
                column: "CervejasId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_VendasIdVendas",
                table: "ItensVenda",
                column: "VendasIdVendas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensVenda");

            migrationBuilder.DropTable(
                name: "Cervejas");

            migrationBuilder.DropTable(
                name: "Vendas");
        }
    }
}
