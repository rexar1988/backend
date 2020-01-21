using Microsoft.EntityFrameworkCore.Migrations;

namespace Campus.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NodeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    MachineName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Instructions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    NodeTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nodes_NodeTypes_NodeTypeId",
                        column: x => x.NodeTypeId,
                        principalTable: "NodeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NodeTypes",
                columns: new[] { "Id", "Description", "Instructions", "MachineName", "Name" },
                values: new object[] { 1, "Simple page for node type Page", "Удобочитаемое название типа материалов. Этот текст будет показан в списке на странице создания материала. Рекомендуется использовать названия, начинающиеся с прописной буквы и состоящие только из букв, цифр и пробелов. Название должно быть уникальным.", "page", "Page" });

            migrationBuilder.InsertData(
                table: "NodeTypes",
                columns: new[] { "Id", "Description", "Instructions", "MachineName", "Name" },
                values: new object[] { 2, "Simple article for node type Article", "Удобочитаемое название типа материалов. Этот текст будет показан в списке на странице создания материала. Рекомендуется использовать названия, начинающиеся с прописной буквы и состоящие только из букв, цифр и пробелов. Название должно быть уникальным.", "article", "Article" });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "Body", "MetaDescription", "MetaTitle", "NodeTypeId", "Title", "Url" },
                values: new object[] { 1, "Node Type Body 1", "Node type Description 1", "Node title 1", 1, "Node Title 1", "url-1" });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "Body", "MetaDescription", "MetaTitle", "NodeTypeId", "Title", "Url" },
                values: new object[] { 2, "Node Type Body 1", "Node type Description 1", "Node title 1", 1, "Node Title 1", "url-1" });

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_NodeTypeId",
                table: "Nodes",
                column: "NodeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "NodeTypes");
        }
    }
}
