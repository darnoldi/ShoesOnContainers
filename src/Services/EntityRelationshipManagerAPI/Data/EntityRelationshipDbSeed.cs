using Arnoldi.Services.EntityRelationshipManagerAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arnoldi.Services.EntityRelationshipManagerAPI.Data
{
    public class EntityRelationshipDbSeed
    {
        //public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        public static async Task SeedAsync(EntityRelationshipDbContext context)
        {
            //var context = (CatalogContext)applicationBuilder
            //    .ApplicationServices.GetService(typeof(CatalogContext));

            //RelationalDatabaseCreator databaseCreator =
            //    (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();
            //if (!await databaseCreator.ExistsAsync())
            //{
            //    System.Console.WriteLine("Creating database...");
            //    context.Database.EnsureCreated();

            //    databaseCreator.CreateTables();

            //    System.Console.WriteLine("Database and tables' creation complete.....");

            //    System.Console.WriteLine("Inserting Data.....");


            context.Database.Migrate();

            if (!context.EntityAddressTypes.Any())
            {
                context.EntityAddressTypes.AddRange(
                GetPreconfiguredEntityAddressTypes());
                await context.SaveChangesAsync();
            }

            if (!context.EntityEmailAddressTypes.Any())
            {
                context.EntityEmailAddressTypes.AddRange(
                GetPreconfiguredEntityEmailAddressTypes());
                await context.SaveChangesAsync();
            }

            if (!context.EntityStatuatoryIdTypes.Any())
            {
                context.EntityStatuatoryIdTypes.AddRange(
                GetPreconfiguredEntityStatuatoryIdTypes());
                await context.SaveChangesAsync();
            }

            if (!context.EntityTelephoneNumberTypes.Any())
            {
                context.EntityTelephoneNumberTypes.AddRange(
                GetPreconfiguredEntityTelephoneNumberTypes());
                await context.SaveChangesAsync();
            }

            if (!context.EntityItems.Any())
            {
                context.EntityItems.AddRange(
                GetPreconfiguredEntityItems());
                await context.SaveChangesAsync();
            }


        }

        static IEnumerable<EntityAddressType> GetPreconfiguredEntityAddressTypes()
        {
            return new List<EntityAddressType>()
                {
                    new EntityAddressType() { Type = "Physical"},
                    new EntityAddressType() { Type = "Postal"},
                    new EntityAddressType() { Type = "Work"},

                };
        }

        static IEnumerable<EntityEmailAddressType> GetPreconfiguredEntityEmailAddressTypes()
        {
            return new List<EntityEmailAddressType>()
                {
                    new EntityEmailAddressType() { Type = "Personal"},
                    new EntityEmailAddressType() { Type = "Work"},
                  
                };
        }

        static IEnumerable<EntityTelephoneNumberType> GetPreconfiguredEntityTelephoneNumberTypes()
        {
            return new List<EntityTelephoneNumberType>()
                {
                    new EntityTelephoneNumberType() { Type = "Home"},
                    new EntityTelephoneNumberType() { Type = "Work"},
                    new EntityTelephoneNumberType() { Type = "Mobile"},

                };
        }

        static IEnumerable<EntityStatuatoryIdType> GetPreconfiguredEntityStatuatoryIdTypes()
        {
            return new List<EntityStatuatoryIdType>()
                {
                    new EntityStatuatoryIdType() { Type = "Id Number"},
                    new EntityStatuatoryIdType() { Type = "Passport"},
                    new EntityStatuatoryIdType() { Type = "CK No"},
                    new EntityStatuatoryIdType() { Type = "Company Reg. No"},
                    new EntityStatuatoryIdType() { Type = "Non Profit"},

                };
        }

        static IEnumerable<EntityType> GetPreconfiguredEntityTypes()
        {
            return new List<EntityType>()
                {
                    new EntityType() { Type = "Person"},
                    new EntityType() { Type = "Closed Corp"},
                    new EntityType() { Type = "PTY LTD"},
                    new EntityType() { Type = "LLC"},
                    new EntityType() { Type = "Non Profit"},

                };
        }

        static IEnumerable<EntityItem> GetPreconfiguredEntityItems()
        {
            return new List<EntityItem>()
            {
                new EntityItem() {
                    Name = "Fred Flintstone",
                    EntityTypeId = 1,
                    EntityAddressList = new List<EntityAddress>()
                    {
                        new EntityAddress() { EntityAddressTypeId = 1, AddressLine1 ="23 the street", AddressLine2 = "some town", AddressLine3 = "The City", AddressCode = 1234},
                        new EntityAddress() { EntityAddressTypeId = 1, AddressLine1 ="14 an avenue", AddressLine2 = "another town", AddressLine3 = "Big City", AddressCode = 4536},
                        new EntityAddress() { EntityAddressTypeId = 2, AddressLine1 ="PO Box 12", AddressLine2 = "Dorp", AddressLine3 = "Stad", AddressCode = 0011},
                    },
                    EntityEmailAddressList =new List<EntityEmailAddress>()
                    {
                        new EntityEmailAddress() {  EntityEmailAddressTypeId = 1, EmailAddress = "email1@email.com" },
                        new EntityEmailAddress() {  EntityEmailAddressTypeId = 2, EmailAddress = "email2@email.com" },
                    },
                    EntityTelephoneNumberList = new List<EntityTelephoneNumber> ()
                    {
                        new EntityTelephoneNumber() {  EntityTelephoneNumberTypeId = 1, TelephoneNumber = "011 456 8790" },
                        new EntityTelephoneNumber() {  EntityTelephoneNumberTypeId = 3, TelephoneNumber = "082 555 6758" },
                    },
                    StatuatoryIdList = new List<EntityStatuatoryId> ()
                    {
                         new EntityStatuatoryId() {  EntityStatuatoryIdTypeId = 1, StatuatoryIdNumber = "456765432190876" },
                         new EntityStatuatoryId() {  EntityStatuatoryIdTypeId = 2, StatuatoryIdNumber = "5578990786434" },
                    },
                },
                new EntityItem() {
                    Name = "Microsoft",
                    EntityTypeId = 3,
                    EntityAddressList = new List<EntityAddress>()
                    {
                        new EntityAddress() { EntityAddressTypeId = 3, AddressLine1 = "At work", AddressLine2 = "Drag", AddressLine3 = "Slaapstad", AddressCode = 5746},
                        new EntityAddress() { EntityAddressTypeId = 3, AddressLine1 = "More Work", AddressLine2 = "PANDOOLA", AddressLine3 = "Far far away", AddressCode = 9864},
                        new EntityAddress() { EntityAddressTypeId = 2, AddressLine1 = "PO Box 18", AddressLine2 = "Sweet Town", AddressLine3 = "Xanadu", AddressCode = 6735},

                    },
                    EntityEmailAddressList =new List<EntityEmailAddress>()
                    {
                        new EntityEmailAddress() {  EntityEmailAddressTypeId = 1, EmailAddress = "email3@email.com" },
                        new EntityEmailAddress() {  EntityEmailAddressTypeId = 2, EmailAddress = "email4@email.com" },
                    },
                    EntityTelephoneNumberList = new List<EntityTelephoneNumber> ()
                    {
                        new EntityTelephoneNumber() {  EntityTelephoneNumberTypeId = 2, TelephoneNumber = "555 111 9876" },
                    },
                    StatuatoryIdList = new List<EntityStatuatoryId> ()
                    {
                         new EntityStatuatoryId() {  EntityStatuatoryIdTypeId = 4, StatuatoryIdNumber = "788 678  55455443  AA" },
                        
                    },
                },

            };
        }
    }
}


//                    new EntityAddress() { EntityAddressTypeId = 1, AddressLine1 = "1 Beach Rd", AddressLine2 = "Strand", AddressLine3 = "Kus City", AddressCode = 9345},
//                    new EntityAddress() { EntityAddressTypeId = 3, AddressLine1 = "1 Busines Center", AddressLine2 = "Office Park", AddressLine3 = "Hell", AddressCode = 0664},
 //                   new EntityAddress() { EntityAddressTypeId = 2, AddressLine1 = "PO Box 78", AddressLine2 = "Dorp2", AddressLine3 = "Stad2", AddressCode = 4321},