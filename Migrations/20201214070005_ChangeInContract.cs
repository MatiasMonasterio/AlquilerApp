using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlquilerApp.Migrations
{
    public partial class ChangeInContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Department_DepartmentId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Lessee_LesseeId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Renter_RenterId",
                table: "Contract");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contract",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_DepartmentId",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_RenterId",
                table: "Contract");

            migrationBuilder.RenameColumn(
                name: "LesseeId",
                table: "Contract",
                newName: "amount");

            migrationBuilder.AddColumn<DateTime>(
                name: "finishDate",
                table: "Contract",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contract",
                table: "Contract",
                columns: new[] { "RenterId", "DepartmentId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contract",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "finishDate",
                table: "Contract");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Contract",
                newName: "LesseeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contract",
                table: "Contract",
                columns: new[] { "LesseeId", "DepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Contract_DepartmentId",
                table: "Contract",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_RenterId",
                table: "Contract",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Department_DepartmentId",
                table: "Contract",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Lessee_LesseeId",
                table: "Contract",
                column: "LesseeId",
                principalTable: "Lessee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Renter_RenterId",
                table: "Contract",
                column: "RenterId",
                principalTable: "Renter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
