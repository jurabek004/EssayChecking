﻿// <auto-generated />
using System;
using EssayChecker.API.Brokers.Storages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EssayChecker.API.Migrations
{
    [DbContext(typeof(StorageBroker))]
    [Migration("20231128043138_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EssayChecker.API.Models.Foundation.Essays.Essay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("EssayContent")
                        .HasColumnType("text");

                    b.Property<string>("EssayType")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Essays");
                });

            modelBuilder.Entity("EssayChecker.API.Models.Foundation.Feedbacks.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<Guid>("EssayId")
                        .HasColumnType("uuid");

                    b.Property<float>("Mark")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("EssayId")
                        .IsUnique();

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("EssayChecker.API.Models.Foundation.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EssayChecker.API.Models.Foundation.Essays.Essay", b =>
                {
                    b.HasOne("EssayChecker.API.Models.Foundation.Users.User", "User")
                        .WithMany("Essays")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EssayChecker.API.Models.Foundation.Feedbacks.Feedback", b =>
                {
                    b.HasOne("EssayChecker.API.Models.Foundation.Essays.Essay", "Essay")
                        .WithOne("Feedback")
                        .HasForeignKey("EssayChecker.API.Models.Foundation.Feedbacks.Feedback", "EssayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Essay");
                });

            modelBuilder.Entity("EssayChecker.API.Models.Foundation.Essays.Essay", b =>
                {
                    b.Navigation("Feedback");
                });

            modelBuilder.Entity("EssayChecker.API.Models.Foundation.Users.User", b =>
                {
                    b.Navigation("Essays");
                });
#pragma warning restore 612, 618
        }
    }
}
