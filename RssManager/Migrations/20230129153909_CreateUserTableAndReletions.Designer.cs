﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RssManager.Database;

#nullable disable

namespace RssManager.Migrations
{
    [DbContext(typeof(XmlContext))]
    [Migration("20230129153909_CreateUserTableAndReletions")]
    partial class CreateUserTableAndReletions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.13");

            modelBuilder.Entity("RssManager.Models.RssSubscription", b =>
                {
                    b.Property<int>("RssSubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("RssSubscriptionId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("RssManager.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RssManager.Models.XmlItemModel", b =>
                {
                    b.Property<int>("XmlItemModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("RssSubscriptionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("XmlText")
                        .HasColumnType("TEXT");

                    b.HasKey("XmlItemModelId");

                    b.HasIndex("RssSubscriptionId");

                    b.ToTable("XmlItems");
                });

            modelBuilder.Entity("UserXmlItemModel", b =>
                {
                    b.Property<int>("ItemsXmlItemModelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ItemsXmlItemModelId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("UserXmlItemModel");
                });

            modelBuilder.Entity("RssManager.Models.XmlItemModel", b =>
                {
                    b.HasOne("RssManager.Models.RssSubscription", "RssSubscription")
                        .WithMany("XmlItemModels")
                        .HasForeignKey("RssSubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RssSubscription");
                });

            modelBuilder.Entity("UserXmlItemModel", b =>
                {
                    b.HasOne("RssManager.Models.XmlItemModel", null)
                        .WithMany()
                        .HasForeignKey("ItemsXmlItemModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RssManager.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RssManager.Models.RssSubscription", b =>
                {
                    b.Navigation("XmlItemModels");
                });
#pragma warning restore 612, 618
        }
    }
}
