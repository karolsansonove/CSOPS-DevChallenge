﻿// <auto-generated />
using System;
using CSOPS.DevChallenge.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CSOPS.DevChallenge.Migrations
{
    [DbContext(typeof(ChallengeContext))]
    [Migration("20241024111647_UpdatedDateTimePropertiesToNullable")]
    partial class UpdatedDateTimePropertiesToNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("CSOPS.DevChallenge.Context.Entities.ChatInfo", b =>
                {
                    b.Property<string>("ChatId")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactId")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentMemberId")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAnyAttendantAssigned")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsWaiting")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastAttendantId")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastMessageSource")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastMessageState")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastMessageTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ChatId");

                    b.HasIndex("ContactId");

                    b.ToTable("ChatInfos");
                });

            modelBuilder.Entity("CSOPS.DevChallenge.Context.Entities.ContactInfo", b =>
                {
                    b.Property<string>("ContactId")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine1")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("ChannelIds")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedAtUTC")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupIdentifier")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsOptIn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Landline")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastActiveUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(14)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(9)
                        .HasColumnType("TEXT");

                    b.HasKey("ContactId");

                    b.ToTable("ContactInfos");
                });

            modelBuilder.Entity("CSOPS.DevChallenge.Context.Entities.NoteInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactId")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedAtUTC")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("NoteInfos");
                });

            modelBuilder.Entity("CSOPS.DevChallenge.Context.Entities.ScheduledMessageInfo", b =>
                {
                    b.Property<string>("ScheduledMessageId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChannelReferenceId")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("ChannelReferenceName")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactId")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("ScheduledMessageId");

                    b.HasIndex("ContactId");

                    b.ToTable("ScheduledMessageInfos");
                });

            modelBuilder.Entity("CSOPS.DevChallenge.Context.Entities.SearchHistoryInfo", b =>
                {
                    b.Property<int>("SearchHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChatId")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAnyAttendantAssigned")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsWaiting")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastAttendantId")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastMessageSource")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastMessageState")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastMessageTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("MemberId")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("SearchHistoryId");

                    b.HasIndex("ChatId");

                    b.ToTable("SearchHistoryInfos");
                });

            modelBuilder.Entity("CSOPS.DevChallenge.Context.Entities.ChatInfo", b =>
                {
                    b.HasOne("CSOPS.DevChallenge.Context.Entities.ContactInfo", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("CSOPS.DevChallenge.Context.Entities.NoteInfo", b =>
                {
                    b.HasOne("CSOPS.DevChallenge.Context.Entities.ContactInfo", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("CSOPS.DevChallenge.Context.Entities.ScheduledMessageInfo", b =>
                {
                    b.HasOne("CSOPS.DevChallenge.Context.Entities.ContactInfo", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("CSOPS.DevChallenge.Context.Entities.SearchHistoryInfo", b =>
                {
                    b.HasOne("CSOPS.DevChallenge.Context.Entities.ChatInfo", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId");

                    b.Navigation("Chat");
                });
#pragma warning restore 612, 618
        }
    }
}
