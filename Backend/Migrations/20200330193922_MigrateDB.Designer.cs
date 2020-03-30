﻿// <auto-generated />
using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(marathonseContext))]
    [Migration("20200330193922_MigrateDB")]
    partial class MigrateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.Models.Charity", b =>
                {
                    b.Property<int>("CharityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CharityDescription")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("CharityLogo")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CharityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("CharityId");

                    b.ToTable("Charity");
                });

            modelBuilder.Entity("Backend.Models.Country", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasColumnType("nchar(3)")
                        .IsFixedLength(true)
                        .HasMaxLength(3);

                    b.Property<string>("CountryFlag")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("CountryCode")
                        .HasName("pk_Country");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Backend.Models.Event", b =>
                {
                    b.Property<string>("EventId")
                        .HasColumnType("nchar(6)")
                        .IsFixedLength(true)
                        .HasMaxLength(6);

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("EventTypeId")
                        .IsRequired()
                        .HasColumnType("nchar(2)")
                        .IsFixedLength(true)
                        .HasMaxLength(2);

                    b.Property<byte>("MarathonId")
                        .HasColumnType("tinyint");

                    b.Property<short?>("MaxParticipants")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("StartDateTime")
                        .HasColumnType("datetime");

                    b.HasKey("EventId");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("MarathonId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("Backend.Models.EventType", b =>
                {
                    b.Property<string>("EventTypeId")
                        .HasColumnType("nchar(2)")
                        .IsFixedLength(true)
                        .HasMaxLength(2);

                    b.Property<string>("EventTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("EventTypeId");

                    b.ToTable("EventType");
                });

            modelBuilder.Entity("Backend.Models.Gender", b =>
                {
                    b.Property<string>("Gender1")
                        .HasColumnName("Gender")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Gender1")
                        .HasName("pk_Gender");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("Backend.Models.Marathon", b =>
                {
                    b.Property<byte>("MarathonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nchar(3)")
                        .IsFixedLength(true)
                        .HasMaxLength(3);

                    b.Property<string>("MarathonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<short?>("YearHeld")
                        .HasColumnType("smallint");

                    b.HasKey("MarathonId");

                    b.HasIndex("CountryCode");

                    b.ToTable("Marathon");
                });

            modelBuilder.Entity("Backend.Models.Position", b =>
                {
                    b.Property<byte>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Payrate")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("PositionDescription")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("PositionId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("Backend.Models.RaceKitOption", b =>
                {
                    b.Property<string>("RaceKitOptionId")
                        .HasColumnType("nchar(1)")
                        .IsFixedLength(true)
                        .HasMaxLength(1);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("RaceKitOption1")
                        .IsRequired()
                        .HasColumnName("RaceKitOption")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("RaceKitOptionId");

                    b.ToTable("RaceKitOption");
                });

            modelBuilder.Entity("Backend.Models.Registration", b =>
                {
                    b.Property<int>("RegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharityId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("RaceKitOptionId")
                        .IsRequired()
                        .HasColumnType("nchar(1)")
                        .IsFixedLength(true)
                        .HasMaxLength(1);

                    b.Property<DateTime>("RegistrationDateTime")
                        .HasColumnType("datetime");

                    b.Property<byte>("RegistrationStatusId")
                        .HasColumnType("tinyint");

                    b.Property<int>("RunnerId")
                        .HasColumnType("int");

                    b.Property<decimal>("SponsorshipTarget")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("RegistrationId");

                    b.HasIndex("CharityId");

                    b.HasIndex("RaceKitOptionId");

                    b.HasIndex("RegistrationStatusId");

                    b.HasIndex("RunnerId");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("Backend.Models.RegistrationEvent", b =>
                {
                    b.Property<int>("RegistrationEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short?>("BibNumber")
                        .HasColumnType("smallint");

                    b.Property<string>("EventId")
                        .IsRequired()
                        .HasColumnType("nchar(6)")
                        .IsFixedLength(true)
                        .HasMaxLength(6);

                    b.Property<int?>("RaceTime")
                        .HasColumnType("int");

                    b.Property<int>("RegistrationId")
                        .HasColumnType("int");

                    b.HasKey("RegistrationEventId");

                    b.HasIndex("EventId");

                    b.HasIndex("RegistrationId");

                    b.ToTable("RegistrationEvent");
                });

            modelBuilder.Entity("Backend.Models.RegistrationStatus", b =>
                {
                    b.Property<byte>("RegistrationStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RegistrationStatus1")
                        .IsRequired()
                        .HasColumnName("RegistrationStatus")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("RegistrationStatusId");

                    b.ToTable("RegistrationStatus");
                });

            modelBuilder.Entity("Backend.Models.Role", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nchar(1)")
                        .IsFixedLength(true)
                        .HasMaxLength(1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Backend.Models.Runner", b =>
                {
                    b.Property<int>("RunnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nchar(3)")
                        .IsFixedLength(true)
                        .HasMaxLength(3);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("RunnerId");

                    b.HasIndex("CountryCode");

                    b.HasIndex("Email");

                    b.HasIndex("Gender");

                    b.ToTable("Runner");
                });

            modelBuilder.Entity("Backend.Models.Sponsorship", b =>
                {
                    b.Property<int>("SponsorshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("RegistrationId")
                        .HasColumnType("int");

                    b.Property<string>("SponsorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("SponsorshipId");

                    b.HasIndex("RegistrationId");

                    b.ToTable("Sponsorship");
                });

            modelBuilder.Entity("Backend.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<byte>("PostionId")
                        .HasColumnType("tinyint");

                    b.HasKey("StaffId");

                    b.HasIndex("PostionId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("Backend.Models.Timesheet", b =>
                {
                    b.Property<int>("TimesheetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDateTime")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("PayAmount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDateTime")
                        .HasColumnType("datetime");

                    b.HasKey("TimesheetId");

                    b.ToTable("Timesheet");
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nchar(1)")
                        .IsFixedLength(true)
                        .HasMaxLength(1);

                    b.HasKey("Email")
                        .HasName("pk_User");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Backend.Models.Volunteer", b =>
                {
                    b.Property<int>("VolunteerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nchar(3)")
                        .IsFixedLength(true)
                        .HasMaxLength(3);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("VolunteerId");

                    b.HasIndex("CountryCode");

                    b.HasIndex("Gender");

                    b.ToTable("Volunteer");
                });

            modelBuilder.Entity("Backend.Models.Event", b =>
                {
                    b.HasOne("Backend.Models.EventType", "EventType")
                        .WithMany("Event")
                        .HasForeignKey("EventTypeId")
                        .HasConstraintName("FK__Event__EventType__74AE54BC")
                        .IsRequired();

                    b.HasOne("Backend.Models.Marathon", "Marathon")
                        .WithMany("Event")
                        .HasForeignKey("MarathonId")
                        .HasConstraintName("FK__Event__MarathonI__75A278F5")
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.Marathon", b =>
                {
                    b.HasOne("Backend.Models.Country", "CountryCodeNavigation")
                        .WithMany("Marathon")
                        .HasForeignKey("CountryCode")
                        .HasConstraintName("FK__Marathon__Countr__7A672E12")
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.Registration", b =>
                {
                    b.HasOne("Backend.Models.Charity", "Charity")
                        .WithMany("Registration")
                        .HasForeignKey("CharityId")
                        .HasConstraintName("FK__Registrat__Chari__71D1E811")
                        .IsRequired();

                    b.HasOne("Backend.Models.RaceKitOption", "RaceKitOption")
                        .WithMany("Registration")
                        .HasForeignKey("RaceKitOptionId")
                        .HasConstraintName("FK__Registrat__RaceK__6FE99F9F")
                        .IsRequired();

                    b.HasOne("Backend.Models.RegistrationStatus", "RegistrationStatus")
                        .WithMany("Registration")
                        .HasForeignKey("RegistrationStatusId")
                        .HasConstraintName("FK__Registrat__Regis__70DDC3D8")
                        .IsRequired();

                    b.HasOne("Backend.Models.Runner", "Runner")
                        .WithMany("Registration")
                        .HasForeignKey("RunnerId")
                        .HasConstraintName("FK__Registrat__Runne__6A30C649")
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.RegistrationEvent", b =>
                {
                    b.HasOne("Backend.Models.Event", "Event")
                        .WithMany("RegistrationEvent")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK__Registrat__Event__797309D9")
                        .IsRequired();

                    b.HasOne("Backend.Models.Registration", "Registration")
                        .WithMany("RegistrationEvent")
                        .HasForeignKey("RegistrationId")
                        .HasConstraintName("FK__Registrat__Regis__778AC167")
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.Runner", b =>
                {
                    b.HasOne("Backend.Models.Country", "CountryCodeNavigation")
                        .WithMany("Runner")
                        .HasForeignKey("CountryCode")
                        .HasConstraintName("FK__Runner__CountryC__5535A963")
                        .IsRequired();

                    b.HasOne("Backend.Models.User", "EmailNavigation")
                        .WithMany("Runner")
                        .HasForeignKey("Email")
                        .HasConstraintName("FK__Runner__Email__7C4F7684")
                        .IsRequired();

                    b.HasOne("Backend.Models.Gender", "GenderNavigation")
                        .WithMany("Runner")
                        .HasForeignKey("Gender")
                        .HasConstraintName("FK__Runner__Gender__7D439ABD")
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.Sponsorship", b =>
                {
                    b.HasOne("Backend.Models.Registration", "Registration")
                        .WithMany("Sponsorship")
                        .HasForeignKey("RegistrationId")
                        .HasConstraintName("FK__Sponsorsh__Regis__72C60C4A")
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.Staff", b =>
                {
                    b.HasOne("Backend.Models.Position", "Postion")
                        .WithMany("Staff")
                        .HasForeignKey("PostionId")
                        .HasConstraintName("FK_Staff_Position_PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.HasOne("Backend.Models.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__User__RoleId__7B5B524B")
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.Volunteer", b =>
                {
                    b.HasOne("Backend.Models.Country", "CountryCodeNavigation")
                        .WithMany("Volunteer")
                        .HasForeignKey("CountryCode")
                        .HasConstraintName("FK__Volunteer__Count__571DF1D5")
                        .IsRequired();

                    b.HasOne("Backend.Models.Gender", "GenderNavigation")
                        .WithMany("Volunteer")
                        .HasForeignKey("Gender")
                        .HasConstraintName("FK__Volunteer__Gende__5629CD9C")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
