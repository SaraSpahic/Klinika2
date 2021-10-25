﻿// <auto-generated />
using System;
using Klinika2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Klinika2.Migrations
{
    [DbContext(typeof(Klinika2Context))]
    partial class Klinika2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Klinika2.Models.Ljekar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Titula")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ljekar");
                });

            modelBuilder.Entity("Klinika2.Models.Nalaz", b =>
                {
                    b.Property<int>("PrijemID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrijemID");

                    b.ToTable("Nalaz");
                });

            modelBuilder.Entity("Klinika2.Models.Patients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImePrezime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Spol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Klinika2.Models.Prijem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Hitno")
                        .HasColumnType("bit");

                    b.Property<int>("LjekarId")
                        .HasColumnType("int");

                    b.Property<int>("PacijentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LjekarId");

                    b.HasIndex("PacijentId");

                    b.ToTable("Prijem");
                });

            modelBuilder.Entity("Klinika2.Models.Nalaz", b =>
                {
                    b.HasOne("Klinika2.Models.Prijem", null)
                        .WithOne("Nalaz")
                        .HasForeignKey("Klinika2.Models.Nalaz", "PrijemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Klinika2.Models.Prijem", b =>
                {
                    b.HasOne("Klinika2.Models.Ljekar", "Ljekar")
                        .WithMany("Prijemi")
                        .HasForeignKey("LjekarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Klinika2.Models.Patients", "Pacijent")
                        .WithMany("Prijemi")
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ljekar");

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("Klinika2.Models.Ljekar", b =>
                {
                    b.Navigation("Prijemi");
                });

            modelBuilder.Entity("Klinika2.Models.Patients", b =>
                {
                    b.Navigation("Prijemi");
                });

            modelBuilder.Entity("Klinika2.Models.Prijem", b =>
                {
                    b.Navigation("Nalaz");
                });
#pragma warning restore 612, 618
        }
    }
}
