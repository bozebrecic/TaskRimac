using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RimacTask.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NetworkNodeData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkNodeData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessagesData",
                columns: table => new
                {
                    TempId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MesssageId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NetworkNodeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesData", x => x.TempId);
                    table.ForeignKey(
                        name: "FK_MessagesData_NetworkNodeData_NetworkNodeId",
                        column: x => x.NetworkNodeId,
                        principalTable: "NetworkNodeData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignalsData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BitStart = table.Column<int>(type: "integer", nullable: false),
                    Length = table.Column<int>(type: "integer", nullable: false),
                    MessageTempId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignalsData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignalsData_MessagesData_MessageTempId",
                        column: x => x.MessageTempId,
                        principalTable: "MessagesData",
                        principalColumn: "TempId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessagesData_NetworkNodeId",
                table: "MessagesData",
                column: "NetworkNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SignalsData_MessageTempId",
                table: "SignalsData",
                column: "MessageTempId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignalsData");

            migrationBuilder.DropTable(
                name: "MessagesData");

            migrationBuilder.DropTable(
                name: "NetworkNodeData");
        }
    }
}
