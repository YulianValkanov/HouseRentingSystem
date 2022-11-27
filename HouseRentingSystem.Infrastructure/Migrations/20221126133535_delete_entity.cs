using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class delete_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Houses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "f9e568bf-34cd-4049-bcbc-48d40ad696e1", "AQAAAAEAACcQAAAAECAr6xLqAmrOTxsaAZTnJdjDT9xlvrprwAbELidIavjOBE/5RnU9sDYojjiRU/snmw==", "5b88fec2-c5a9-4da3-b1dc-4782735a468b" });

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "72ffc57e-3bd6-401e-bd2a-09f6fc9bcd7c", "AQAAAAEAACcQAAAAEPJqtSUn42Yoxg4Dq4Sz0tJZUDbU/BdOxx/PCPoGk97bAIF7ncg1Jxgh71+zAUUmKA==", "01946876-3ac2-4913-828f-ae8f614a997f" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "isActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Houses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7e16de4-65d1-46ba-9a32-874db17307ce", "AQAAAAEAACcQAAAAEJe5ToOtIujua2j3piv3To13nOgSR9rCECOj43y0M1Q53EYmOEgFkMUpeInYhbiWVw==", "df022d20-0466-4102-984e-0c587a8afd95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20f49647-b737-4d85-85d5-7fa1c758f058", "AQAAAAEAACcQAAAAELJc+lAB352JOraJk1ZNxPH3cLEhhp2lDdKbEk2LCYBDZ0EwhAMWvYCrMtrS/Wj6Mw==", "ef95d5ed-1c0b-487e-b35e-0b6a55254172" });
        }
    }
}
