using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NokiaHUIServer.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedCard",
                columns: table => new
                {
                    MedCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Grow = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    AB0 = table.Column<string>(nullable: true),
                    Rh = table.Column<string>(nullable: true),
                    MedHistory = table.Column<string>(nullable: true),
                    PacientProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedCard", x => x.MedCardId);
                });

            migrationBuilder.CreateTable(
                name: "PacientProfiles",
                columns: table => new
                {
                    PacientProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Passw = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    AdditionalPhoneNumber = table.Column<string>(nullable: true),
                    BirthDay = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    MedCardId = table.Column<int>(nullable: false),
                    MedCardId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacientProfiles", x => x.PacientProfileId);
                    table.ForeignKey(
                        name: "FK_PacientProfiles_MedCard_MedCardId1",
                        column: x => x.MedCardId1,
                        principalTable: "MedCard",
                        principalColumn: "MedCardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PacientProfiles_MedCardId1",
                table: "PacientProfiles",
                column: "MedCardId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacientProfiles");

            migrationBuilder.DropTable(
                name: "MedCard");
        }
    }
}
