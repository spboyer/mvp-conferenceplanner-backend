﻿// <auto-generated />
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-preview1-24937")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd.Data.Attendee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(256);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Attendees");
                });

            modelBuilder.Entity("BackEnd.Data.Conference", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.ToTable("Conferences");
                });

            modelBuilder.Entity("BackEnd.Data.ConferenceAttendee", b =>
                {
                    b.Property<int>("ConferenceID");

                    b.Property<int>("AttendeeID");

                    b.HasKey("ConferenceID", "AttendeeID");

                    b.HasIndex("AttendeeID");

                    b.ToTable("ConferenceAttendee");
                });

            modelBuilder.Entity("BackEnd.Data.Session", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abstract")
                        .HasMaxLength(4000);

                    b.Property<int?>("AttendeeID");

                    b.Property<int>("ConferenceID");

                    b.Property<DateTimeOffset?>("EndTime");

                    b.Property<DateTimeOffset?>("StartTime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int?>("TrackId");

                    b.HasKey("ID");

                    b.HasIndex("AttendeeID");

                    b.HasIndex("ConferenceID");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("BackEnd.Data.SessionSpeaker", b =>
                {
                    b.Property<int>("SessionId");

                    b.Property<int>("SpeakerId");

                    b.HasKey("SessionId", "SpeakerId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("SessionSpeaker");
                });

            modelBuilder.Entity("BackEnd.Data.SessionTag", b =>
                {
                    b.Property<int>("SessionID");

                    b.Property<int>("TagID");

                    b.HasKey("SessionID", "TagID");

                    b.HasIndex("TagID");

                    b.ToTable("SessionTag");
                });

            modelBuilder.Entity("BackEnd.Data.Speaker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio")
                        .HasMaxLength(4000);

                    b.Property<int?>("ConferenceID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("WebSite")
                        .HasMaxLength(1000);

                    b.HasKey("ID");

                    b.HasIndex("ConferenceID");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("ConferenceDTO.Tag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("ID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ConferenceDTO.Track", b =>
                {
                    b.Property<int>("TrackID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConferenceID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("TrackID");

                    b.HasIndex("ConferenceID");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("BackEnd.Data.ConferenceAttendee", b =>
                {
                    b.HasOne("BackEnd.Data.Attendee", "Attendee")
                        .WithMany("ConferenceAttendees")
                        .HasForeignKey("AttendeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BackEnd.Data.Conference", "Conference")
                        .WithMany("ConferenceAttendees")
                        .HasForeignKey("ConferenceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackEnd.Data.Session", b =>
                {
                    b.HasOne("BackEnd.Data.Attendee")
                        .WithMany("Sessions")
                        .HasForeignKey("AttendeeID");

                    b.HasOne("BackEnd.Data.Conference")
                        .WithMany("Sessions")
                        .HasForeignKey("ConferenceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackEnd.Data.SessionSpeaker", b =>
                {
                    b.HasOne("BackEnd.Data.Session", "Session")
                        .WithMany("SessionSpeakers")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BackEnd.Data.Speaker", "Speaker")
                        .WithMany("SessionSpeakers")
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackEnd.Data.SessionTag", b =>
                {
                    b.HasOne("BackEnd.Data.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConferenceDTO.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackEnd.Data.Speaker", b =>
                {
                    b.HasOne("BackEnd.Data.Conference")
                        .WithMany("Speakers")
                        .HasForeignKey("ConferenceID");
                });

            modelBuilder.Entity("ConferenceDTO.Track", b =>
                {
                    b.HasOne("BackEnd.Data.Conference")
                        .WithMany("Tracks")
                        .HasForeignKey("ConferenceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
