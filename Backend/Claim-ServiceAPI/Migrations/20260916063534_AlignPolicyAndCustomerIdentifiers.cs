using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Claim_ServiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlignPolicyAndCustomerIdentifiers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Claim_PolicyId",
                table: "Claim");

            migrationBuilder.DropIndex(
                name: "IX_Claim_CustomerId",
                table: "Claim");

            migrationBuilder.AlterColumn<string>(
                name: "PolicyId",
                table: "Claim",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Claim",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_PolicyId",
                table: "Claim",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_CustomerId",
                table: "Claim",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Claim_PolicyId",
                table: "Claim");

            migrationBuilder.DropIndex(
                name: "IX_Claim_CustomerId",
                table: "Claim");

            migrationBuilder.AlterColumn<long>(
                name: "PolicyId",
                table: "Claim",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<long>(
                name: "CustomerId",
                table: "Claim",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.CreateIndex(
                name: "IX_Claim_PolicyId",
                table: "Claim",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_CustomerId",
                table: "Claim",
                column: "CustomerId");
        }
    }
}
