using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherAPI.DB.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Astronomies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sunrise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sunset = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Astronomies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atmospheres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Humidity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pressure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rising = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atmospheres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoLetterCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThreeLetterCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numeric = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Winds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chill = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speed = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherObservations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AstronomyId = table.Column<long>(type: "bigint", nullable: false),
                    AtmosphereId = table.Column<long>(type: "bigint", nullable: false),
                    ConditionId = table.Column<long>(type: "bigint", nullable: false),
                    WindId = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherObservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherObservations_Astronomies_AstronomyId",
                        column: x => x.AstronomyId,
                        principalTable: "Astronomies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeatherObservations_Atmospheres_AtmosphereId",
                        column: x => x.AtmosphereId,
                        principalTable: "Atmospheres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeatherObservations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeatherObservations_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeatherObservations_Winds_WindId",
                        column: x => x.WindId,
                        principalTable: "Winds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherObservations_AstronomyId",
                table: "WeatherObservations",
                column: "AstronomyId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherObservations_AtmosphereId",
                table: "WeatherObservations",
                column: "AtmosphereId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherObservations_CityId",
                table: "WeatherObservations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherObservations_ConditionId",
                table: "WeatherObservations",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherObservations_WindId",
                table: "WeatherObservations",
                column: "WindId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherObservations");

            migrationBuilder.DropTable(
                name: "Astronomies");

            migrationBuilder.DropTable(
                name: "Atmospheres");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Winds");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
