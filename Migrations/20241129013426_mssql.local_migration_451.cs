﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CanineConnect.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_451 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeOnly>(
                name: "Time",
                table: "Event",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Event");
        }
    }
}
