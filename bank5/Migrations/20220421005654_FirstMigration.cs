using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bank5.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillCreations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    BankName = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillCreations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Duration = table.Column<string>(type: "TEXT", nullable: false),
                    Procent = table.Column<int>(type: "INTEGER", nullable: false),
                    BankId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FactoryType = table.Column<string>(type: "TEXT", nullable: true),
                    UNP = table.Column<string>(type: "TEXT", nullable: true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    UrlAdress = table.Column<string>(type: "TEXT", nullable: true),
                    IsBank = table.Column<bool>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Procent = table.Column<string>(type: "TEXT", nullable: false),
                    BankId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FromId = table.Column<int>(type: "INTEGER", nullable: false),
                    ToId = table.Column<int>(type: "INTEGER", nullable: false),
                    Money = table.Column<int>(type: "INTEGER", nullable: false),
                    Display = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    SecondName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    SeriesAndPassportNumber = table.Column<string>(type: "TEXT", nullable: true),
                    IdentificationNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    FactoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsAproved = table.Column<bool>(type: "INTEGER", nullable: true),
                    OneOperation = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Money = table.Column<double>(type: "REAL", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    FactoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    State = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Factories_BankId",
                        column: x => x.BankId,
                        principalTable: "Factories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bills_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Money = table.Column<double>(type: "REAL", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    BankId = table.Column<int>(type: "INTEGER", nullable: false),
                    BillId = table.Column<int>(type: "INTEGER", nullable: false),
                    Percent = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<string>(type: "TEXT", nullable: false),
                    EndTime = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credits_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deposit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Money = table.Column<double>(type: "REAL", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposit_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Money = table.Column<double>(type: "REAL", nullable: false),
                    BankId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<string>(type: "TEXT", nullable: false),
                    EndTime = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plans_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestMonies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    BillId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsAproved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestMonies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestMonies_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestMonies_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Duration", "Procent" },
                values: new object[] { 1, 1, "3", 10 });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Duration", "Procent" },
                values: new object[] { 2, 1, "6", 200 });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Duration", "Procent" },
                values: new object[] { 3, 1, "12", 50 });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Duration", "Procent" },
                values: new object[] { 4, 1, "24", 11 });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Duration", "Procent" },
                values: new object[] { 5, 1, ">24", 12 });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Duration", "Procent" },
                values: new object[] { 6, 2, "3", 13 });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Duration", "Procent" },
                values: new object[] { 7, 2, "6", 100 });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Duration", "Procent" },
                values: new object[] { 8, 2, "12", 1 });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Duration", "Procent" },
                values: new object[] { 9, 2, "24", 2000 });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Duration", "Procent" },
                values: new object[] { 10, 2, ">24", 2 });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Duration", "Procent" },
                values: new object[] { 11, 3, "3", 3 });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Duration", "Procent" },
                values: new object[] { 12, 3, "6", 2 });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Duration", "Procent" },
                values: new object[] { 13, 3, "12", 10 });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Duration", "Procent" },
                values: new object[] { 14, 3, "24", 10 });

            migrationBuilder.InsertData(
                table: "CreditInfos",
                columns: new[] { "Id", "BankId", "Duration", "Procent" },
                values: new object[] { 15, 3, ">24", 10 });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "IsBank", "Name", "UNP", "UrlAdress" },
                values: new object[] { 1, 1, "Bank", null, true, "PriorBank", null, null });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "IsBank", "Name", "UNP", "UrlAdress" },
                values: new object[] { 2, 2, "Bank", null, true, "MTBank", null, null });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "IsBank", "Name", "UNP", "UrlAdress" },
                values: new object[] { 3, 3, "Bank", null, true, "BelWeb", null, null });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "IsBank", "Name", "UNP", "UrlAdress" },
                values: new object[] { 4, 1, "Factory", "Rabotygi", false, "Super Compony", "supercode", "rabotygi.com" });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "IsBank", "Name", "UNP", "UrlAdress" },
                values: new object[] { 5, 2, "Factory", "NotRabotygi", false, "Mega Compony", "megacode", "notrabotygi.com" });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "IsBank", "Name", "UNP", "UrlAdress" },
                values: new object[] { 6, 3, "Factory", "students", false, "BSUIR Compony", "student.com", "students.com" });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "IsBank", "Name", "UNP", "UrlAdress" },
                values: new object[] { 7, 1, "Factory", "nones", false, "Noone Compony", "nonecode", "nones.com" });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "BankId", "Discriminator", "FactoryType", "IsBank", "Name", "UNP", "UrlAdress" },
                values: new object[] { 8, 2, "Factory", "fucks", false, "Fuck Compony", "fuckcode", "fucks.com" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "user" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "client" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "specialist" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "manager" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "operator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "FirstName", "IdentificationNumber", "LastName", "Password", "PhoneNumber", "RoleId", "SecondName", "SeriesAndPassportNumber" },
                values: new object[] { 123, "User", null, null, null, null, null, null, 1, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BankId",
                table: "Bills",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ClientId",
                table: "Bills",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_ClientId",
                table: "Credits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposit_ClientId",
                table: "Deposit",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_ClientId",
                table: "Plans",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestMonies_BillId",
                table: "RequestMonies",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestMonies_ClientId",
                table: "RequestMonies",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillCreations");

            migrationBuilder.DropTable(
                name: "CreditInfos");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "Deposit");

            migrationBuilder.DropTable(
                name: "PlanInfos");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "RequestMonies");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Factories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
