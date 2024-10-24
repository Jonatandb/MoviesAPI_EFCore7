﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesAPI_EFCore7.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MoviesAPI_EFCore7.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    partial class MoviesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

                    b.ToTable("Generos");
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

            modelBuilder.Entity("MoviesAPI_EFCore7.Entities.Pelicula", b =>
                {
                    b.Navigation("Comentarios");
                });
#pragma warning restore 612, 618
        }
    }
}
