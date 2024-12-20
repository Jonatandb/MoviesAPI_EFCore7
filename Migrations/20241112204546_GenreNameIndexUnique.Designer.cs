﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesAPI_EFCore7.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MoviesAPI_EFCore7.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    [Migration("20241112204546_GenreNameIndexUnique")]
    partial class GenreNameIndexUnique
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GeneroPelicula", b =>
                {
                    b.Property<int>("GenerosId")
                        .HasColumnType("integer");

                    b.Property<int>("PeliculasId")
                        .HasColumnType("integer");

                    b.HasKey("GenerosId", "PeliculasId");

                    b.HasIndex("PeliculasId");

                    b.ToTable("GeneroPelicula");

                    b.HasData(
                        new
                        {
                            GenerosId = 2,
                            PeliculasId = 2
                        },
                        new
                        {
                            GenerosId = 2,
                            PeliculasId = 3
                        },
                        new
                        {
                            GenerosId = 5,
                            PeliculasId = 4
                        });
                });

            modelBuilder.Entity("MoviesAPI_EFCore7.Entities.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<decimal>("Fortuna")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.ToTable("Actores");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            FechaNacimiento = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fortuna = 15000m,
                            Nombre = "Samuel Jackson"
                        },
                        new
                        {
                            Id = 3,
                            FechaNacimiento = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fortuna = 18000m,
                            Nombre = "Robert Downey Jr"
                        });
                });

            modelBuilder.Entity("MoviesAPI_EFCore7.Entities.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Contenido")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("integer");

                    b.Property<bool>("Recomendar")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("PeliculaId");

                    b.ToTable("Comentarios");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Contenido = "Muy buena",
                            PeliculaId = 2,
                            Recomendar = true
                        },
                        new
                        {
                            Id = 3,
                            Contenido = "Dura dura",
                            PeliculaId = 2,
                            Recomendar = true
                        },
                        new
                        {
                            Id = 4,
                            Contenido = "Muy aburrida...",
                            PeliculaId = 3,
                            Recomendar = false
                        });
                });

            modelBuilder.Entity("MoviesAPI_EFCore7.Entities.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Generos");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Nombre = "Ciencia ficción"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Anime"
                        });
                });

            modelBuilder.Entity("MoviesAPI_EFCore7.Entities.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("EnCines")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("FechaEstreno")
                        .HasColumnType("date");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.ToTable("Peliculas");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            EnCines = false,
                            FechaEstreno = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titulo = "Avengers Endgame"
                        },
                        new
                        {
                            Id = 3,
                            EnCines = false,
                            FechaEstreno = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titulo = "Spiderman: No Way Home"
                        },
                        new
                        {
                            Id = 4,
                            EnCines = false,
                            FechaEstreno = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titulo = "Spiderman: Across the Spider-Verse 2"
                        });
                });

            modelBuilder.Entity("MoviesAPI_EFCore7.Entities.PeliculaActor", b =>
                {
                    b.Property<int>("PeliculaId")
                        .HasColumnType("integer");

                    b.Property<int>("ActorId")
                        .HasColumnType("integer");

                    b.Property<int>("Orden")
                        .HasColumnType("integer");

                    b.Property<string>("Personaje")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("PeliculaId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("PeliculasActores");

                    b.HasData(
                        new
                        {
                            PeliculaId = 3,
                            ActorId = 2,
                            Orden = 1,
                            Personaje = "Nick Fury"
                        },
                        new
                        {
                            PeliculaId = 2,
                            ActorId = 2,
                            Orden = 2,
                            Personaje = "Nick Fury"
                        },
                        new
                        {
                            PeliculaId = 2,
                            ActorId = 3,
                            Orden = 1,
                            Personaje = "Tony Stark / Ironman"
                        });
                });

            modelBuilder.Entity("GeneroPelicula", b =>
                {
                    b.HasOne("MoviesAPI_EFCore7.Entities.Genero", null)
                        .WithMany()
                        .HasForeignKey("GenerosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesAPI_EFCore7.Entities.Pelicula", null)
                        .WithMany()
                        .HasForeignKey("PeliculasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviesAPI_EFCore7.Entities.Comentario", b =>
                {
                    b.HasOne("MoviesAPI_EFCore7.Entities.Pelicula", "Pelicula")
                        .WithMany("Comentarios")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("MoviesAPI_EFCore7.Entities.PeliculaActor", b =>
                {
                    b.HasOne("MoviesAPI_EFCore7.Entities.Actor", "Actor")
                        .WithMany("Peliculas")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesAPI_EFCore7.Entities.Pelicula", "Pelicula")
                        .WithMany("PeliculasActores")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("MoviesAPI_EFCore7.Entities.Actor", b =>
                {
                    b.Navigation("Peliculas");
                });

            modelBuilder.Entity("MoviesAPI_EFCore7.Entities.Pelicula", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("PeliculasActores");
                });
#pragma warning restore 612, 618
        }
    }
}
