// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RssManager.Database;

#nullable disable

namespace RssManager.Migrations
{
    [DbContext(typeof(Database.XmlContext))]
    [Migration("20230128180225_AddedRssSubscriptionModelOneToManyXmlItems")]
    partial class AddedRssSubscriptionModelOneToManyXmlItems
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

            modelBuilder.Entity("RssManager.Models.XmlItemModel", b =>
                {
                    b.HasOne("RssManager.Models.RssSubscription", "RssSubscription")
                        .WithMany("XmlItemModels")
                        .HasForeignKey("RssSubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RssSubscription");
                });

            modelBuilder.Entity("RssManager.Models.RssSubscription", b =>
                {
                    b.Navigation("XmlItemModels");
                });
#pragma warning restore 612, 618
        }
    }
}
