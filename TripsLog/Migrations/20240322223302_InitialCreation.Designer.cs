﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TripsLog.Data;

#nullable disable

namespace TripsLog.Migrations
{
    [DbContext(typeof(TripsContext))]
    [Migration("20240322223302_InitialCreation")]
    partial class InitialCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TripsLog.Models.Accommodation", b =>
                {
                    b.Property<int>("AccommodationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccommodationId"));

                    b.Property<string>("AccommodationEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccommodationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccommodationPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccommodationId");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("TripsLog.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityId"));

                    b.Property<string>("ActivityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActivityId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("TripsLog.Models.Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DestinationId"));

                    b.Property<string>("DestinationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DestinationId");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("TripsLog.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripId"));

                    b.Property<int?>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TripId");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("DestinationId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TripsLog.Models.TripActivity", b =>
                {
                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.HasKey("TripId", "ActivityId");

                    b.HasIndex("ActivityId");

                    b.ToTable("TripActivities");
                });

            modelBuilder.Entity("TripsLog.Models.Trip", b =>
                {
                    b.HasOne("TripsLog.Models.Accommodation", "Accommodation")
                        .WithMany("Trip")
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("TripsLog.Models.Destination", "Destination")
                        .WithMany("Trip")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Accommodation");

                    b.Navigation("Destination");
                });

            modelBuilder.Entity("TripsLog.Models.TripActivity", b =>
                {
                    b.HasOne("TripsLog.Models.Activity", "Activity")
                        .WithMany("TripActivities")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TripsLog.Models.Trip", "Trip")
                        .WithMany("TripActivities")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("TripsLog.Models.Accommodation", b =>
                {
                    b.Navigation("Trip");
                });

            modelBuilder.Entity("TripsLog.Models.Activity", b =>
                {
                    b.Navigation("TripActivities");
                });

            modelBuilder.Entity("TripsLog.Models.Destination", b =>
                {
                    b.Navigation("Trip");
                });

            modelBuilder.Entity("TripsLog.Models.Trip", b =>
                {
                    b.Navigation("TripActivities");
                });
#pragma warning restore 612, 618
        }
    }
}