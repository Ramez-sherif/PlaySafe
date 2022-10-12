﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlaySafe.Data;

#nullable disable

namespace PlaySafe.Migrations
{
    [DbContext(typeof(dbContext))]
    partial class dbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PlaySafe.Models.comments", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("PlaySafe.Models.entry", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("points")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("entry");
                });

            modelBuilder.Entity("PlaySafe.Models.matchHistory", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("entryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("withPoints")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("entryId");

                    b.HasIndex("userId");

                    b.ToTable("matchHistory");
                });

            modelBuilder.Entity("PlaySafe.Models.NFC", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("NFC");
                });

            modelBuilder.Entity("PlaySafe.Models.player", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("adminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("pic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("points")
                        .HasColumnType("int");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("player");
                });

            modelBuilder.Entity("PlaySafe.Models.specials", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("adminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("special")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("adminId");

                    b.ToTable("specials");
                });

            modelBuilder.Entity("PlaySafe.Models.user", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("phoneNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("points")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("userTypeId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("PlaySafe.Models.userType", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("usersType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("userType");
                });

            modelBuilder.Entity("PlaySafe.Models.userTypePages", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("page")
                        .HasColumnType("int");

                    b.Property<Guid>("userTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("userTypeId");

                    b.ToTable("userTypePages");
                });

            modelBuilder.Entity("PlaySafe.Models.comments", b =>
                {
                    b.HasOne("PlaySafe.Models.user", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("PlaySafe.Models.matchHistory", b =>
                {
                    b.HasOne("PlaySafe.Models.entry", "entry")
                        .WithMany()
                        .HasForeignKey("entryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlaySafe.Models.user", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("entry");

                    b.Navigation("user");
                });

            modelBuilder.Entity("PlaySafe.Models.NFC", b =>
                {
                    b.HasOne("PlaySafe.Models.user", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("PlaySafe.Models.player", b =>
                {
                    b.HasOne("PlaySafe.Models.user", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("PlaySafe.Models.specials", b =>
                {
                    b.HasOne("PlaySafe.Models.userType", "userType")
                        .WithMany()
                        .HasForeignKey("adminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("userType");
                });

            modelBuilder.Entity("PlaySafe.Models.user", b =>
                {
                    b.HasOne("PlaySafe.Models.userType", "userType")
                        .WithMany()
                        .HasForeignKey("userTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("userType");
                });

            modelBuilder.Entity("PlaySafe.Models.userTypePages", b =>
                {
                    b.HasOne("PlaySafe.Models.userType", "userType")
                        .WithMany()
                        .HasForeignKey("userTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("userType");
                });
#pragma warning restore 612, 618
        }
    }
}
