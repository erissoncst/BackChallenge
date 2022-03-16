﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.Property<long>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("brand_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("BrandId");

                    b.ToTable("brands");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Property<long>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("car_id");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("color");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("license_plate");

                    b.Property<long>("ModelId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("model_id");

                    b.Property<short>("YearManufacture")
                        .HasColumnType("INTEGER")
                        .HasColumnName("year_manufacture");

                    b.HasKey("CarId");

                    b.HasIndex("ModelId");

                    b.ToTable("cars");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("category_id");

                    b.Property<string>("Initial")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("initial");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<double>("ValuePerHour")
                        .HasColumnType("REAL")
                        .HasColumnName("value_per_hour");

                    b.HasKey("CategoryId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Domain.Entities.CheckIn", b =>
                {
                    b.Property<long>("CheckInId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("checkin_id");

                    b.Property<long>("CarId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("car_id");

                    b.Property<double>("ContractValue")
                        .HasColumnType("REAL")
                        .HasColumnName("contract_value");

                    b.Property<long>("CustomerId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT")
                        .HasColumnName("end");

                    b.Property<int>("RentCarType")
                        .HasColumnType("INTEGER")
                        .HasColumnName("rentcar_type");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT")
                        .HasColumnName("start");

                    b.Property<double?>("TotalPaid")
                        .HasColumnType("REAL")
                        .HasColumnName("total_paid");

                    b.HasKey("CheckInId");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("checkins");
                });

            modelBuilder.Entity("Domain.Entities.CheckOut", b =>
                {
                    b.Property<long>("CheckoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("checkout_id");

                    b.Property<long>("CheckinId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("checkin_id");

                    b.Property<bool>("CleanCar")
                        .HasColumnType("INTEGER")
                        .HasColumnName("clean_car");

                    b.Property<bool>("FullTank")
                        .HasColumnType("INTEGER")
                        .HasColumnName("full_tank");

                    b.Property<bool>("NoDents")
                        .HasColumnType("INTEGER")
                        .HasColumnName("no_dents");

                    b.Property<bool>("NoScratches")
                        .HasColumnType("INTEGER")
                        .HasColumnName("no_scratches");

                    b.HasKey("CheckoutId");

                    b.HasIndex("CheckinId");

                    b.ToTable("checkouts");
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Property<long>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("customer_id");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("birth_date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("city");

                    b.Property<string>("Complement")
                        .HasColumnType("TEXT")
                        .HasColumnName("complement");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("full_name");

                    b.Property<string>("IndividualRegistration")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("individual_registration");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("number");

                    b.Property<string>("PublicPlace")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("public_place");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("state");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("zip_code");

                    b.HasKey("CustomerId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("customers");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("employee_id");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("full_name");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("registration");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.HasKey("EmployeeId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("employees");
                });

            modelBuilder.Entity("Domain.Entities.Model", b =>
                {
                    b.Property<long>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("model_id");

                    b.Property<long>("BrandId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("brand_id");

                    b.Property<long>("CategoryId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("category_id");

                    b.Property<int>("Fuel")
                        .HasColumnType("INTEGER")
                        .HasColumnName("fuel");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<int>("TrunkCarSize")
                        .HasColumnType("INTEGER")
                        .HasColumnName("trunk_car_size");

                    b.HasKey("ModelId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("models");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("password");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.HasOne("Domain.Entities.Model", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Domain.Entities.CheckIn", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("CheckIns")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Entities.CheckOut", b =>
                {
                    b.HasOne("Domain.Entities.CheckIn", "CheckIn")
                        .WithMany()
                        .HasForeignKey("CheckinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckIn");
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("Domain.Entities.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithOne("Employee")
                        .HasForeignKey("Domain.Entities.Employee", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Model", b =>
                {
                    b.HasOne("Domain.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("Models")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Navigation("CheckIns");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Domain.Entities.Model", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}