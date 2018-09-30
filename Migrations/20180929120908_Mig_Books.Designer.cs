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
    [Migration("20180929120908_Mig_Books")]
    partial class Mig_Books
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

                    b.Property<int>("YearWritten");

                    b.HasKey("Id");

                    b.ToTable("BookDefs");
                });

            modelBuilder.Entity("bookshop.Models.BookInst", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DefinitionId");

                    b.Property<int>("NumberInStock");

                    b.HasKey("Id");

                    b.HasIndex("DefinitionId");

                    b.ToTable("BookInsts");
                });

            modelBuilder.Entity("bookshop.Models.BookInst", b =>
                {
                    b.HasOne("bookshop.Models.BookDef", "Definition")
                        .WithMany()
                        .HasForeignKey("DefinitionId");
                });
#pragma warning restore 612, 618
        }
    }
}
