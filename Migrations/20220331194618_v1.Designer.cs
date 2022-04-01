﻿// <auto-generated />
using System;
using AndreAirlinesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AndreAirlinesApi.Migrations
{
    [DbContext(typeof(AndreAirlinesApiContext))]
    [Migration("20220331194618_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AndreAirlinesApi.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("AndreAirlinesApi.Model.Airport", b =>
                {
                    b.Property<string>("Acronym")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Acronym");

                    b.HasIndex("AddressId");

                    b.ToTable("Airport");
                });

            modelBuilder.Entity("AndreAirlinesApi.Model.Airship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Airship");
                });

            modelBuilder.Entity("AndreAirlinesApi.Model.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirportDestinyAcronym")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AirportOriginAcronym")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AirshipId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HorarioDesembarque")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HorarioEmbarque")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PassengerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirportDestinyAcronym");

                    b.HasIndex("AirportOriginAcronym");

                    b.HasIndex("AirshipId");

                    b.HasIndex("PassengerId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("AndreAirlinesApi.Model.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nome");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Passenger");
                });

            modelBuilder.Entity("AndreAirlinesApi.Model.Airport", b =>
                {
                    b.HasOne("AndreAirlinesApi.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("AndreAirlinesApi.Model.Flight", b =>
                {
                    b.HasOne("AndreAirlinesApi.Model.Airport", "AirportDestiny")
                        .WithMany()
                        .HasForeignKey("AirportDestinyAcronym");

                    b.HasOne("AndreAirlinesApi.Model.Airport", "AirportOrigin")
                        .WithMany()
                        .HasForeignKey("AirportOriginAcronym");

                    b.HasOne("AndreAirlinesApi.Model.Airship", "Airship")
                        .WithMany()
                        .HasForeignKey("AirshipId");

                    b.HasOne("AndreAirlinesApi.Model.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerId");

                    b.Navigation("AirportDestiny");

                    b.Navigation("AirportOrigin");

                    b.Navigation("Airship");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("AndreAirlinesApi.Model.Passenger", b =>
                {
                    b.HasOne("AndreAirlinesApi.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
