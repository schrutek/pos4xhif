using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPG.CodeFirstApplication.Migrations
{
    public partial class schoolclass_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolClass",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClass", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pupils_SchoolClassId",
                table: "Pupils",
                column: "SchoolClassId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Pupils_SchoolClass_SchoolClassId",
            //    table: "Pupils",
            //    column: "SchoolClassId",
            //    principalTable: "SchoolClass",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pupils_SchoolClass_SchoolClassId",
                table: "Pupils");

            migrationBuilder.DropTable(
                name: "SchoolClass");

            migrationBuilder.DropIndex(
                name: "IX_Pupils_SchoolClassId",
                table: "Pupils");
        }
    }
}
