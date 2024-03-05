using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bikes.Migrations
{
    /// <inheritdoc />
    public partial class AddRider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Riders",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    Birthdate = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    CnhNumber = table.Column<string>(type: "text", nullable: false),
                    CnhType = table.Column<int>(type: "integer", nullable: false),
                    CnhPhotoUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Riders", x => x.Id);
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Riders_CnhNumber",
                table: "Riders",
                column: "CnhNumber",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_Riders_Cnpj",
                table: "Riders",
                column: "Cnpj",
                unique: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Riders");
        }
    }
}
