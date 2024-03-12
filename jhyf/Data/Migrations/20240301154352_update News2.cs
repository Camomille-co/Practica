using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jhyf.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateNews2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageNews",
                table: "News",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageNews",
                table: "News");
        }
    }
}
