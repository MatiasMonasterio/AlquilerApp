﻿// <auto-generated />
using System;
using AlquilerApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlquilerApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AlquilerApp.Models.Contract", b =>
                {
                    b.Property<long>("LesseeId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnType("TEXT");

                    b.Property<long>("RenterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LesseeId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RenterId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("AlquilerApp.Models.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("LesseeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("provincia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("state")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LesseeId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("AlquilerApp.Models.Lessee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("FeeEmitAlert")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("FeeOverdueAlert")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("PaymentTicket")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Theme")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Lessee");
                });

            modelBuilder.Entity("AlquilerApp.Models.Renter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("FeeEmitAlert")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("FeeOverdueAlert")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("PaymentTicket")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Theme")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Renter");
                });

            modelBuilder.Entity("AlquilerApp.Models.Contract", b =>
                {
                    b.HasOne("AlquilerApp.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlquilerApp.Models.Lessee", "Lessee")
                        .WithMany()
                        .HasForeignKey("LesseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlquilerApp.Models.Renter", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Lessee");

                    b.Navigation("Renter");
                });

            modelBuilder.Entity("AlquilerApp.Models.Department", b =>
                {
                    b.HasOne("AlquilerApp.Models.Lessee", "Lesse")
                        .WithMany("Departments")
                        .HasForeignKey("LesseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesse");
                });

            modelBuilder.Entity("AlquilerApp.Models.Lessee", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
