using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Buffer_BH.Migrations
{
    /// <inheritdoc />
    public partial class NovoCaixa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Forma",
                table: "Caixa");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Caixa");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAbertura",
                table: "Caixa",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFechamento",
                table: "Caixa",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Lucro",
                table: "Caixa",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Caixa",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalEntradas",
                table: "Caixa",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSaidas",
                table: "Caixa",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorFinal",
                table: "Caixa",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorInicial",
                table: "Caixa",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAbertura",
                table: "Caixa");

            migrationBuilder.DropColumn(
                name: "DataFechamento",
                table: "Caixa");

            migrationBuilder.DropColumn(
                name: "Lucro",
                table: "Caixa");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Caixa");

            migrationBuilder.DropColumn(
                name: "TotalEntradas",
                table: "Caixa");

            migrationBuilder.DropColumn(
                name: "TotalSaidas",
                table: "Caixa");

            migrationBuilder.DropColumn(
                name: "ValorFinal",
                table: "Caixa");

            migrationBuilder.DropColumn(
                name: "ValorInicial",
                table: "Caixa");

            migrationBuilder.AddColumn<string>(
                name: "Forma",
                table: "Caixa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Caixa",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
