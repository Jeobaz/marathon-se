using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class MigrateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charity",
                columns: table => new
                {
                    CharityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharityName = table.Column<string>(maxLength: 100, nullable: false),
                    CharityDescription = table.Column<string>(maxLength: 2000, nullable: true),
                    CharityLogo = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charity", x => x.CharityId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryCode = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false),
                    CountryName = table.Column<string>(maxLength: 100, nullable: false),
                    CountryFlag = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Country", x => x.CountryCode);
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    EventTypeId = table.Column<string>(fixedLength: true, maxLength: 2, nullable: false),
                    EventTypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.EventTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Gender = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Gender", x => x.Gender);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PositionId = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(maxLength: 50, nullable: false),
                    PositionDescription = table.Column<string>(maxLength: 1000, nullable: true),
                    Payrate = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "RaceKitOption",
                columns: table => new
                {
                    RaceKitOptionId = table.Column<string>(fixedLength: true, maxLength: 1, nullable: false),
                    RaceKitOption = table.Column<string>(maxLength: 80, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceKitOption", x => x.RaceKitOptionId);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationStatus",
                columns: table => new
                {
                    RegistrationStatusId = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationStatus = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationStatus", x => x.RegistrationStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<string>(fixedLength: true, maxLength: 1, nullable: false),
                    RoleName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Timesheet",
                columns: table => new
                {
                    TimesheetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    PayAmount = table.Column<decimal>(type: "decimal(10, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheet", x => x.TimesheetId);
                });

            migrationBuilder.CreateTable(
                name: "Marathon",
                columns: table => new
                {
                    MarathonId = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarathonName = table.Column<string>(maxLength: 80, nullable: false),
                    CityName = table.Column<string>(maxLength: 80, nullable: true),
                    CountryCode = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false),
                    YearHeld = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marathon", x => x.MarathonId);
                    table.ForeignKey(
                        name: "FK__Marathon__Countr__7A672E12",
                        column: x => x.CountryCode,
                        principalTable: "Country",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    VolunteerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 80, nullable: true),
                    LastName = table.Column<string>(maxLength: 80, nullable: true),
                    CountryCode = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false),
                    Gender = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.VolunteerId);
                    table.ForeignKey(
                        name: "FK__Volunteer__Count__571DF1D5",
                        column: x => x.CountryCode,
                        principalTable: "Country",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Volunteer__Gende__5629CD9C",
                        column: x => x.Gender,
                        principalTable: "Gender",
                        principalColumn: "Gender",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 80, nullable: false),
                    LastName = table.Column<string>(maxLength: 80, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    Gender = table.Column<string>(maxLength: 10, nullable: false),
                    PostionId = table.Column<byte>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Comments = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staff_Position_PositionId",
                        column: x => x.PostionId,
                        principalTable: "Position",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(maxLength: 80, nullable: true),
                    LastName = table.Column<string>(maxLength: 80, nullable: true),
                    RoleId = table.Column<string>(fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_User", x => x.Email);
                    table.ForeignKey(
                        name: "FK__User__RoleId__7B5B524B",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<string>(fixedLength: true, maxLength: 6, nullable: false),
                    EventName = table.Column<string>(maxLength: 50, nullable: false),
                    EventTypeId = table.Column<string>(fixedLength: true, maxLength: 2, nullable: false),
                    MarathonId = table.Column<byte>(nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    MaxParticipants = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                    table.ForeignKey(
                        name: "FK__Event__EventType__74AE54BC",
                        column: x => x.EventTypeId,
                        principalTable: "EventType",
                        principalColumn: "EventTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Event__MarathonI__75A278F5",
                        column: x => x.MarathonId,
                        principalTable: "Marathon",
                        principalColumn: "MarathonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Runner",
                columns: table => new
                {
                    RunnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Gender = table.Column<string>(maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    CountryCode = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runner", x => x.RunnerId);
                    table.ForeignKey(
                        name: "FK__Runner__CountryC__5535A963",
                        column: x => x.CountryCode,
                        principalTable: "Country",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Runner__Email__7C4F7684",
                        column: x => x.Email,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Runner__Gender__7D439ABD",
                        column: x => x.Gender,
                        principalTable: "Gender",
                        principalColumn: "Gender",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RunnerId = table.Column<int>(nullable: false),
                    RegistrationDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    RaceKitOptionId = table.Column<string>(fixedLength: true, maxLength: 1, nullable: false),
                    RegistrationStatusId = table.Column<byte>(nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    CharityId = table.Column<int>(nullable: false),
                    SponsorshipTarget = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK__Registrat__Chari__71D1E811",
                        column: x => x.CharityId,
                        principalTable: "Charity",
                        principalColumn: "CharityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Registrat__RaceK__6FE99F9F",
                        column: x => x.RaceKitOptionId,
                        principalTable: "RaceKitOption",
                        principalColumn: "RaceKitOptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Registrat__Regis__70DDC3D8",
                        column: x => x.RegistrationStatusId,
                        principalTable: "RegistrationStatus",
                        principalColumn: "RegistrationStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Registrat__Runne__6A30C649",
                        column: x => x.RunnerId,
                        principalTable: "Runner",
                        principalColumn: "RunnerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationEvent",
                columns: table => new
                {
                    RegistrationEventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(nullable: false),
                    EventId = table.Column<string>(fixedLength: true, maxLength: 6, nullable: false),
                    BibNumber = table.Column<short>(nullable: true),
                    RaceTime = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationEvent", x => x.RegistrationEventId);
                    table.ForeignKey(
                        name: "FK__Registrat__Event__797309D9",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Registrat__Regis__778AC167",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sponsorship",
                columns: table => new
                {
                    SponsorshipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SponsorName = table.Column<string>(maxLength: 150, nullable: false),
                    RegistrationId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsorship", x => x.SponsorshipId);
                    table.ForeignKey(
                        name: "FK__Sponsorsh__Regis__72C60C4A",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventTypeId",
                table: "Event",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_MarathonId",
                table: "Event",
                column: "MarathonId");

            migrationBuilder.CreateIndex(
                name: "IX_Marathon_CountryCode",
                table: "Marathon",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_CharityId",
                table: "Registration",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_RaceKitOptionId",
                table: "Registration",
                column: "RaceKitOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_RegistrationStatusId",
                table: "Registration",
                column: "RegistrationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_RunnerId",
                table: "Registration",
                column: "RunnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationEvent_EventId",
                table: "RegistrationEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationEvent_RegistrationId",
                table: "RegistrationEvent",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Runner_CountryCode",
                table: "Runner",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Runner_Email",
                table: "Runner",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Runner_Gender",
                table: "Runner",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsorship_RegistrationId",
                table: "Sponsorship",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_PostionId",
                table: "Staff",
                column: "PostionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_CountryCode",
                table: "Volunteer",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_Gender",
                table: "Volunteer",
                column: "Gender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationEvent");

            migrationBuilder.DropTable(
                name: "Sponsorship");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Timesheet");

            migrationBuilder.DropTable(
                name: "Volunteer");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropTable(
                name: "Marathon");

            migrationBuilder.DropTable(
                name: "Charity");

            migrationBuilder.DropTable(
                name: "RaceKitOption");

            migrationBuilder.DropTable(
                name: "RegistrationStatus");

            migrationBuilder.DropTable(
                name: "Runner");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
