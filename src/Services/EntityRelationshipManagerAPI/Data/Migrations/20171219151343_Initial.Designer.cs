﻿// <auto-generated />
using Arnoldi.Services.EntityRelationshipManagerAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Arnoldi.Services.EntityRelationshipManagerAPI.Data.Migrations
{
    [DbContext(typeof(EntityRelationshipDbContext))]
    [Migration("20171219151343_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("Relational:Sequence:.entity_address_hilo", "'entity_address_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.entity_address_type_hilo", "'entity_address_type_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.entity_email_address_hilo", "'entity_email_address_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.entity_email_address_type_hilo", "'entity_email_address_type_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.entity_item_hilo", "'entity_item_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.entity_statuatory_id_hilo", "'entity_statuatory_id_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.entity_statuatory_id_type_hilo", "'entity_statuatory_id_type_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.entity_telephone_number_hilo", "'entity_telephone_number_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.entity_telephone_number_type_hilo", "'entity_telephone_number_type_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.entity_type_hilo", "'entity_type_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "entity_address_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("AddressCode");

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("AddressLine3");

                    b.Property<int>("EntityAddressTypeId");

                    b.Property<int>("EntityItemId");

                    b.HasKey("Id");

                    b.HasIndex("EntityAddressTypeId");

                    b.HasIndex("EntityItemId");

                    b.ToTable("EntityAddresses");
                });

            modelBuilder.Entity("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityAddressType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "entity_address_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("EntityAddressTypes");
                });

            modelBuilder.Entity("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityEmailAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "entity_email_address_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("EmailAddress");

                    b.Property<int>("EntityEmailAddressTypeId");

                    b.Property<int>("EntityItemId");

                    b.HasKey("Id");

                    b.HasIndex("EntityEmailAddressTypeId");

                    b.HasIndex("EntityItemId");

                    b.ToTable("EntityEmailAddresses");
                });

            modelBuilder.Entity("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityEmailAddressType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "entity_email_address_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("EntityEmailAddressTypes");
                });

            modelBuilder.Entity("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "entity_item_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("EntityTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("EntityTypeId");

                    b.ToTable("EntityItems");
                });

            modelBuilder.Entity("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityStatuatoryId", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "entity_statuatory_id_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("EntityItemId");

                    b.Property<int>("EntityStatuatoryIdTypeId");

                    b.Property<string>("StatuatoryIdNumber");

                    b.HasKey("Id");

                    b.HasIndex("EntityItemId");

                    b.HasIndex("EntityStatuatoryIdTypeId");

                    b.ToTable("EntityStatuatoryIds");
                });

            modelBuilder.Entity("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityStatuatoryIdType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "entity_statuatory_id_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("EntityStatuatoryIdTypes");
                });

            modelBuilder.Entity("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityTelephoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "entity_telephone_number_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("EntityItemId");

                    b.Property<int>("EntityTelephoneNumberTypeId");

                    b.Property<string>("TelephoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("EntityItemId");

                    b.HasIndex("EntityTelephoneNumberTypeId");

                    b.ToTable("EntityTelephoneNumbers");
                });

            modelBuilder.Entity("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityTelephoneNumberType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "entity_telephone_number_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("EntityTelephoneNumberTypes");
                });

            modelBuilder.Entity("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "entity_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("EntityTypes");
                });

            modelBuilder.Entity("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityAddress", b =>
                {
                    b.HasOne("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityAddressType", "EntityAddressType")
                        .WithMany()
                        .HasForeignKey("EntityAddressTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityItem", "EntityItem")
                        .WithMany("EntityAddressList")
                        .HasForeignKey("EntityItemId")
                        .HasConstraintName("ForeignKey_EntityAddressList_EntityItem")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityEmailAddress", b =>
                {
                    b.HasOne("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityEmailAddressType", "EntityEmailAddressType")
                        .WithMany()
                        .HasForeignKey("EntityEmailAddressTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityItem", "EntityItem")
                        .WithMany("EntityEmailAddressList")
                        .HasForeignKey("EntityItemId")
                        .HasConstraintName("ForeignKey_EntityEmailAddressList_EntityItem")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityItem", b =>
                {
                    b.HasOne("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityType", "EntityType")
                        .WithMany()
                        .HasForeignKey("EntityTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityStatuatoryId", b =>
                {
                    b.HasOne("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityItem", "EntityItem")
                        .WithMany("StatuatoryIdList")
                        .HasForeignKey("EntityItemId")
                        .HasConstraintName("ForeignKey_EntityStatuatoryId_EntityItem")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityStatuatoryIdType", "EntityStatuatoryIdType")
                        .WithMany()
                        .HasForeignKey("EntityStatuatoryIdTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityTelephoneNumber", b =>
                {
                    b.HasOne("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityItem", "EntityItem")
                        .WithMany("EntityTelephoneNumberList")
                        .HasForeignKey("EntityItemId")
                        .HasConstraintName("ForeignKey_EntityTelephoneNumberList_EntityItem")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Arnoldi.Services.EntityRelationshipManagerAPI.Domain.EntityTelephoneNumberType", "EntityTelephoneNumberType")
                        .WithMany()
                        .HasForeignKey("EntityTelephoneNumberTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
