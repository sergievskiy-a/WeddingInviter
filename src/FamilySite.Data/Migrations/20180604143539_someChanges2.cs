using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FamilySite.Data.Migrations
{
    public partial class someChanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InviteAnswers_Invites_InviteId",
                table: "InviteAnswers");

            migrationBuilder.DropIndex(
                name: "IX_InviteAnswers_InviteId",
                table: "InviteAnswers");

            migrationBuilder.AddColumn<int>(
                name: "InviteAnswerId",
                table: "Invites",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InviteId",
                table: "InviteAnswers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InviteAnswers_InviteId",
                table: "InviteAnswers",
                column: "InviteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InviteAnswers_Invites_InviteId",
                table: "InviteAnswers",
                column: "InviteId",
                principalTable: "Invites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InviteAnswers_Invites_InviteId",
                table: "InviteAnswers");

            migrationBuilder.DropIndex(
                name: "IX_InviteAnswers_InviteId",
                table: "InviteAnswers");

            migrationBuilder.DropColumn(
                name: "InviteAnswerId",
                table: "Invites");

            migrationBuilder.AlterColumn<int>(
                name: "InviteId",
                table: "InviteAnswers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_InviteAnswers_InviteId",
                table: "InviteAnswers",
                column: "InviteId",
                unique: true,
                filter: "[InviteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_InviteAnswers_Invites_InviteId",
                table: "InviteAnswers",
                column: "InviteId",
                principalTable: "Invites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
