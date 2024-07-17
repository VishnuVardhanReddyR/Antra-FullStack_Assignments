using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackdropUrl = table.Column<string>(type: "nvarchar(2084)", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImdbUrl = table.Column<string>(type: "nvarchar(2084)", nullable: true),
                    OriginalLanguage = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(2084)", nullable: true),
                    PosterUrl = table.Column<string>(type: "nvarchar(2084)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Revenue = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    RunTime = table.Column<int>(type: "int", nullable: true),
                    TagLine = table.Column<string>(type: "nvarchar(512)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    TmdbUrl = table.Column<string>(type: "nvarchar(2084)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
