﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.Backend.Entities.Context;

namespace Restaurant.Backend.Entities.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210104001934_ConfirmCustomer")]
    partial class ConfirmCustomer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Restaurant.Backend.Entities.Entities.ConfirmCustomer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("ExpirationEmail")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("ModificationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UniqueEmailKey")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("UniquePhoneKey")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("ConfirmCustomers");
                });

            modelBuilder.Entity("Restaurant.Backend.Entities.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<short>("Gender")
                        .HasColumnType("smallint");

                    b.Property<long>("IdentificationNumber")
                        .HasColumnType("bigint");

                    b.Property<Guid>("IdentificationTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTimeOffset>("ModificationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("VerifiedEmail")
                        .HasColumnType("bit");

                    b.Property<bool>("VerifiedPhoneNumber")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdentificationTypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Restaurant.Backend.Entities.Entities.IdentificationType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTimeOffset>("ModificationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("IdentificationTypes");
                });

            modelBuilder.Entity("Restaurant.Backend.Entities.Entities.ConfirmCustomer", b =>
                {
                    b.HasOne("Restaurant.Backend.Entities.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Restaurant.Backend.Entities.Entities.Customer", b =>
                {
                    b.HasOne("Restaurant.Backend.Entities.Entities.IdentificationType", "IdentificationType")
                        .WithMany()
                        .HasForeignKey("IdentificationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentificationType");
                });
#pragma warning restore 612, 618
        }
    }
}
