using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aec.Brasil.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoLogErro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogErro",
                schema: "AecBrasil",
                columns: table => new
                {
                    IdLogErro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Detail = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: false),
                    StackTrace = table.Column<string>(type: "varchar(max)", unicode: false, maxLength: 15000, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime", nullable: false),
                    AlteradoPor = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogErro", x => x.IdLogErro);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogErro",
                schema: "AecBrasil");
        }
    }
}
