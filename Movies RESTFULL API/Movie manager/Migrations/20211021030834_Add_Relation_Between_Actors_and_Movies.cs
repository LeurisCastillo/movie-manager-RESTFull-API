using Microsoft.EntityFrameworkCore.Migrations;

namespace Movie_manager.Migrations
{
    public partial class Add_Relation_Between_Actors_and_Movies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ActorId",
                table: "Movie",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Actors_ActorId",
                table: "Movie",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Actors_ActorId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_ActorId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Movie");
        }
    }
}
