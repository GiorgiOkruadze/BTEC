﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scoring.DatabaseEntity.DB;

namespace Scoring.DatabaseEntity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Scoring.DatabaseModels.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int?>("PerformerId")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PerformerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Scoring.DatabaseModels.Models.EventPerformer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EventStorySource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PerformDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<bool>("სSuccessfullyCompleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("EventPerformers");
                });

            modelBuilder.Entity("Scoring.DatabaseModels.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Scoring.DatabaseModels.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MembersCount")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Scoring.DatabaseModels.Models.Event", b =>
                {
                    b.HasOne("Scoring.DatabaseModels.Models.EventPerformer", "Performer")
                        .WithMany()
                        .HasForeignKey("PerformerId");

                    b.Navigation("Performer");
                });

            modelBuilder.Entity("Scoring.DatabaseModels.Models.EventPerformer", b =>
                {
                    b.HasOne("Scoring.DatabaseModels.Models.Team", "PerformerTeam")
                        .WithMany("CompletedEvents")
                        .HasForeignKey("TeamId");

                    b.Navigation("PerformerTeam");
                });

            modelBuilder.Entity("Scoring.DatabaseModels.Models.Student", b =>
                {
                    b.HasOne("Scoring.DatabaseModels.Models.Team", "Team")
                        .WithMany("Students")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Scoring.DatabaseModels.Models.Team", b =>
                {
                    b.Navigation("CompletedEvents");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
