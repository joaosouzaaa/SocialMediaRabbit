using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileMicroService.API.Migrations
{
    /// <inheritdoc />
    public partial class Follow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Follow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    follower_id = table.Column<int>(type: "int", nullable: false),
                    following_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follow_Profile_follower_id",
                        column: x => x.follower_id,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Follow_Profile_following_id",
                        column: x => x.following_id,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Follow_follower_id",
                table: "Follow",
                column: "follower_id");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_following_id",
                table: "Follow",
                column: "following_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Follow");
        }
    }
}
