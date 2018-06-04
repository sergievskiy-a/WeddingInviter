using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FamilySite.Data.Migrations
{
    public partial class someChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SuggestHotel",
                table: "Invites",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "InviteAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    Going = table.Column<bool>(nullable: false),
                    InviteId = table.Column<int>(nullable: true),
                    NeedHotel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InviteAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InviteAnswers_Invites_InviteId",
                        column: x => x.InviteId,
                        principalTable: "Invites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InviteAnswers_InviteId",
                table: "InviteAnswers",
                column: "InviteId",
                unique: true,
                filter: "[InviteId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InviteAnswers");

            migrationBuilder.DropColumn(
                name: "SuggestHotel",
                table: "Invites");
        }
    }
}
