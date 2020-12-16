﻿// <auto-generated />
using System;
using AlquilerApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlquilerApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201216081930_addPropertiToRenter")]
    partial class addPropertiToRenter
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AlquilerApp.Models.AditionalAmount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("FeeContractId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("FeeId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("FeeId1")
                        .HasColumnType("INTEGER");

                    b.Property<double>("amount")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FeeId1", "FeeContractId");

                    b.ToTable("AditionalAmount");
                });

            modelBuilder.Entity("AlquilerApp.Models.Contract", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnType("TEXT");

                    b.Property<long>("RenterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("amount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("finishDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

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

            modelBuilder.Entity("AlquilerApp.Models.Fee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("ContractId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("EmitDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("ExpiryAmount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id", "ContractId");

                    b.HasIndex("ContractId");

                    b.ToTable("Fee");
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

                    b.Property<bool>("Active")
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

            modelBuilder.Entity("AlquilerApp.Models.AditionalAmount", b =>
                {
                    b.HasOne("AlquilerApp.Models.Fee", null)
                        .WithMany("AditionalAmounts")
                        .HasForeignKey("FeeId1", "FeeContractId");
                });

            modelBuilder.Entity("AlquilerApp.Models.Department", b =>
                {
                    b.HasOne("AlquilerApp.Models.Lessee", null)
                        .WithMany("Departments")
                        .HasForeignKey("LesseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlquilerApp.Models.Fee", b =>
                {
                    b.HasOne("AlquilerApp.Models.Contract", null)
                        .WithMany("Fees")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlquilerApp.Models.Contract", b =>
                {
                    b.Navigation("Fees");
                });

            modelBuilder.Entity("AlquilerApp.Models.Fee", b =>
                {
                    b.Navigation("AditionalAmounts");
                });

            modelBuilder.Entity("AlquilerApp.Models.Lessee", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
