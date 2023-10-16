using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCentralPark.Migrations
{
    /// <inheritdoc />
    public partial class AlternadoTabelaVeiculos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VEICULOS",
                table: "VEICULOS");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "VEICULOS",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VEICULOS",
                table: "VEICULOS",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VEICULOS",
                table: "VEICULOS");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "VEICULOS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VEICULOS",
                table: "VEICULOS",
                column: "Placa");
        }
    }
}
