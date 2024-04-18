﻿// <auto-generated />
using System;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240418095852_incidenttestseed")]
    partial class incidenttestseed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.HelpDesk.AmbitsToTypes", b =>
                {
                    b.Property<int>("AmbitId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("AmbitId", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("AmbitsToTypes");

                    b.HasData(
                        new
                        {
                            AmbitId = 3,
                            TypeId = 1
                        },
                        new
                        {
                            AmbitId = 3,
                            TypeId = 2
                        },
                        new
                        {
                            AmbitId = 2,
                            TypeId = 2
                        },
                        new
                        {
                            AmbitId = 2,
                            TypeId = 3
                        },
                        new
                        {
                            AmbitId = 4,
                            TypeId = 4
                        },
                        new
                        {
                            AmbitId = 1,
                            TypeId = 4
                        },
                        new
                        {
                            AmbitId = 1,
                            TypeId = 5
                        },
                        new
                        {
                            AmbitId = 1,
                            TypeId = 1
                        },
                        new
                        {
                            AmbitId = 1,
                            TypeId = 6
                        },
                        new
                        {
                            AmbitId = 1,
                            TypeId = 3
                        },
                        new
                        {
                            AmbitId = 1,
                            TypeId = 7
                        },
                        new
                        {
                            AmbitId = 5,
                            TypeId = 3
                        },
                        new
                        {
                            AmbitId = 6,
                            TypeId = 2
                        },
                        new
                        {
                            AmbitId = 6,
                            TypeId = 7
                        },
                        new
                        {
                            AmbitId = 6,
                            TypeId = 1
                        },
                        new
                        {
                            AmbitId = 7,
                            TypeId = 8
                        },
                        new
                        {
                            AmbitId = 7,
                            TypeId = 1
                        },
                        new
                        {
                            AmbitId = 8,
                            TypeId = 9
                        },
                        new
                        {
                            AmbitId = 8,
                            TypeId = 8
                        },
                        new
                        {
                            AmbitId = 8,
                            TypeId = 2
                        },
                        new
                        {
                            AmbitId = 8,
                            TypeId = 7
                        },
                        new
                        {
                            AmbitId = 9,
                            TypeId = 7
                        },
                        new
                        {
                            AmbitId = 9,
                            TypeId = 6
                        },
                        new
                        {
                            AmbitId = 10,
                            TypeId = 4
                        },
                        new
                        {
                            AmbitId = 10,
                            TypeId = 10
                        },
                        new
                        {
                            AmbitId = 10,
                            TypeId = 9
                        },
                        new
                        {
                            AmbitId = 10,
                            TypeId = 7
                        },
                        new
                        {
                            AmbitId = 11,
                            TypeId = 4
                        },
                        new
                        {
                            AmbitId = 11,
                            TypeId = 2
                        },
                        new
                        {
                            AmbitId = 11,
                            TypeId = 7
                        },
                        new
                        {
                            AmbitId = 11,
                            TypeId = 6
                        },
                        new
                        {
                            AmbitId = 12,
                            TypeId = 4
                        },
                        new
                        {
                            AmbitId = 13,
                            TypeId = 11
                        },
                        new
                        {
                            AmbitId = 13,
                            TypeId = 12
                        },
                        new
                        {
                            AmbitId = 13,
                            TypeId = 13
                        },
                        new
                        {
                            AmbitId = 13,
                            TypeId = 1
                        },
                        new
                        {
                            AmbitId = 13,
                            TypeId = 14
                        },
                        new
                        {
                            AmbitId = 13,
                            TypeId = 15
                        },
                        new
                        {
                            AmbitId = 13,
                            TypeId = 16
                        },
                        new
                        {
                            AmbitId = 14,
                            TypeId = 7
                        },
                        new
                        {
                            AmbitId = 15,
                            TypeId = 7
                        },
                        new
                        {
                            AmbitId = 15,
                            TypeId = 6
                        },
                        new
                        {
                            AmbitId = 16,
                            TypeId = 10
                        },
                        new
                        {
                            AmbitId = 16,
                            TypeId = 9
                        },
                        new
                        {
                            AmbitId = 16,
                            TypeId = 6
                        },
                        new
                        {
                            AmbitId = 17,
                            TypeId = 6
                        });
                });

            modelBuilder.Entity("Domain.Entities.HelpDesk.Incident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AmbitId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicationType")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("IncidentTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OriginId")
                        .HasColumnType("int");

                    b.Property<string>("ProblemDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ProblemSummary")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("RequestNr")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int>("ScenaryId")
                        .HasColumnType("int");

                    b.Property<string>("Solution")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("SubCause")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("Subsystem")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("ThirdParty")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("ThreatId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("Urgency")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.HasIndex("AmbitId");

                    b.HasIndex("IncidentTypeId");

                    b.HasIndex("OriginId");

                    b.HasIndex("RequestNr")
                        .IsUnique();

                    b.HasIndex("ScenaryId");

                    b.HasIndex("ThreatId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmbitId = 1,
                            ApplicationType = "str",
                            Created = new DateTime(2024, 4, 18, 9, 58, 51, 990, DateTimeKind.Utc).AddTicks(4345),
                            CreatedBy = 1,
                            IncidentTypeId = 1,
                            IsDeleted = false,
                            OpenDate = new DateTime(2024, 4, 18, 9, 58, 51, 990, DateTimeKind.Utc).AddTicks(4879),
                            OriginId = 1,
                            ProblemDescription = "Descr",
                            ProblemSummary = "Summ",
                            RequestNr = "1",
                            ScenaryId = 1,
                            Solution = "str",
                            SubCause = "tmp",
                            Subsystem = "Te",
                            ThirdParty = "tmps",
                            ThreatId = 1,
                            Type = "Configuration",
                            Urgency = "No"
                        });
                });

            modelBuilder.Entity("Domain.Entities.HelpDesk.IncidentAmbit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("Name");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Name"));

                    b.ToTable("Ambits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Software"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Functionality"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Phase"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Release"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Service"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Transmission Channels"
                        },
                        new
                        {
                            Id = 7,
                            Name = "CICS"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Database"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Hardware Host"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Hardware Open"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Middleware"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Networks"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Security"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Basic Host Software"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Open Basic Software"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Service Software"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Storage"
                        });
                });

            modelBuilder.Entity("Domain.Entities.HelpDesk.IncidentOrigin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("Origins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Application"
                        },
                        new
                        {
                            Id = 2,
                            Name = "External"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Infrastructure"
                        });
                });

            modelBuilder.Entity("Domain.Entities.HelpDesk.IncidentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("Name");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Name"));

                    b.ToTable("IncidentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Configuration"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Software Malfunction"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Third Parts"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Incorrect Change"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Code"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Resource Saturation"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Insufficient Resources"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Hardware Malfunction"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Degradation"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Block"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Accesses"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Cyber Attacks"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Certificates"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Firewall"
                        },
                        new
                        {
                            Id = 15,
                            Name = "IDM"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Patching"
                        });
                });

            modelBuilder.Entity("Domain.Entities.HelpDesk.OriginsToAmbit", b =>
                {
                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.Property<int>("AmbitId")
                        .HasColumnType("int");

                    b.HasKey("OriginId", "AmbitId");

                    b.HasIndex("AmbitId");

                    b.ToTable("OriginsToAmbit");

                    b.HasData(
                        new
                        {
                            OriginId = 1,
                            AmbitId = 3
                        },
                        new
                        {
                            OriginId = 1,
                            AmbitId = 2
                        },
                        new
                        {
                            OriginId = 1,
                            AmbitId = 4
                        },
                        new
                        {
                            OriginId = 1,
                            AmbitId = 1
                        },
                        new
                        {
                            OriginId = 2,
                            AmbitId = 2
                        },
                        new
                        {
                            OriginId = 2,
                            AmbitId = 5
                        },
                        new
                        {
                            OriginId = 2,
                            AmbitId = 1
                        },
                        new
                        {
                            OriginId = 3,
                            AmbitId = 6
                        },
                        new
                        {
                            OriginId = 3,
                            AmbitId = 7
                        },
                        new
                        {
                            OriginId = 3,
                            AmbitId = 8
                        },
                        new
                        {
                            OriginId = 3,
                            AmbitId = 3
                        },
                        new
                        {
                            OriginId = 3,
                            AmbitId = 9
                        },
                        new
                        {
                            OriginId = 3,
                            AmbitId = 10
                        },
                        new
                        {
                            OriginId = 3,
                            AmbitId = 11
                        },
                        new
                        {
                            OriginId = 3,
                            AmbitId = 12
                        },
                        new
                        {
                            OriginId = 3,
                            AmbitId = 13
                        },
                        new
                        {
                            OriginId = 3,
                            AmbitId = 1
                        },
                        new
                        {
                            OriginId = 3,
                            AmbitId = 14
                        },
                        new
                        {
                            OriginId = 3,
                            AmbitId = 15
                        },
                        new
                        {
                            OriginId = 3,
                            AmbitId = 16
                        },
                        new
                        {
                            OriginId = 3,
                            AmbitId = 17
                        });
                });

            modelBuilder.Entity("Domain.Entities.HelpDesk.Scenary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("Scenaries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "A1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "A2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "A3"
                        });
                });

            modelBuilder.Entity("Domain.Entities.HelpDesk.Threat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("Threats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AA1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "AA2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "AA3"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("Name")
                        .IsUnique();

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Name"));

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "User that can add, modify and disable other users, change data manually.",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Description = "User that can can view information about incidents.",
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            Description = "User that can import data from a CSV file.",
                            Name = "Operator"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@mail.com",
                            FullName = "Admin",
                            IsEnabled = true,
                            Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                            UserName = "cr00001"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alexander.david@gmail.com",
                            FullName = "David Alexandr",
                            IsEnabled = true,
                            Password = "e17c8fa0a351caf1138741f0862208a250ecfa122ce3f4cbba637a2e510e2920",
                            UserName = "Crme145"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.HelpDesk.AmbitsToTypes", b =>
                {
                    b.HasOne("Domain.Entities.HelpDesk.IncidentAmbit", "Ambit")
                        .WithMany("AmbitsToTypes")
                        .HasForeignKey("AmbitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.HelpDesk.IncidentType", "Type")
                        .WithMany("AmbitsToTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ambit");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Domain.Entities.HelpDesk.Incident", b =>
                {
                    b.HasOne("Domain.Entities.HelpDesk.IncidentAmbit", "Ambit")
                        .WithMany("Incidents")
                        .HasForeignKey("AmbitId");

                    b.HasOne("Domain.Entities.HelpDesk.IncidentType", "IncidentType")
                        .WithMany("Incidents")
                        .HasForeignKey("IncidentTypeId");

                    b.HasOne("Domain.Entities.HelpDesk.IncidentOrigin", "Origin")
                        .WithMany("Incidents")
                        .HasForeignKey("OriginId");

                    b.HasOne("Domain.Entities.HelpDesk.Scenary", "Scenary")
                        .WithMany("Incidents")
                        .HasForeignKey("ScenaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.HelpDesk.Threat", "Threat")
                        .WithMany("Incidents")
                        .HasForeignKey("ThreatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ambit");

                    b.Navigation("IncidentType");

                    b.Navigation("Origin");

                    b.Navigation("Scenary");

                    b.Navigation("Threat");
                });

            modelBuilder.Entity("Domain.Entities.HelpDesk.OriginsToAmbit", b =>
                {
                    b.HasOne("Domain.Entities.HelpDesk.IncidentAmbit", "Ambit")
                        .WithMany("OriginsToAmbits")
                        .HasForeignKey("AmbitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.HelpDesk.IncidentOrigin", "Origin")
                        .WithMany("OriginsToAmbits")
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ambit");

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.HelpDesk.IncidentAmbit", b =>
                {
                    b.Navigation("AmbitsToTypes");

                    b.Navigation("Incidents");

                    b.Navigation("OriginsToAmbits");
                });

            modelBuilder.Entity("Domain.Entities.HelpDesk.IncidentOrigin", b =>
                {
                    b.Navigation("Incidents");

                    b.Navigation("OriginsToAmbits");
                });

            modelBuilder.Entity("Domain.Entities.HelpDesk.IncidentType", b =>
                {
                    b.Navigation("AmbitsToTypes");

                    b.Navigation("Incidents");
                });

            modelBuilder.Entity("Domain.Entities.HelpDesk.Scenary", b =>
                {
                    b.Navigation("Incidents");
                });

            modelBuilder.Entity("Domain.Entities.HelpDesk.Threat", b =>
                {
                    b.Navigation("Incidents");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
