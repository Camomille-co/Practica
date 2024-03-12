using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jhyf.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageNews",
                table: "News");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageNews",
                table: "News",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
