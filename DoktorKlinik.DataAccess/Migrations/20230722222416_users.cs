using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoktorKlinik.DataAccess.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderCode = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlinikId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_AspNetUsers_KlinikId",
                        column: x => x.KlinikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    KlinikUserId = table.Column<int>(type: "int", nullable: false),
                    BolumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctor_AspNetUsers_KlinikUserId",
                        column: x => x.KlinikUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctor_Part_BolumId",
                        column: x => x.BolumId,
                        principalTable: "Part",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    DateOnly = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOnly = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointment_Part_PartId",
                        column: x => x.PartId,
                        principalTable: "Part",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppointmentGet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentGet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentGet_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppointmentGet_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DoctorComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "varchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorComment_AppointmentGet_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "AppointmentGet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "varchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientInfo_AppointmentGet_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "AppointmentGet",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "d5f1afaa-13c4-4ef7-a17f-c896aa8fb8ea", "Admin", "ADMIN" },
                    { 2, "1eba838f-706c-4317-ae83-ada1ebf87af1", "Doktor", "DOKTOR" },
                    { 3, "ea336a44-e8a7-4eb0-8cf0-2ce517db4fcd", "Hasta", "HASTA" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, " TÜRKİYE" },
                    { 2, " ALMANYA" },
                    { 3, " AMERİKA BİRLEŞİK DEVLETLERİ" },
                    { 4, " AMERİKAN SAMOASI (ABD)" },
                    { 5, " ANDORRA" },
                    { 6, " ANGOLA" },
                    { 7, "  ANGUİLLA (Birleşik Krallık)" },
                    { 8, " ANTİGUA ve BARBUDA" },
                    { 9, " ARJANTİN" },
                    { 10, "  ARNAVUTLUK" },
                    { 11, " ARUBA (Hollanda)" },
                    { 12, "  AVUSTRALYA" },
                    { 13, " AZERBAYCAN" },
                    { 14, " BELÇİKA" },
                    { 15, "  BULGARİSTAN" },
                    { 16, " Çin" },
                    { 17, "  Yunanistan" },
                    { 18, " AFGANİSTAN" },
                    { 19, " Rusya" },
                    { 20, " İtalya" }
                });

            migrationBuilder.InsertData(
                table: "Part",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, " Endodonti" },
                    { 2, " Periodontoloji" },
                    { 3, " Ağız ve Çene Cerrahisi" },
                    { 4, " ‌İmplantoloji " },
                    { 5, " Estetik Diş Hekimliği" },
                    { 6, " ‌Protez " },
                    { 7, " Ortodonti " }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Adana" },
                    { 2, 1, "Adıyaman" },
                    { 3, 1, "Afyon" },
                    { 4, 1, "Ağrı" },
                    { 5, 1, "Aksaray" },
                    { 6, 1, "Amasya" },
                    { 7, 1, "Ankara" },
                    { 8, 1, "Antalya" },
                    { 9, 1, "Ardahan" },
                    { 10, 1, "Artvin" },
                    { 11, 1, "Aydın" },
                    { 12, 1, "Balıkesir" },
                    { 13, 1, "Bartın" },
                    { 14, 1, "Batman" },
                    { 15, 1, "Bayburt" },
                    { 16, 1, "Bilecik" },
                    { 17, 1, "Bingöl" },
                    { 18, 1, "Bitlis" },
                    { 19, 1, "Bolu" },
                    { 20, 1, "Burdur" },
                    { 21, 1, "Bursa" },
                    { 22, 1, "Çanakkale" },
                    { 23, 1, "Çankırı" },
                    { 24, 1, "Çorum" },
                    { 25, 1, "Denizli" },
                    { 26, 1, "Diyarbakır" },
                    { 27, 1, "Düzce" },
                    { 28, 1, "Edirne" },
                    { 29, 1, "Elazığ" },
                    { 30, 1, "Erzincan" },
                    { 31, 1, "Erzurum" },
                    { 32, 1, "Eskişehir" },
                    { 33, 1, "Gaziantep" },
                    { 34, 1, "Giresun" },
                    { 35, 1, "Gümüşhane" },
                    { 36, 1, "Hakkari" },
                    { 37, 1, "Hatay" },
                    { 38, 1, "Iğdır" },
                    { 39, 1, "Isparta" },
                    { 40, 1, "İstanbul" },
                    { 41, 1, "İzmir" },
                    { 42, 1, "Kahramanmaraş" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 43, 1, "Karabük" },
                    { 44, 1, "Karaman" },
                    { 45, 1, "Kars" },
                    { 46, 1, "Kastamonu" },
                    { 47, 1, "Kayseri" },
                    { 48, 1, "Kırıkkale" },
                    { 49, 1, "Kırklareli" },
                    { 50, 1, "Kırşehir" },
                    { 51, 1, "Kilis" },
                    { 52, 1, "Kocaeli" },
                    { 53, 1, "Konya" },
                    { 54, 1, "Kütahya" },
                    { 55, 1, "Malatya" },
                    { 56, 1, "Manisa" },
                    { 57, 1, "Mardin" },
                    { 58, 1, "Mersin" },
                    { 59, 1, "Muğla" },
                    { 60, 1, "Muş" },
                    { 61, 1, "Nevşehir" },
                    { 62, 1, "Niğde" },
                    { 63, 1, "Ordu" },
                    { 64, 1, "Osmaniye" },
                    { 65, 1, "Rize" },
                    { 66, 1, "Sakarya" },
                    { 67, 1, "Samsun" },
                    { 68, 1, "Siirt" },
                    { 69, 1, "Sinop" },
                    { 70, 1, "Sivas" },
                    { 71, 1, "Şanlıurfa" },
                    { 72, 1, "Şırnak" },
                    { 73, 1, "Tekirdağ" },
                    { 74, 1, "Tokat" },
                    { 75, 1, "Trabzon" },
                    { 76, 1, "Tunceli" },
                    { 77, 1, "Uşak" },
                    { 78, 1, "Van" },
                    { 79, 1, "Yalova" },
                    { 80, 1, "Yozgat" },
                    { 81, 1, "Zonguldak" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorId",
                table: "Appointment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PartId",
                table: "Appointment",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentGet_AppointmentId",
                table: "AppointmentGet",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentGet_PatientId",
                table: "AppointmentGet",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_BolumId",
                table: "Doctor",
                column: "BolumId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_KlinikUserId",
                table: "Doctor",
                column: "KlinikUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_RoleId",
                table: "Doctor",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorComment_AppointmentId",
                table: "DoctorComment",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInfo_AppointmentId",
                table: "PatientInfo",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_KlinikId",
                table: "Patients",
                column: "KlinikId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_RoleId",
                table: "Patients",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "DoctorComment");

            migrationBuilder.DropTable(
                name: "PatientInfo");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "AppointmentGet");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Part");
        }
    }
}
