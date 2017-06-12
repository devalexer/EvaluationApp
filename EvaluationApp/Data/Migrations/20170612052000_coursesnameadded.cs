using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationApp.Data.Migrations
{
    public partial class coursesnameadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LecturesId",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoursesName",
                table: "Lectures",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LecturesId",
                table: "DataOfUnderstanding",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Questions_LecturesId",
                table: "Questions",
                column: "LecturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Lectures_LecturesId",
                table: "Questions",
                column: "LecturesId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Lectures_LecturesId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_LecturesId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "LecturesId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CoursesName",
                table: "Lectures");

            migrationBuilder.AlterColumn<int>(
                name: "LecturesId",
                table: "DataOfUnderstanding",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
