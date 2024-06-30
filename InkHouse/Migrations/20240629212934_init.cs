using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InkHouse.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    { new Guid("36d13b72-f356-4d0a-8364-c6f55e78e538"), "Англия" },
                    { new Guid("e8c499d3-a794-49a7-a65e-f0ec0bcace58"), "Германия" },
                    { new Guid("ed1dc00c-8576-4e3b-8a99-6c85ad9336b3"), "Франция" }
                });

            migrationBuilder.InsertData(
                table: "Painters",
                columns: new[] { "Id", "Birthdate", "CountryId", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("28ff85a5-63da-41c8-827b-2d69afc3b148"), new DateTime(1990, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("36d13b72-f356-4d0a-8364-c6f55e78e538"), "Франсуа", "Дюпон" },
                    { new Guid("9791266f-620d-433f-aad4-1dede4052505"), new DateTime(1980, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8c499d3-a794-49a7-a65e-f0ec0bcace58"), "Анри", "Селин" },
                    { new Guid("bb26a45a-120e-477f-9356-a3845f07af35"), new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ed1dc00c-8576-4e3b-8a99-6c85ad9336b3"), "Марсель", "Руссо" }
                });

            migrationBuilder.InsertData(
                table: "Paintings",
                columns: new[] { "PaintingId", "Image", "Name", "PainterId", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("27bad295-e53c-4060-8fb5-57681f1e4354"), "Assets/PaintingImg/27bad295-e53c-4060-8fb5-57681f1e4354.jpg", "Дама с собачкой", new Guid("9791266f-620d-433f-aad4-1dede4052505"), 16500.0, "Акрил, бумага (50х80)" },
                    { new Guid("7cea2648-a8fc-4cca-9730-85bf83ac437c"), "Assets/PaintingImg/7cea2648-a8fc-4cca-9730-85bf83ac437c.jpg", "Процедура", new Guid("28ff85a5-63da-41c8-827b-2d69afc3b148"), 20000.0, "Цветная литография (40х60)" }
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
