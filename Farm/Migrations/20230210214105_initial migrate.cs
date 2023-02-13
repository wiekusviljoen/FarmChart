using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farm.Migrations
{
    /// <inheritdoc />
    public partial class initialmigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cattle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Camp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bulls = table.Column<int>(type: "int", nullable: false),
                    Cows = table.Column<int>(type: "int", nullable: false),
                    BullCalf = table.Column<int>(type: "int", nullable: false),
                    CowCalf = table.Column<int>(type: "int", nullable: false),
                    NewCalf = table.Column<int>(type: "int", nullable: false),
                    Missing = table.Column<int>(type: "int", nullable: false),
                    Dead = table.Column<int>(type: "int", nullable: false),
                    Branded = table.Column<bool>(type: "bit", nullable: false),
                    Dipped = table.Column<bool>(type: "bit", nullable: false),
                    Injected = table.Column<bool>(type: "bit", nullable: false),
                    Feed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedPrice = table.Column<double>(type: "float", nullable: false),
                    FeedQuantity = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cattle", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cattle");
        }
    }
}
