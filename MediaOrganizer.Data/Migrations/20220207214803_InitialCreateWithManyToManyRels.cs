using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaOrganizer.Data.Migrations
{
    public partial class InitialCreateWithManyToManyRels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaCatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaCatalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaTypeId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaObjects_MediaTypes_MediaTypeId",
                        column: x => x.MediaTypeId,
                        principalTable: "MediaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaCatalogMediaObject",
                columns: table => new
                {
                    CatalogsId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaCatalogMediaObject", x => new { x.CatalogsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_MediaCatalogMediaObject_MediaCatalogs_CatalogsId",
                        column: x => x.CatalogsId,
                        principalTable: "MediaCatalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaCatalogMediaObject_MediaObjects_MembersId",
                        column: x => x.MembersId,
                        principalTable: "MediaObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaCatalogMediaObject_MembersId",
                table: "MediaCatalogMediaObject",
                column: "MembersId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaObjects_MediaTypeId",
                table: "MediaObjects",
                column: "MediaTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaCatalogMediaObject");

            migrationBuilder.DropTable(
                name: "MediaCatalogs");

            migrationBuilder.DropTable(
                name: "MediaObjects");

            migrationBuilder.DropTable(
                name: "MediaTypes");
        }
    }
}
