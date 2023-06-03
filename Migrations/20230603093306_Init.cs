﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Animals.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal_Class",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal_Class", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Procedure",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedure", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false),
                    AnimalClassID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Animal_Animal_Class_AnimalClassID",
                        column: x => x.AnimalClassID,
                        principalTable: "Animal_Class",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_Owner_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owner",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procedure_Animal",
                columns: table => new
                {
                    ProcedureID = table.Column<int>(type: "int", nullable: false),
                    AnimalID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedure_Animal", x => new { x.ProcedureID, x.AnimalID });
                    table.ForeignKey(
                        name: "FK_Procedure_Animal_Animal_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Animal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Procedure_Animal_Procedure_ProcedureID",
                        column: x => x.ProcedureID,
                        principalTable: "Procedure",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animal_Class",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "nameclass1" },
                    { 2, "nameclass2" },
                    { 3, "nameclass3" }
                });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Anna", "Kowal" },
                    { 2, "Michał", "Kowalczyk" }
                });

            migrationBuilder.InsertData(
                table: "Procedure",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "procedure-desc", "procedure-name" },
                    { 2, "procedure-desc-2", "procedure-name-2" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "ID", "AdmissionDate", "AnimalClassID", "Name", "OwnerID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "nameAnimal1", 1 },
                    { 2, new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "nameAnimal2", 2 },
                    { 3, new DateTime(2022, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "nameAnimal3", 2 }
                });

            migrationBuilder.InsertData(
                table: "Procedure_Animal",
                columns: new[] { "AnimalID", "ProcedureID", "Date" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2018, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2020, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_AnimalClassID",
                table: "Animal",
                column: "AnimalClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_OwnerID",
                table: "Animal",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Procedure_Animal_AnimalID",
                table: "Procedure_Animal",
                column: "AnimalID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Procedure_Animal");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Procedure");

            migrationBuilder.DropTable(
                name: "Animal_Class");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
