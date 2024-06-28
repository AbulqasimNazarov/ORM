using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InkHouse.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Painters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Painters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Painters_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paintings",
                columns: table => new
                {
                    PaintingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PainterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paintings", x => x.PaintingId);
                    table.ForeignKey(
                        name: "FK_Paintings_Painters_PainterId",
                        column: x => x.PainterId,
                        principalTable: "Painters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("16e52979-6a2c-4498-b60e-35a9d7c68a30"), "Германия" },
                    { new Guid("28b6a49f-4cb9-41ae-a2be-7a54112a191a"), "Англия" },
                    { new Guid("903fb3fc-90c8-4353-a731-6911170cb807"), "Франция" }
                });

            migrationBuilder.InsertData(
                table: "Painters",
                columns: new[] { "Id", "Birthdate", "CountryId", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("5676a486-0bf7-49a7-9be0-f9c482c2f591"), new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("903fb3fc-90c8-4353-a731-6911170cb807"), "Марсель", "Руссо" },
                    { new Guid("79c30055-dfcc-45f6-85a5-174cf2da2146"), new DateTime(1980, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("16e52979-6a2c-4498-b60e-35a9d7c68a30"), "Анри", "Селин" },
                    { new Guid("bb57c88c-b1e3-43a4-825a-ac289e85cfb4"), new DateTime(1990, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("28b6a49f-4cb9-41ae-a2be-7a54112a191a"), "Франсуа", "Дюпон" }
                });

            migrationBuilder.InsertData(
                table: "Paintings",
                columns: new[] { "PaintingId", "Image", "Name", "PainterId", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("27bad295-e53c-4060-8fb5-57681f1e4354"), "Assets/PaintingImg/27bad295-e53c-4060-8fb5-57681f1e4354.jpg", "Дама с собачкой", new Guid("79c30055-dfcc-45f6-85a5-174cf2da2146"), 16500.0, "Акрил, бумага (50х80)" },
                    { new Guid("7cea2648-a8fc-4cca-9730-85bf83ac437c"), "Assets/PaintingImg/7cea2648-a8fc-4cca-9730-85bf83ac437c.jpg", "Процедура", new Guid("bb57c88c-b1e3-43a4-825a-ac289e85cfb4"), 20000.0, "Цветная литография (40х60)" },
                    { new Guid("f8a8c851-2cbc-48c2-a439-bdc494d6329a"), "Assets/PaintingImg/f8a8c851-2cbc-48c2-a439-bdc494d6329a.jpg", "Охота Амура", new Guid("5676a486-0bf7-49a7-9be0-f9c482c2f591"), 14500.0, "Холст, масло (50х80)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Painters_CountryId",
                table: "Painters",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_PainterId",
                table: "Paintings",
                column: "PainterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paintings");

            migrationBuilder.DropTable(
                name: "Painters");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
