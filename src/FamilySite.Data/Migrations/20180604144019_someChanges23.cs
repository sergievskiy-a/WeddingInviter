using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FamilySite.Data.Migrations
{
    public partial class someChanges23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InviteAnswerId",
                table: "Invites");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InviteAnswerId",
                table: "Invites",
                nullable: true);
        }
    }
}
