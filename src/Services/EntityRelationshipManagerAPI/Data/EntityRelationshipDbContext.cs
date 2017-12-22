using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arnoldi.Services.EntityRelationshipManagerAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arnoldi.Services.EntityRelationshipManagerAPI.Data
{
    public class EntityRelationshipDbContext : DbContext
    {
        public DbSet<EntityAddressType> EntityAddressTypes { get; set; }
        public DbSet<EntityType> EntityType { get; set; }
        public DbSet<EntityEmailAddressType> EntityEmailAddressTypes { get; set; }
        public DbSet<EntityItem> EntityItems { get; set; }
        public DbSet<EntityStatuatoryIdType> EntityStatuatoryIdTypes { get; set; }
        public DbSet<EntityTelephoneNumberType> EntityTelephoneNumberTypes { get; set; }

        public EntityRelationshipDbContext(DbContextOptions<EntityRelationshipDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EntityAddress>(ConfigureEntityAddress);
            builder.Entity<EntityAddressType>(ConfigureEntityAddressType);
            builder.Entity<EntityEmailAddress>(ConfigureEntityEmailAddress);
            builder.Entity<EntityEmailAddressType>(ConfigureEntityEmailAddressType);
            builder.Entity<EntityItem>(ConfigureEntityItem);
            builder.Entity<EntityStatuatoryId>(ConfigureEntityStatuatoryId);
            builder.Entity<EntityStatuatoryIdType>(ConfigureEntityStatuatoryIdType);
            builder.Entity<EntityTelephoneNumber>(ConfigureEntityTelephoneNumber);
            builder.Entity<EntityTelephoneNumberType>(ConfigureEntityTelephoneNumberType);
            builder.Entity<EntityType>(ConfigureEntityType);

        }

        void ConfigureEntityAddress(EntityTypeBuilder<EntityAddress> builder)
        {
            builder.ToTable("EntityAddresses");

            builder.Property(ci => ci.Id)
              .ForSqlServerUseSequenceHiLo("entity_address_hilo")
              .IsRequired();

            builder.HasOne(ci => ci.EntityAddressType)
                .WithMany()
                .HasForeignKey(ci => ci.EntityAddressTypeId);

            builder.HasOne(p => p.EntityItem)
               .WithMany(b => b.EntityAddressList)
               .HasForeignKey(p => p.EntityItemId)
               .HasConstraintName("ForeignKey_EntityAddressList_EntityItem");

        }

        void ConfigureEntityAddressType(EntityTypeBuilder<EntityAddressType> builder)
        {
            builder.ToTable("EntityAddressTypes");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("entity_address_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.Type)
                .IsRequired()
                .HasMaxLength(30);
        }

        void ConfigureEntityEmailAddress(EntityTypeBuilder<EntityEmailAddress> builder)
        {
            builder.ToTable("EntityEmailAddresses");

            builder.Property(ci => ci.Id)
              .ForSqlServerUseSequenceHiLo("entity_email_address_hilo")
              .IsRequired();

            builder.HasOne(ci => ci.EntityEmailAddressType)
                .WithMany()
                .HasForeignKey(ci => ci.EntityEmailAddressTypeId);

            builder.HasOne(p => p.EntityItem)
              .WithMany(b => b.EntityEmailAddressList)
              .HasForeignKey(p => p.EntityItemId)
              .HasConstraintName("ForeignKey_EntityEmailAddressList_EntityItem");

        }

        void ConfigureEntityEmailAddressType(EntityTypeBuilder<EntityEmailAddressType> builder)
        {
            builder.ToTable("EntityEmailAddressTypes");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("entity_email_address_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.Type)
                .IsRequired()
                .HasMaxLength(30);
        }

        void ConfigureEntityStatuatoryId(EntityTypeBuilder<EntityStatuatoryId> builder)
        {
            builder.ToTable("EntityStatuatoryIds");

            builder.Property(ci => ci.Id)
              .ForSqlServerUseSequenceHiLo("entity_statuatory_id_hilo")
              .IsRequired();

            builder.HasOne(ci => ci.EntityStatuatoryIdType)
                .WithMany()
                .HasForeignKey(ci => ci.EntityStatuatoryIdTypeId);

            builder.HasOne(p => p.EntityItem)
                .WithMany(b => b.StatuatoryIdList)
                .HasForeignKey(p => p.EntityItemId)
                .HasConstraintName("ForeignKey_EntityStatuatoryId_EntityItem");

        }

        void ConfigureEntityStatuatoryIdType(EntityTypeBuilder<EntityStatuatoryIdType> builder)
        {
            builder.ToTable("EntityStatuatoryIdTypes");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("entity_statuatory_id_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.Type)
                .IsRequired()
                .HasMaxLength(30);
        }

        void ConfigureEntityTelephoneNumber(EntityTypeBuilder<EntityTelephoneNumber> builder)
        {
            builder.ToTable("EntityTelephoneNumbers");

            builder.Property(ci => ci.Id)
              .ForSqlServerUseSequenceHiLo("entity_telephone_number_hilo")
              .IsRequired();

            builder.HasOne(ci => ci.EntityTelephoneNumberType)
                .WithMany()
                .HasForeignKey(ci => ci.EntityTelephoneNumberTypeId);

            builder.HasOne(p => p.EntityItem)
              .WithMany(b => b.EntityTelephoneNumberList)
              .HasForeignKey(p => p.EntityItemId)
              .HasConstraintName("ForeignKey_EntityTelephoneNumberList_EntityItem");

        }

        void ConfigureEntityTelephoneNumberType(EntityTypeBuilder<EntityTelephoneNumberType> builder)
        {
            builder.ToTable("EntityTelephoneNumberTypes");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("entity_telephone_number_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.Type)
                .IsRequired()
                .HasMaxLength(30);
        }

        void ConfigureEntityType(EntityTypeBuilder<EntityType> builder)
        {
            builder.ToTable("EntityTypes");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("entity_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.Type)
                .IsRequired()
                .HasMaxLength(30);
        }

        void ConfigureEntityItem(EntityTypeBuilder<EntityItem> builder)
        {
            builder.ToTable("EntityItems");

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("entity_item_hilo")
               .IsRequired();

            builder.Property(ci => ci.Name)
                           .IsRequired(true)
                           .HasMaxLength(50);

            builder.HasOne(ci => ci.EntityType)
                .WithMany()
                .HasForeignKey(ci => ci.EntityTypeId);

            

        }
    }
}
