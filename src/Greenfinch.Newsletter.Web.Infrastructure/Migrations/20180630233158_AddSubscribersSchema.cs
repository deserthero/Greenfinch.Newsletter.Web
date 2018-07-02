using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Greenfinch.Newsletter.Web.Infrastructure.EF.Migrations
{
    public partial class AddSubscribersSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    HeardFrom = table.Column<string>(nullable: true),
                    ReasonForSignup = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscribers");
        }
    }
}
