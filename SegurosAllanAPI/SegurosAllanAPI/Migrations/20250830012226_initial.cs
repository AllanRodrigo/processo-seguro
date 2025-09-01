using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SegurosAllanAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Segurados",
                columns: table => new
                {
                    Cpf = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segurados", x => x.Cpf);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seguros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxaRisco = table.Column<double>(type: "float", nullable: false),
                    PremioRisco = table.Column<double>(type: "float", nullable: false),
                    PremioPuro = table.Column<double>(type: "float", nullable: false),
                    PremioComercial = table.Column<double>(type: "float", nullable: false),
                    SeguradoCpf = table.Column<long>(type: "bigint", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguros_Segurados_SeguradoCpf",
                        column: x => x.SeguradoCpf,
                        principalTable: "Segurados",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seguros_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seguros_SeguradoCpf",
                table: "Seguros",
                column: "SeguradoCpf");

            migrationBuilder.CreateIndex(
                name: "IX_Seguros_VeiculoId",
                table: "Seguros",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguros");

            migrationBuilder.DropTable(
                name: "Segurados");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
