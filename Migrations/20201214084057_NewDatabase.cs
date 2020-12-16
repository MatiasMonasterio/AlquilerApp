using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlquilerApp.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contract",
                table: "Contract");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Contract",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contract",
                table: "Contract",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Fee",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    ContractId = table.Column<long>(type: "INTEGER", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    EmitDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpiryAmount = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fee", x => new { x.Id, x.ContractId });
                    table.ForeignKey(
                        name: "FK_Fee_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AditionalAmount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    amount = table.Column<double>(type: "REAL", nullable: false),
                    FeeId = table.Column<long>(type: "INTEGER", nullable: false),
                    FeeContractId = table.Column<long>(type: "INTEGER", nullable: true),
                    FeeId1 = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AditionalAmount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AditionalAmount_Fee_FeeId1_FeeContractId",
                        columns: x => new { x.FeeId1, x.FeeContractId },
                        principalTable: "Fee",
                        principalColumns: new[] { "Id", "ContractId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AditionalAmount_FeeId1_FeeContractId",
                table: "AditionalAmount",
                columns: new[] { "FeeId1", "FeeContractId" });

            migrationBuilder.CreateIndex(
                name: "IX_Fee_ContractId",
                table: "Fee",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AditionalAmount");

            migrationBuilder.DropTable(
                name: "Fee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contract",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Contract");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contract",
                table: "Contract",
                columns: new[] { "RenterId", "DepartmentId" });
        }
    }
}
