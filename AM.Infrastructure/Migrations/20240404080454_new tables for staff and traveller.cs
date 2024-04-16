﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newtablesforstaffandtraveller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployementDate",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Function",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "HealthInformation",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "IsTraveller",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Passengers");

            migrationBuilder.CreateTable(
                name: "staff",
                columns: table => new
                {
                    PassporitNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    EmployementDate = table.Column<DateTime>(type: "date", nullable: false),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff", x => x.PassporitNumber);
                    table.ForeignKey(
                        name: "FK_staff_Passengers_PassporitNumber",
                        column: x => x.PassporitNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassporitNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Traveller",
                columns: table => new
                {
                    PassporitNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    HealthInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traveller", x => x.PassporitNumber);
                    table.ForeignKey(
                        name: "FK_Traveller_Passengers_PassporitNumber",
                        column: x => x.PassporitNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassporitNumber",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "staff");

            migrationBuilder.DropTable(
                name: "Traveller");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmployementDate",
                table: "Passengers",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Function",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HealthInformation",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsTraveller",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Passengers",
                type: "float",
                nullable: true);
        }
    }
}
