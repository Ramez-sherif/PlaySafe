using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaySafe.Migrations
{
    public partial class tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_type",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specials",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AD_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Special = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specials", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Specials_User_type_AD_id",
                        column: x => x.AD_id,
                        principalTable: "User_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    u_Typeid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    phone_Num = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_Id);
                    table.ForeignKey(
                        name: "FK_User_User_type_u_Typeid",
                        column: x => x.u_Typeid,
                        principalTable: "User_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usertype_pages",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userTypeid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usertype_pages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Usertype_pages_User_type_userTypeid",
                        column: x => x.userTypeid,
                        principalTable: "User_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_User_userID",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "user_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match_History",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    entryid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_History_Entry_entryid",
                        column: x => x.entryid,
                        principalTable: "Entry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_History_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "user_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NFC",
                columns: table => new
                {
                    NFCId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFC", x => x.NFCId);
                    table.ForeignKey(
                        name: "FK_NFC_User_Userid",
                        column: x => x.Userid,
                        principalTable: "User",
                        principalColumn: "user_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    player_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    admin_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.player_Id);
                    table.ForeignKey(
                        name: "FK_Player_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "user_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userID",
                table: "Comments",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Match_History_entryid",
                table: "Match_History",
                column: "entryid");

            migrationBuilder.CreateIndex(
                name: "IX_Match_History_userid",
                table: "Match_History",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_NFC_Userid",
                table: "NFC",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Player_userid",
                table: "Player",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Specials_AD_id",
                table: "Specials",
                column: "AD_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_u_Typeid",
                table: "User",
                column: "u_Typeid");

            migrationBuilder.CreateIndex(
                name: "IX_Usertype_pages_userTypeid",
                table: "Usertype_pages",
                column: "userTypeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Match_History");

            migrationBuilder.DropTable(
                name: "NFC");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Specials");

            migrationBuilder.DropTable(
                name: "Usertype_pages");

            migrationBuilder.DropTable(
                name: "Entry");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "User_type");
        }
    }
}
