﻿// <auto-generated />
using System;
using Datalayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Datalayer.Migrations
{
    [DbContext(typeof(GMDBContext))]
    [Migration("20220517152933_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.Band", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("memberLimit")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("Models.BandMember", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("bandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateJoined")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("BandMembers");
                });

            modelBuilder.Entity("Models.Comment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("entry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("likes")
                        .HasColumnType("int");

                    b.Property<int>("postId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("postId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Models.Post", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("bandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("entry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("likes")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.Comment", b =>
                {
                    b.HasOne("Models.Post", null)
                        .WithMany("postComments")
                        .HasForeignKey("postId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Post", b =>
                {
                    b.Navigation("postComments");
                });
#pragma warning restore 612, 618
        }
    }
}