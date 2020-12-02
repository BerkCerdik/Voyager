﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Voyager.Models.Orm.Context;

namespace Voyager.Migrations
{
    [DbContext(typeof(VoyagerContext))]
    partial class VoyagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Voyager.Models.Orm.Entities.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int>("TripID")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("TripID")
                        .IsUnique();

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Voyager.Models.Orm.Entities.Driver", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Experience")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaymentID")
                        .HasColumnType("int");

                    b.Property<string>("Plate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("PaymentID");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Voyager.Models.Orm.Entities.Passenger", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaymentID")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("PaymentID");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("Voyager.Models.Orm.Entities.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("TripID")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("TripID")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Voyager.Models.Orm.Entities.Trip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ArrivalPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeparturePoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriverID")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PassengerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("DriverID")
                        .IsUnique();

                    b.HasIndex("PassengerID")
                        .IsUnique();

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Voyager.Models.Orm.Entities.Comment", b =>
                {
                    b.HasOne("Voyager.Models.Orm.Entities.Trip", "Trip")
                        .WithOne("Comment")
                        .HasForeignKey("Voyager.Models.Orm.Entities.Comment", "TripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Voyager.Models.Orm.Entities.Driver", b =>
                {
                    b.HasOne("Voyager.Models.Orm.Entities.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentID");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Voyager.Models.Orm.Entities.Passenger", b =>
                {
                    b.HasOne("Voyager.Models.Orm.Entities.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentID");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Voyager.Models.Orm.Entities.Payment", b =>
                {
                    b.HasOne("Voyager.Models.Orm.Entities.Trip", "Trip")
                        .WithOne("Payment")
                        .HasForeignKey("Voyager.Models.Orm.Entities.Payment", "TripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Voyager.Models.Orm.Entities.Trip", b =>
                {
                    b.HasOne("Voyager.Models.Orm.Entities.Driver", "Driver")
                        .WithOne("Trip")
                        .HasForeignKey("Voyager.Models.Orm.Entities.Trip", "DriverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Voyager.Models.Orm.Entities.Passenger", "Passenger")
                        .WithOne("Trip")
                        .HasForeignKey("Voyager.Models.Orm.Entities.Trip", "PassengerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("Voyager.Models.Orm.Entities.Driver", b =>
                {
                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Voyager.Models.Orm.Entities.Passenger", b =>
                {
                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Voyager.Models.Orm.Entities.Trip", b =>
                {
                    b.Navigation("Comment");

                    b.Navigation("Payment");
                });
#pragma warning restore 612, 618
        }
    }
}