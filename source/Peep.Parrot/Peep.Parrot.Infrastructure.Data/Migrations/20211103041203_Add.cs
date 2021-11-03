using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Peep.Parrot.Infrastructure.Data.Migrations
{
    public partial class Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPrivateAccount = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    PeepId = table.Column<Guid>(type: "uuid", nullable: true),
                    PeepId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Block",
                columns: table => new
                {
                    BlockerId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlockedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Block", x => new { x.BlockerId, x.BlockedId });
                    table.ForeignKey(
                        name: "FK_Block_User_BlockerId",
                        column: x => x.BlockerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Followship",
                columns: table => new
                {
                    FollowerId = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowedId = table.Column<Guid>(type: "uuid", nullable: false),
                    Accepted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followship", x => new { x.FollowerId, x.FollowedId });
                    table.ForeignKey(
                        name: "FK_Followship_User_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mute",
                columns: table => new
                {
                    MuterId = table.Column<Guid>(type: "uuid", nullable: false),
                    MutedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mute", x => new { x.MuterId, x.MutedId });
                    table.ForeignKey(
                        name: "FK_Mute_User_MuterId",
                        column: x => x.MuterId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Peep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(280)", maxLength: 280, nullable: true),
                    ReplyRestriction = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    PeepId = table.Column<Guid>(type: "uuid", nullable: true),
                    Reply_PeepId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peep_Peep_PeepId",
                        column: x => x.PeepId,
                        principalTable: "Peep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Peep_Peep_Reply_PeepId",
                        column: x => x.Reply_PeepId,
                        principalTable: "Peep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Peep_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Peep_PeepId",
                table: "Peep",
                column: "PeepId");

            migrationBuilder.CreateIndex(
                name: "IX_Peep_Reply_PeepId",
                table: "Peep",
                column: "Reply_PeepId");

            migrationBuilder.CreateIndex(
                name: "IX_Peep_UserId1",
                table: "Peep",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_User_PeepId",
                table: "User",
                column: "PeepId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PeepId1",
                table: "User",
                column: "PeepId1");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Peep_PeepId",
                table: "User",
                column: "PeepId",
                principalTable: "Peep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Peep_PeepId1",
                table: "User",
                column: "PeepId1",
                principalTable: "Peep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peep_User_UserId1",
                table: "Peep");

            migrationBuilder.DropTable(
                name: "Block");

            migrationBuilder.DropTable(
                name: "Followship");

            migrationBuilder.DropTable(
                name: "Mute");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Peep");
        }
    }
}
