using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaySafe.Migrations
{
    public partial class table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_type",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "specials",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AD_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Specials = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specials", x => x.ID);
                    table.ForeignKey(
                        name: "FK_specials_User_type_AD_id",
                        column: x => x.AD_id,
                        principalTable: "User_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Admin_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    U_Typeid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone_Num = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_Id);
                    table.ForeignKey(
                        name: "FK_User_User_type_U_Typeid",
                        column: x => x.U_Typeid,
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
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    U_IDUser_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_User_U_IDUser_Id",
                        column: x => x.U_IDUser_Id,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match_History",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_History_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "User_Id",
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
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_U_IDUser_Id",
                table: "Comments",
                column: "U_IDUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Match_History_userid",
                table: "Match_History",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_NFC_Userid",
                table: "NFC",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_specials_AD_id",
                table: "specials",
                column: "AD_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_U_Typeid",
                table: "User",
                column: "U_Typeid");

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
                name: "specials");

            migrationBuilder.DropTable(
                name: "Usertype_pages");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "User_type");
        }
    }
}
