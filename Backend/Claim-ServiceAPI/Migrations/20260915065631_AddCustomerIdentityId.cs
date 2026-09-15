using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Claim_ServiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerIdentityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerIdentityId",
                table: "Claim",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Claim_CustomerIdentityId",
                table: "Claim",
                column: "CustomerIdentityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Claim_CustomerIdentityId",
                table: "Claim");

            migrationBuilder.DropColumn(
                name: "CustomerIdentityId",
                table: "Claim");
        }
    }
}
