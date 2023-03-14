using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketOnline.Migrations
{
    /// <inheritdoc />
    public partial class updateconstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "ShowtimeId",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShowTimeId",
                table: "Seats",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatId_ShowtimeId",
                table: "Tickets",
                columns: new[] { "SeatId", "ShowtimeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShowtimeId",
                table: "Tickets",
                column: "ShowtimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_ShowTimeId",
                table: "Seats",
                column: "ShowTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_ShowTimes_ShowTimeId",
                table: "Seats",
                column: "ShowTimeId",
                principalTable: "ShowTimes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ShowTimes_ShowtimeId",
                table: "Tickets",
                column: "ShowtimeId",
                principalTable: "ShowTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_ShowTimes_ShowTimeId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ShowTimes_ShowtimeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_SeatId_ShowtimeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ShowtimeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Seats_ShowTimeId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "ShowtimeId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ShowTimeId",
                table: "Seats");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets",
                column: "SeatId");
        }
    }
}
