using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aec.Brasil.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AecBrasil");

            migrationBuilder.CreateTable(
                name: "Cidade",
                schema: "AecBrasil",
                columns: table => new
                {
                    IdCidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdIntegracao = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime", nullable: false),
                    AlteradoPor = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.IdCidade);
                });

            migrationBuilder.CreateTable(
                name: "Clima",
                schema: "AecBrasil",
                columns: table => new
                {
                    IdClima = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condicao = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    CondicaoDesc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Min = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false),
                    IndiceUV = table.Column<int>(type: "int", nullable: false),
                    IdCidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriadoPor = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime", nullable: false),
                    AlteradoPor = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clima", x => x.IdClima);
                    table.ForeignKey(
                        name: "FK_Clima_Cidade",
                        column: x => x.IdCidade,
                        principalSchema: "AecBrasil",
                        principalTable: "Cidade",
                        principalColumn: "IdCidade");
                });

            migrationBuilder.CreateIndex(
                name: "FKIDX_Clima_Cidade",
                schema: "AecBrasil",
                table: "Clima",
                column: "IdCidade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clima",
                schema: "AecBrasil");

            migrationBuilder.DropTable(
                name: "Cidade",
                schema: "AecBrasil");
        }
    }
}
