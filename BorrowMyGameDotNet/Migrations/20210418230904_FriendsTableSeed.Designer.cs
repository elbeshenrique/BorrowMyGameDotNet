﻿// <auto-generated />
using BorrowMyGameDotNet.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BorrowMyGameDotNet.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210418230904_FriendsTableSeed")]
    partial class FriendsTableSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("BorrowMyGameDotNet.Modules.Core.Domain.Entities.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Friends");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ellen Ripley"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bruce Wayne"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tony Stark"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Lara Croft"
                        });
                });

            modelBuilder.Entity("BorrowMyGameDotNet.Modules.Core.Domain.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsBorrowed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsBorrowed = false,
                            Title = "Half-Life 3"
                        },
                        new
                        {
                            Id = 2,
                            IsBorrowed = true,
                            Title = "Half-Life 2"
                        },
                        new
                        {
                            Id = 3,
                            IsBorrowed = false,
                            Title = "Age of Empires 2"
                        },
                        new
                        {
                            Id = 4,
                            IsBorrowed = true,
                            Title = "SimCity 4000"
                        },
                        new
                        {
                            Id = 5,
                            IsBorrowed = false,
                            Title = "The Elder Scrolls V: Skyrim"
                        },
                        new
                        {
                            Id = 6,
                            IsBorrowed = false,
                            Title = "Fallout 3"
                        },
                        new
                        {
                            Id = 7,
                            IsBorrowed = true,
                            Title = "God Of War"
                        },
                        new
                        {
                            Id = 8,
                            IsBorrowed = false,
                            Title = "Warcraft 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
