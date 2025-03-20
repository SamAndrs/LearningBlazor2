﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieStoreAPI.Data;

#nullable disable

namespace MovieStoreAPI.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20250319113706_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieStoreAPI.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Documentary"
                        });
                });

            modelBuilder.Entity("MovieStoreAPI.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 1,
                            Name = "Inception",
                            Price = 12.99m,
                            ReleaseDate = new DateOnly(2003, 1, 1)
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 1,
                            Name = "The Dark Knight",
                            Price = 14.99m,
                            ReleaseDate = new DateOnly(2005, 1, 1)
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 2,
                            Name = "Interstellar",
                            Price = 10.99m,
                            ReleaseDate = new DateOnly(2007, 1, 1)
                        },
                        new
                        {
                            Id = 4,
                            GenreId = 2,
                            Name = "The Matrix",
                            Price = 9.99m,
                            ReleaseDate = new DateOnly(1999, 1, 1)
                        },
                        new
                        {
                            Id = 5,
                            GenreId = 3,
                            Name = "The Lord of the Rings: The Fellowship of the Ring",
                            Price = 11.99m,
                            ReleaseDate = new DateOnly(2008, 1, 1)
                        },
                        new
                        {
                            Id = 6,
                            GenreId = 3,
                            Name = "The Lord of the Rings: The Two Towers",
                            Price = 11.99m,
                            ReleaseDate = new DateOnly(2011, 1, 1)
                        });
                });

            modelBuilder.Entity("MovieStoreAPI.Entities.Movie", b =>
                {
                    b.HasOne("MovieStoreAPI.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
