﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YourAssistant;

namespace YourAssistant.Migrations
{
    [DbContext(typeof(AssistantContext))]
    [Migration("20191028140334_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YourAssistant.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("YourAssistant.Models.GameLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<float>("PointRate");

                    b.Property<int?>("gameId");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("gameId");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("YourAssistant.Models.GameRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GameId");

                    b.Property<int>("Points");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("GameRating");
                });

            modelBuilder.Entity("YourAssistant.Models.LevelGameRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GameId");

                    b.Property<int?>("LevelId");

                    b.Property<int>("Points");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("LevelId");

                    b.HasIndex("UserId");

                    b.ToTable("LevelRating");
                });

            modelBuilder.Entity("YourAssistant.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Image");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("YourAssistant.Models.GameLevel", b =>
                {
                    b.HasOne("YourAssistant.Models.Game", "game")
                        .WithMany()
                        .HasForeignKey("gameId");
                });

            modelBuilder.Entity("YourAssistant.Models.GameRating", b =>
                {
                    b.HasOne("YourAssistant.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.HasOne("YourAssistant.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("YourAssistant.Models.LevelGameRating", b =>
                {
                    b.HasOne("YourAssistant.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.HasOne("YourAssistant.Models.GameLevel", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId");

                    b.HasOne("YourAssistant.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
