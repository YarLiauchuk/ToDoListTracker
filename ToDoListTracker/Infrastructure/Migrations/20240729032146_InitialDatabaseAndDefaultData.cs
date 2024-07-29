using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoListTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseAndDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PriorityId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PriorityId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoItems_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ToDoItems_Priorities_PriorityId1",
                        column: x => x.PriorityId1,
                        principalTable: "Priorities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ToDoItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoItems_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Level" },
                values: new object[,]
                {
                    { new Guid("14a32d34-9241-4040-bc9d-e438530810de"), 3 },
                    { new Guid("1998214e-0fea-4673-b736-6bf6b87de8da"), 2 },
                    { new Guid("3ec8efa0-5305-403f-adfe-644051f4e476"), 4 },
                    { new Guid("4396a607-4fa1-4ce6-9378-69b6db56e963"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("23c59c51-5ab1-4a0e-8374-89f7d5323295"), "Helena" },
                    { new Guid("63a16261-755c-42d9-b490-c1bfbb93f18d"), "Jonh" },
                    { new Guid("6ba91f37-5e9d-425b-bdc7-b498437098ee"), "Ivan" },
                    { new Guid("f283ce82-f941-4068-acc2-a788ffd4b634"), "Alex" }
                });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "Description", "DueDate", "IsCompleted", "IsDeleted", "PriorityId", "PriorityId1", "Title", "UserId", "UserId1" },
                values: new object[,]
                {
                    { new Guid("0fcd221c-3cc4-42ba-819d-2ee157a745ec"), null, new DateTime(2024, 7, 29, 3, 21, 46, 199, DateTimeKind.Utc).AddTicks(9157), true, false, new Guid("14a32d34-9241-4040-bc9d-e438530810de"), null, "Something", new Guid("23c59c51-5ab1-4a0e-8374-89f7d5323295"), null },
                    { new Guid("84d15eb3-036a-4f15-832c-418b0ac9d047"), null, new DateTime(2024, 7, 29, 3, 21, 46, 199, DateTimeKind.Utc).AddTicks(9143), false, false, new Guid("4396a607-4fa1-4ce6-9378-69b6db56e963"), null, "Household chores", new Guid("6ba91f37-5e9d-425b-bdc7-b498437098ee"), null },
                    { new Guid("bd4e74b9-6728-4233-99e7-976799932854"), null, new DateTime(2024, 7, 29, 3, 21, 46, 199, DateTimeKind.Utc).AddTicks(9160), true, false, new Guid("3ec8efa0-5305-403f-adfe-644051f4e476"), null, "Relax", new Guid("63a16261-755c-42d9-b490-c1bfbb93f18d"), null },
                    { new Guid("fcfe54f0-7b06-48ce-a636-eec4457e725f"), null, new DateTime(2024, 7, 29, 3, 21, 46, 199, DateTimeKind.Utc).AddTicks(9153), false, false, new Guid("1998214e-0fea-4673-b736-6bf6b87de8da"), null, "Work task", new Guid("f283ce82-f941-4068-acc2-a788ffd4b634"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_PriorityId",
                table: "ToDoItems",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_PriorityId1",
                table: "ToDoItems",
                column: "PriorityId1");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_UserId",
                table: "ToDoItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_UserId1",
                table: "ToDoItems",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItems");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
