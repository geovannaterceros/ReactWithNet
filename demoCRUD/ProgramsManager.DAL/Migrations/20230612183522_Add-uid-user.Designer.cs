﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgramsManager.DAL.Database;

#nullable disable

namespace ProgramsManager.DAL.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20230612183522_Add-uid-user")]
    partial class Adduiduser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProgramsManager.DAL.Database.DBModels.Plate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateActivity")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Offer")
                        .HasColumnType("bit");

                    b.Property<string>("UIDUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Plate", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("21eea7cd-5b63-4ee2-88ce-13e13785d10d"),
                            DateActivity = new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Blue 20",
                            Offer = true,
                            UIDUser = "DnwdIFJ3jpYiYqWnyNYAS5nb88g2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
