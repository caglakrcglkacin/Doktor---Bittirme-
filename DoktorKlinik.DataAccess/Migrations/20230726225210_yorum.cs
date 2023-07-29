using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoktorKlinik.DataAccess.Migrations
{
    public partial class yorum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YorumYapıldımı",
                table: "AppointmentGet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bc74178c-26bc-4c1d-a6b9-1bec59102b97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d53153d8-0ccf-45f2-80cb-726ca23a4add");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "d6a55dee-64b0-4ecf-9147-aaf5d6b35ca4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YorumYapıldımı",
                table: "AppointmentGet");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "95f35e1b-ddea-4b35-adad-0fe424583830");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "99642a1f-46a9-40b1-9448-183e723ff9a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "497905e1-10fe-4049-b367-b26ea028fe85");
        }
    }
}
