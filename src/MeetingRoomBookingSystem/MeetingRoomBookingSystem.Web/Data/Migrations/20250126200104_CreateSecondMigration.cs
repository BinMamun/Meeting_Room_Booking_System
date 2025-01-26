using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingRoomBookingSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateSecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "MeetingRooms");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "MeetingRooms");

            migrationBuilder.AddColumn<DateTime>(
                name: "Availablity",
                table: "MeetingRooms",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availablity",
                table: "MeetingRooms");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Available",
                table: "MeetingRooms",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "MeetingRooms",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
