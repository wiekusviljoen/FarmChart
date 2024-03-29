﻿// <auto-generated />
using System;
using Farm.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Farm.Migrations
{
    [DbContext(typeof(FarmContext))]
    [Migration("20230902131018_farmcontext")]
    partial class farmcontext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Farm.Models.Cattle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Branded")
                        .HasColumnType("bit");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BullCalf")
                        .HasColumnType("int");

                    b.Property<int>("Bulls")
                        .HasColumnType("int");

                    b.Property<string>("Camp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CowCalf")
                        .HasColumnType("int");

                    b.Property<int>("Cows")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Dead")
                        .HasColumnType("int");

                    b.Property<bool>("Dipped")
                        .HasColumnType("bit");

                    b.Property<string>("Feed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("FeedPrice")
                        .HasColumnType("real");

                    b.Property<float>("FeedQuantity")
                        .HasColumnType("real");

                    b.Property<bool>("Injected")
                        .HasColumnType("bit");

                    b.Property<int>("Missing")
                        .HasColumnType("int");

                    b.Property<int>("NewCalf")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cattle");
                });

            modelBuilder.Entity("Farm.Models.RainModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Camp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("RainModel");
                });
#pragma warning restore 612, 618
        }
    }
}
