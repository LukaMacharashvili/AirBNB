﻿// <auto-generated />
using System;
using AirBNB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirBNB.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221227093125_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AirBNB.Domain.BookDates.BookDate", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("RoomId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("bookDate", (string)null);
                });

            modelBuilder.Entity("AirBNB.Domain.Hotels.Hotel", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("varchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("hotel", (string)null);
                });

            modelBuilder.Entity("AirBNB.Domain.Rooms.Room", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("HotelId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("varchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("room", (string)null);
                });

            modelBuilder.Entity("AirBNB.Domain.Users.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("AirBNB.Domain.BookDates.BookDate", b =>
                {
                    b.HasOne("AirBNB.Domain.Rooms.Room", "Room")
                        .WithMany("BookDates")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("AirBNB.Domain.Hotels.Hotel", b =>
                {
                    b.HasOne("AirBNB.Domain.Users.User", "User")
                        .WithMany("Hotels")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AirBNB.Domain.Rooms.Room", b =>
                {
                    b.HasOne("AirBNB.Domain.Hotels.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("AirBNB.Domain.Hotels.Hotel", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("AirBNB.Domain.Rooms.Room", b =>
                {
                    b.Navigation("BookDates");
                });

            modelBuilder.Entity("AirBNB.Domain.Users.User", b =>
                {
                    b.Navigation("Hotels");
                });
#pragma warning restore 612, 618
        }
    }
}