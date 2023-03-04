using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetoCRUD.Application.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Address", "Age", "LastName", "Name", "Phone", "Profession" },
                values: new object[,]
                {
                    { 1, "Rua Hermann Tribess", 17, "Godri", "Pedro", "47999998888", "Programador" },
                    { 2, "Rua Alberto Einstein", 33, "Lisboa", "Ramon", "47999997777", "Programador" },
                    { 3, "Rua Julio Michel", 7, "Godri", "Luiz", "47999996666", "Sushi Man" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
