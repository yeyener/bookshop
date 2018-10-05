﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bookshop.Persistance;

namespace bookshop.Migrations
{
    [DbContext(typeof(BookDbContext))]
    [Migration("20181003040112_Mig_FKS_Nullable")]
    partial class Mig_FKS_Nullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bookshop.Models.BookDef", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("WriterId");

                    b.Property<int>("YearWritten");

                    b.HasKey("Id");

                    b.HasIndex("WriterId");

                    b.ToTable("BookDefs");
                });

            modelBuilder.Entity("bookshop.Models.BookDefGenre", b =>
                {
                    b.Property<int>("BookDefId");

                    b.Property<int>("GenreId");

                    b.HasKey("BookDefId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookDefGenre");
                });

            modelBuilder.Entity("bookshop.Models.BookInst", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookName");

                    b.Property<int>("DefinitionId");

                    b.Property<int>("Edition");

                    b.Property<int?>("LanguageId");

                    b.Property<int>("NumberInStock");

                    b.Property<int>("PageNumber");

                    b.Property<int?>("PublisherId");

                    b.Property<int?>("TranslatorId");

                    b.Property<string>("WriterName");

                    b.HasKey("Id");

                    b.HasIndex("DefinitionId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PublisherId");

                    b.HasIndex("TranslatorId");

                    b.ToTable("BookInsts");
                });

            modelBuilder.Entity("bookshop.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("bookshop.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("bookshop.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("bookshop.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("bookshop.Models.Translator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Translators");
                });

            modelBuilder.Entity("bookshop.Models.Writer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId");

                    b.Property<string>("Definition");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("bookshop.Models.BookDef", b =>
                {
                    b.HasOne("bookshop.Models.Writer", "Writer")
                        .WithMany()
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("bookshop.Models.BookDefGenre", b =>
                {
                    b.HasOne("bookshop.Models.BookDef", "BookDef")
                        .WithMany("BookDefGenres")
                        .HasForeignKey("BookDefId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("bookshop.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("bookshop.Models.BookInst", b =>
                {
                    b.HasOne("bookshop.Models.BookDef", "Definition")
                        .WithMany()
                        .HasForeignKey("DefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("bookshop.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");

                    b.HasOne("bookshop.Models.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId");

                    b.HasOne("bookshop.Models.Translator", "Translator")
                        .WithMany()
                        .HasForeignKey("TranslatorId");
                });

            modelBuilder.Entity("bookshop.Models.Writer", b =>
                {
                    b.HasOne("bookshop.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });
#pragma warning restore 612, 618
        }
    }
}
