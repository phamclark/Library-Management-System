using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryData.Migrations
{
    public partial class AddPatrontoLibraryCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PatronId",
                table: "LibraryCards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCards_PatronId",
                table: "LibraryCards",
                column: "PatronId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryCards_Patrons_PatronId",
                table: "LibraryCards",
                column: "PatronId",
                principalTable: "Patrons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryCards_Patrons_PatronId",
                table: "LibraryCards");

            migrationBuilder.DropIndex(
                name: "IX_LibraryCards_PatronId",
                table: "LibraryCards");

            migrationBuilder.DropColumn(
                name: "PatronId",
                table: "LibraryCards");
        }
    }
}
