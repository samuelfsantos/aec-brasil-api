using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aec.Brasil.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoAeroporto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeroporto",
                schema: "AecBrasil",
                columns: table => new
                {
                    IdAeroporto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Umidade = table.Column<int>(type: "int", nullable: false),
                    Visibilidade = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CodigoIcao = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    PressaoAtmosferica = table.Column<int>(type: "int", nullable: false),
                    Vento = table.Column<int>(type: "int", nullable: false),
                    DirecaoVento = table.Column<int>(type: "int", nullable: false),
                    Condicao = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    CondicaoDesc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Temp = table.Column<int>(type: "int", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime", nullable: false),
                    AlteradoPor = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeroporto", x => x.IdAeroporto);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_Cidade_IdIntegracao",
                schema: "AecBrasil",
                table: "Cidade",
                column: "IdIntegracao");

            migrationBuilder.CreateIndex(
                name: "IDX_Aeroporto_CodigoIcao",
                schema: "AecBrasil",
                table: "Aeroporto",
                column: "CodigoIcao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeroporto",
                schema: "AecBrasil");

            migrationBuilder.DropIndex(
                name: "IDX_Cidade_IdIntegracao",
                schema: "AecBrasil",
                table: "Cidade");
        }
    }
}
