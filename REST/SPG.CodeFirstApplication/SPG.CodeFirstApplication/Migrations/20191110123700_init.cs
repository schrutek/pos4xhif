using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPG.CodeFirstApplication.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pupils",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 250, nullable: false),
                    LastName = table.Column<string>(maxLength: 250, nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    SchoolClassId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupils", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolClassId" },
                values: new object[] { new Guid("26a76d85-7577-4b53-abd1-4aca501a3f68"), "Vorname 1", "M", "Nachname 1", new Guid("75d42b58-c4c6-4380-9f8b-bacdcf8e03ee") });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolClassId" },
                values: new object[] { new Guid("5699f9fe-4f2d-4c00-b226-007e0ff42ca7"), "Vorname 2", "M", "Nachname 2", new Guid("75d42b58-c4c6-4380-9f8b-bacdcf8e03ee") });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolClassId" },
                values: new object[] { new Guid("3404ce31-e751-44cb-b84a-3b318a017176"), "Vorname 3", "M", "Nachname 3", new Guid("75d42b58-c4c6-4380-9f8b-bacdcf8e03ee") });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolClassId" },
                values: new object[] { new Guid("1b71952b-4695-4741-92a0-b2fb9dfa6851"), "Vorname 4", "M", "Nachname 4", new Guid("75d42b58-c4c6-4380-9f8b-bacdcf8e03ee") });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolClassId" },
                values: new object[] { new Guid("7b66c7c6-2898-456e-95bf-37af3f97e799"), "Vorname 5", "M", "Nachname 5", new Guid("75d42b58-c4c6-4380-9f8b-bacdcf8e03ee") });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolClassId" },
                values: new object[] { new Guid("cf3bd38f-3e4f-4202-a6ee-102e00c03a2a"), "Vorname 6", "M", "Nachname 6", new Guid("75d42b58-c4c6-4380-9f8b-bacdcf8e03ee") });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolClassId" },
                values: new object[] { new Guid("65549b37-0de2-4549-9a0c-90311bad52f1"), "Vorname 7", "M", "Nachname 7", new Guid("75d42b58-c4c6-4380-9f8b-bacdcf8e03ee") });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolClassId" },
                values: new object[] { new Guid("d69d01ba-afed-40ea-b54e-63c0fbd25abd"), "Vorname 8", "M", "Nachname 8", new Guid("75d42b58-c4c6-4380-9f8b-bacdcf8e03ee") });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolClassId" },
                values: new object[] { new Guid("a16970d2-2a84-4a76-8991-0ecec1eeb1c8"), "Vorname 9", "M", "Nachname 9", new Guid("ac87ce7b-89bd-434f-a800-b2979d745c1b") });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolClassId" },
                values: new object[] { new Guid("38cf31d8-a3a9-4e4d-86d9-aacb52c52c1b"), "Vorname 10", "M", "Nachname 10", new Guid("ac87ce7b-89bd-434f-a800-b2979d745c1b") });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolClassId" },
                values: new object[] { new Guid("ef2e0d3d-91b8-44c1-b335-183a82f517b2"), "Vorname 11", "M", "Nachname 11", new Guid("ac87ce7b-89bd-434f-a800-b2979d745c1b") });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolClassId" },
                values: new object[] { new Guid("ad4ab73a-8cba-4ad6-9079-3f546c0f8589"), "Vorname 12", "M", "Nachname 12", new Guid("1712daf8-bf01-4f88-905b-74ec9498d077") });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolClassId" },
                values: new object[] { new Guid("fcd40d7b-b676-43a9-bec5-1d2f9301a450"), "Vorname 13", "M", "Nachname 13", new Guid("1712daf8-bf01-4f88-905b-74ec9498d077") });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolClassId" },
                values: new object[] { new Guid("7893a991-cb8c-457b-84b6-87329f70d9b6"), "Vorname 14", "M", "Nachname 14", new Guid("1712daf8-bf01-4f88-905b-74ec9498d077") });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolClassId" },
                values: new object[] { new Guid("65dc791d-8109-4f63-9bf2-fab745af866d"), "Vorname 15", "M", "Nachname 15", new Guid("1712daf8-bf01-4f88-905b-74ec9498d077") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pupils");
        }
    }
}
