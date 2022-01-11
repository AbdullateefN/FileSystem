using Microsoft.EntityFrameworkCore.Migrations;

namespace FileSystem.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Folders_FolderId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "IdAnotherFolder",
                table: "Folders");

            migrationBuilder.AddColumn<int>(
                name: "FolderParentId",
                table: "Folders",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FolderId",
                table: "Files",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_FolderParentId",
                table: "Folders",
                column: "FolderParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Folders_FolderId",
                table: "Files",
                column: "FolderId",
                principalTable: "Folders",
                principalColumn: "FolderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Folders_FolderParentId",
                table: "Folders",
                column: "FolderParentId",
                principalTable: "Folders",
                principalColumn: "FolderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Folders_FolderId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Folders_FolderParentId",
                table: "Folders");

            migrationBuilder.DropIndex(
                name: "IX_Folders_FolderParentId",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "FolderParentId",
                table: "Folders");

            migrationBuilder.AddColumn<int>(
                name: "IdAnotherFolder",
                table: "Folders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FolderId",
                table: "Files",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Folders_FolderId",
                table: "Files",
                column: "FolderId",
                principalTable: "Folders",
                principalColumn: "FolderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
