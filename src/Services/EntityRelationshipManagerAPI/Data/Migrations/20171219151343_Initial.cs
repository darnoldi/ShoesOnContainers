using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Arnoldi.Services.EntityRelationshipManagerAPI.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "entity_address_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "entity_address_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "entity_email_address_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "entity_email_address_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "entity_item_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "entity_statuatory_id_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "entity_statuatory_id_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "entity_telephone_number_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "entity_telephone_number_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "entity_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "EntityAddressTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityAddressTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityEmailAddressTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityEmailAddressTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityStatuatoryIdTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityStatuatoryIdTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityTelephoneNumberTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTelephoneNumberTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EntityTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityItems_EntityTypes_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "EntityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    AddressCode = table.Column<int>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    EntityAddressTypeId = table.Column<int>(nullable: false),
                    EntityItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityAddresses_EntityAddressTypes_EntityAddressTypeId",
                        column: x => x.EntityAddressTypeId,
                        principalTable: "EntityAddressTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_EntityAddressList_EntityItem",
                        column: x => x.EntityItemId,
                        principalTable: "EntityItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityEmailAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    EntityEmailAddressTypeId = table.Column<int>(nullable: false),
                    EntityItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityEmailAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityEmailAddresses_EntityEmailAddressTypes_EntityEmailAddressTypeId",
                        column: x => x.EntityEmailAddressTypeId,
                        principalTable: "EntityEmailAddressTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_EntityEmailAddressList_EntityItem",
                        column: x => x.EntityItemId,
                        principalTable: "EntityItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityStatuatoryIds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EntityItemId = table.Column<int>(nullable: false),
                    EntityStatuatoryIdTypeId = table.Column<int>(nullable: false),
                    StatuatoryIdNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityStatuatoryIds", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_EntityStatuatoryId_EntityItem",
                        column: x => x.EntityItemId,
                        principalTable: "EntityItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityStatuatoryIds_EntityStatuatoryIdTypes_EntityStatuatoryIdTypeId",
                        column: x => x.EntityStatuatoryIdTypeId,
                        principalTable: "EntityStatuatoryIdTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityTelephoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EntityItemId = table.Column<int>(nullable: false),
                    EntityTelephoneNumberTypeId = table.Column<int>(nullable: false),
                    TelephoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTelephoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_EntityTelephoneNumberList_EntityItem",
                        column: x => x.EntityItemId,
                        principalTable: "EntityItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityTelephoneNumbers_EntityTelephoneNumberTypes_EntityTelephoneNumberTypeId",
                        column: x => x.EntityTelephoneNumberTypeId,
                        principalTable: "EntityTelephoneNumberTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityAddresses_EntityAddressTypeId",
                table: "EntityAddresses",
                column: "EntityAddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityAddresses_EntityItemId",
                table: "EntityAddresses",
                column: "EntityItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityEmailAddresses_EntityEmailAddressTypeId",
                table: "EntityEmailAddresses",
                column: "EntityEmailAddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityEmailAddresses_EntityItemId",
                table: "EntityEmailAddresses",
                column: "EntityItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityItems_EntityTypeId",
                table: "EntityItems",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityStatuatoryIds_EntityItemId",
                table: "EntityStatuatoryIds",
                column: "EntityItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityStatuatoryIds_EntityStatuatoryIdTypeId",
                table: "EntityStatuatoryIds",
                column: "EntityStatuatoryIdTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityTelephoneNumbers_EntityItemId",
                table: "EntityTelephoneNumbers",
                column: "EntityItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityTelephoneNumbers_EntityTelephoneNumberTypeId",
                table: "EntityTelephoneNumbers",
                column: "EntityTelephoneNumberTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityAddresses");

            migrationBuilder.DropTable(
                name: "EntityEmailAddresses");

            migrationBuilder.DropTable(
                name: "EntityStatuatoryIds");

            migrationBuilder.DropTable(
                name: "EntityTelephoneNumbers");

            migrationBuilder.DropTable(
                name: "EntityAddressTypes");

            migrationBuilder.DropTable(
                name: "EntityEmailAddressTypes");

            migrationBuilder.DropTable(
                name: "EntityStatuatoryIdTypes");

            migrationBuilder.DropTable(
                name: "EntityItems");

            migrationBuilder.DropTable(
                name: "EntityTelephoneNumberTypes");

            migrationBuilder.DropTable(
                name: "EntityTypes");

            migrationBuilder.DropSequence(
                name: "entity_address_hilo");

            migrationBuilder.DropSequence(
                name: "entity_address_type_hilo");

            migrationBuilder.DropSequence(
                name: "entity_email_address_hilo");

            migrationBuilder.DropSequence(
                name: "entity_email_address_type_hilo");

            migrationBuilder.DropSequence(
                name: "entity_item_hilo");

            migrationBuilder.DropSequence(
                name: "entity_statuatory_id_hilo");

            migrationBuilder.DropSequence(
                name: "entity_statuatory_id_type_hilo");

            migrationBuilder.DropSequence(
                name: "entity_telephone_number_hilo");

            migrationBuilder.DropSequence(
                name: "entity_telephone_number_type_hilo");

            migrationBuilder.DropSequence(
                name: "entity_type_hilo");
        }
    }
}
