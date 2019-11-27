using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LithologyLog.Model.Migrations
{
    public partial class Add_Report : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractorOrgId = table.Column<int>(nullable: false),
                    ClientOrgId = table.Column<int>(nullable: false),
                    SiteName = table.Column<string>(maxLength: 100, nullable: true),
                    ProjectName = table.Column<string>(maxLength: 100, nullable: true),
                    Borehole = table.Column<string>(nullable: true),
                    Depth = table.Column<float>(nullable: false),
                    Diameter = table.Column<float>(nullable: false),
                    CoreRecovery = table.Column<float>(nullable: false),
                    DrillingEquipment = table.Column<string>(maxLength: 100, nullable: true),
                    DrillingMethode = table.Column<string>(maxLength: 100, nullable: true),
                    GroundDedectionWatherLevel = table.Column<float>(nullable: false),
                    GroundStableWatherLevelValue = table.Column<float>(nullable: false),
                    Elavation = table.Column<float>(nullable: false),
                    BoreholeNCoordinate = table.Column<float>(nullable: false),
                    BoreholeECoordinate = table.Column<float>(nullable: false),
                    PageCreationMember = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Report");
        }
    }
}
