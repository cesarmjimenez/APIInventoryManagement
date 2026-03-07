using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixOutboundAndOutboundDetailsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutboundDetails_Outbounds_OutboundId",
                table: "OutboundDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_OutboundDetails_Outbounds_OutboundId",
                table: "OutboundDetails",
                column: "OutboundId",
                principalTable: "Outbounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutboundDetails_Outbounds_OutboundId",
                table: "OutboundDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_OutboundDetails_Outbounds_OutboundId",
                table: "OutboundDetails",
                column: "OutboundId",
                principalTable: "Outbounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
