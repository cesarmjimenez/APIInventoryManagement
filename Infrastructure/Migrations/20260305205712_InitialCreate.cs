using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsWareHouse = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductBatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductBatches_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductBatches_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockQuantity = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductBatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory_ProductBatches_ProductBatchId",
                        column: x => x.ProductBatchId,
                        principalTable: "ProductBatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Outbounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutboundNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OriginLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutboundUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutboundDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceivedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outbounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outbounds_Locations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Outbounds_Locations_OriginLocationId",
                        column: x => x.OriginLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Outbounds_Users_OutboundUserId",
                        column: x => x.OutboundUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Outbounds_Users_ReceivedUserId",
                        column: x => x.ReceivedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OutboundDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    OutboundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductBatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboundDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutboundDetails_Outbounds_OutboundId",
                        column: x => x.OutboundId,
                        principalTable: "Outbounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutboundDetails_ProductBatches_ProductBatchId",
                        column: x => x.ProductBatchId,
                        principalTable: "ProductBatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City", "IsActive", "IsWareHouse", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Av. Principal 123", "Ciudad A", true, true, "Bodega Central" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Calle Norte 45", "Ciudad B", true, true, "Bodega Norte" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Plaza 8 #12", "Ciudad A", true, false, "Tienda Centro" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Av. Sur 77", "Ciudad C", true, false, "Tienda Sur" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Km 10 Ruta", "Ciudad D", false, true, "Depósito Temporal" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "IsActive", "Name", "Sku" },
                values: new object[,]
                {
                    { new Guid("00000001-0000-0000-0000-000000000001"), "Genfar", true, "Paracetamol 500mg", "MED-PAR500" },
                    { new Guid("00000002-0000-0000-0000-000000000002"), "Advil", true, "Ibuprofeno 400mg", "MED-IBU400" },
                    { new Guid("00000003-0000-0000-0000-000000000003"), "GSK", true, "Amoxicilina 500mg", "MED-AMO500" },
                    { new Guid("00000004-0000-0000-0000-000000000004"), "Bayer", true, "Loratadina 10mg", "MED-LOR10" },
                    { new Guid("00000005-0000-0000-0000-000000000005"), "Merck", true, "Metformina 500mg", "MED-MET500" },
                    { new Guid("00000006-0000-0000-0000-000000000006"), "Pfizer", true, "Atorvastatina 20mg", "MED-ATR20" },
                    { new Guid("00000007-0000-0000-0000-000000000007"), "Ventolin", true, "Salbutamol Inhalador", "MED-SAL100" },
                    { new Guid("00000008-0000-0000-0000-000000000008"), "AstraZeneca", true, "Omeprazol 20mg", "MED-OMP20" },
                    { new Guid("00000009-0000-0000-0000-000000000009"), "MK", true, "Losartán 50mg", "MED-LOS50" },
                    { new Guid("0000000a-0000-0000-0000-00000000000a"), "Bayer", true, "Aspirina 100mg", "MED-ASP100" },
                    { new Guid("0000000b-0000-0000-0000-00000000000b"), "Laboratorios Stein", true, "Dexametasona 4mg", "MED-DEX4" },
                    { new Guid("0000000c-0000-0000-0000-00000000000c"), "Abbott", true, "Cefalexina 500mg", "MED-CEP500" },
                    { new Guid("0000000d-0000-0000-0000-00000000000d"), "Sandoz", true, "Azitromicina 500mg", "MED-AZI500" },
                    { new Guid("0000000e-0000-0000-0000-00000000000e"), "Sanofi", true, "Enalapril 10mg", "MED-ENL10" },
                    { new Guid("0000000f-0000-0000-0000-00000000000f"), "Roche", true, "Clonazepam 2mg", "MED-CLO2" },
                    { new Guid("00000010-0000-0000-0000-000000000010"), "Voltaren", true, "Diclofenaco 50mg", "MED-DIC50" },
                    { new Guid("00000011-0000-0000-0000-000000000011"), "Siegfried", true, "Ketorolaco 10mg", "MED-KET10" },
                    { new Guid("00000012-0000-0000-0000-000000000012"), "Zoloft", true, "Sertralina 50mg", "MED-SER50" },
                    { new Guid("00000013-0000-0000-0000-000000000013"), "Euthyrox", true, "Levotiroxina 50mcg", "MED-LEV50" },
                    { new Guid("00000014-0000-0000-0000-000000000014"), "Flanax", true, "Naproxeno 500mg", "MED-NAP500" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Jefe de Bodega" },
                    { 2, "Operario de Bodega" }
                });

            migrationBuilder.InsertData(
                table: "ProductBatches",
                columns: new[] { "Id", "BatchNumber", "ExpirationDate", "LocationId", "ProductId", "Quantity", "UnitCost" },
                values: new object[,]
                {
                    { new Guid("20000001-0000-0000-0000-000000000001"), "BATCH-1001", new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("00000001-0000-0000-0000-000000000001"), 150m, 5.50m },
                    { new Guid("20000002-0000-0000-0000-000000000002"), "BATCH-1002", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222222"), new Guid("00000001-0000-0000-0000-000000000001"), 80m, 5.75m },
                    { new Guid("20000003-0000-0000-0000-000000000003"), "BATCH-2001", new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("00000002-0000-0000-0000-000000000002"), 200m, 3.20m },
                    { new Guid("20000004-0000-0000-0000-000000000004"), "BATCH-2002", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new Guid("00000002-0000-0000-0000-000000000002"), 120m, 3.00m },
                    { new Guid("20000005-0000-0000-0000-000000000005"), "BATCH-3001", new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("00000003-0000-0000-0000-000000000003"), 50m, 45.00m },
                    { new Guid("20000006-0000-0000-0000-000000000006"), "BATCH-4001", new DateTime(2028, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("00000004-0000-0000-0000-000000000004"), 40m, 60.00m },
                    { new Guid("20000007-0000-0000-0000-000000000007"), "BATCH-5001", new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222222"), new Guid("00000005-0000-0000-0000-000000000005"), 300m, 12.00m },
                    { new Guid("20000008-0000-0000-0000-000000000008"), "BATCH-6001", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222222"), new Guid("00000006-0000-0000-0000-000000000006"), 90m, 110.00m },
                    { new Guid("20000009-0000-0000-0000-000000000009"), "BATCH-7001", new DateTime(2026, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new Guid("00000007-0000-0000-0000-000000000007"), 180m, 25.00m },
                    { new Guid("2000000a-0000-0000-0000-00000000000a"), "BATCH-8001", new DateTime(2025, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-4444-4444-4444-444444444444"), new Guid("00000008-0000-0000-0000-000000000008"), 220m, 8.50m },
                    { new Guid("2000000b-0000-0000-0000-00000000000b"), "BATCH-9001", new DateTime(2029, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("00000009-0000-0000-0000-000000000009"), 60m, 95.00m },
                    { new Guid("2000000c-0000-0000-0000-00000000000c"), "BATCH-10001", new DateTime(2027, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222222"), new Guid("0000000a-0000-0000-0000-00000000000a"), 70m, 40.00m },
                    { new Guid("2000000d-0000-0000-0000-00000000000d"), "BATCH-11001", new DateTime(2025, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new Guid("0000000b-0000-0000-0000-00000000000b"), 140m, 22.50m },
                    { new Guid("2000000e-0000-0000-0000-00000000000e"), "BATCH-12001", new DateTime(2026, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-4444-4444-4444-444444444444"), new Guid("0000000c-0000-0000-0000-00000000000c"), 95m, 18.00m },
                    { new Guid("2000000f-0000-0000-0000-00000000000f"), "BATCH-13001", new DateTime(2026, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("0000000d-0000-0000-0000-00000000000d"), 260m, 4.00m },
                    { new Guid("20000010-0000-0000-0000-000000000010"), "BATCH-14001", new DateTime(2028, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222222"), new Guid("0000000e-0000-0000-0000-00000000000e"), 30m, 150.00m },
                    { new Guid("20000011-0000-0000-0000-000000000011"), "BATCH-15001", new DateTime(2027, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new Guid("0000000f-0000-0000-0000-00000000000f"), 110m, 2.50m },
                    { new Guid("20000012-0000-0000-0000-000000000012"), "BATCH-16001", new DateTime(2029, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("00000010-0000-0000-0000-000000000010"), 45m, 180.00m },
                    { new Guid("20000013-0000-0000-0000-000000000013"), "BATCH-17001", new DateTime(2026, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-4444-4444-4444-444444444444"), new Guid("00000011-0000-0000-0000-000000000011"), 55m, 210.00m },
                    { new Guid("20000014-0000-0000-0000-000000000014"), "BATCH-18001", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222222"), new Guid("00000012-0000-0000-0000-000000000012"), 400m, 75.00m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "FullName", "IsActive", "LastName", "LocationId", "PasswordHash", "RoleId", "SecondLastName", "SecondName", "UserName" },
                values: new object[,]
                {
                    { new Guid("10000001-0000-0000-0000-000000000001"), "c.gonzalez@example.com", "Carlos", "Carlos Miguel Gonzalez Lopez", true, "Gonzalez", new Guid("11111111-1111-1111-1111-111111111111"), "HASHED_pw1", 1, "Lopez", "Miguel", "cgonzalez" },
                    { new Guid("10000002-0000-0000-0000-000000000002"), "m.perez@example.com", "Mariana", "Mariana Elena Perez Soto", true, "Perez", new Guid("11111111-1111-1111-1111-111111111111"), "HASHED_pw2", 2, "Soto", "Elena", "mperez" },
                    { new Guid("10000003-0000-0000-0000-000000000003"), "j.ramirez@example.com", "Javier", "Javier Ramirez", true, "Ramirez", new Guid("22222222-2222-2222-2222-222222222222"), "HASHED_pw3", 2, "", "", "jramirez" },
                    { new Guid("10000004-0000-0000-0000-000000000004"), "l.martinez@example.com", "Lucia", "Lucia Beatriz Martinez Diaz", true, "Martinez", new Guid("22222222-2222-2222-2222-222222222222"), "HASHED_pw4", 1, "Diaz", "Beatriz", "lmartinez" },
                    { new Guid("10000005-0000-0000-0000-000000000005"), "p.sanchez@example.com", "Pedro", "Pedro Alberto Sanchez", true, "Sanchez", new Guid("33333333-3333-3333-3333-333333333333"), "HASHED_pw5", 2, "", "Alberto", "psanchez" },
                    { new Guid("10000006-0000-0000-0000-000000000006"), "a.torres@example.com", "Ana", "Ana Torres", true, "Torres", new Guid("44444444-4444-4444-4444-444444444444"), "HASHED_pw6", 2, "", "", "atorres" },
                    { new Guid("10000007-0000-0000-0000-000000000007"), "r.vega@example.com", "Roberto", "Roberto Vega", true, "Vega", new Guid("11111111-1111-1111-1111-111111111111"), "HASHED_pw7", 2, "", "", "rvega" },
                    { new Guid("10000008-0000-0000-0000-000000000008"), "s.rios@example.com", "Sandra", "Sandra Mar Rios Garcia", true, "Rios", new Guid("33333333-3333-3333-3333-333333333333"), "HASHED_pw8", 1, "Garcia", "Mar", "srios" }
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "LocationId", "ProductBatchId", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("30000001-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("20000001-0000-0000-0000-000000000001"), 150m },
                    { new Guid("30000002-0000-0000-0000-000000000002"), new Guid("22222222-2222-2222-2222-222222222222"), new Guid("20000002-0000-0000-0000-000000000002"), 80m },
                    { new Guid("30000003-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("20000003-0000-0000-0000-000000000003"), 200m },
                    { new Guid("30000004-0000-0000-0000-000000000004"), new Guid("33333333-3333-3333-3333-333333333333"), new Guid("20000004-0000-0000-0000-000000000004"), 120m },
                    { new Guid("30000005-0000-0000-0000-000000000005"), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("20000005-0000-0000-0000-000000000005"), 50m },
                    { new Guid("30000006-0000-0000-0000-000000000006"), new Guid("22222222-2222-2222-2222-222222222222"), new Guid("20000007-0000-0000-0000-000000000007"), 300m },
                    { new Guid("30000007-0000-0000-0000-000000000007"), new Guid("44444444-4444-4444-4444-444444444444"), new Guid("2000000a-0000-0000-0000-00000000000a"), 220m },
                    { new Guid("30000008-0000-0000-0000-000000000008"), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("2000000b-0000-0000-0000-00000000000b"), 60m }
                });

            migrationBuilder.InsertData(
                table: "Outbounds",
                columns: new[] { "Id", "DestinationId", "OriginLocationId", "OutboundDate", "OutboundNumber", "OutboundUserId", "ReceivedDate", "ReceivedUserId", "Status" },
                values: new object[,]
                {
                    { new Guid("40000001-0000-0000-0000-000000000001"), new Guid("33333333-3333-3333-3333-333333333333"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "OUT-0001", new Guid("10000001-0000-0000-0000-000000000001"), null, null, "EnviadaASucursal" },
                    { new Guid("40000002-0000-0000-0000-000000000002"), new Guid("44444444-4444-4444-4444-444444444444"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "OUT-0002", new Guid("10000004-0000-0000-0000-000000000004"), null, null, "EnviadaASucursal" },
                    { new Guid("40000003-0000-0000-0000-000000000003"), new Guid("33333333-3333-3333-3333-333333333333"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "OUT-0003", new Guid("10000002-0000-0000-0000-000000000002"), new DateTime(2025, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("10000005-0000-0000-0000-000000000005"), "RecibidoEnSucursal" },
                    { new Guid("40000004-0000-0000-0000-000000000004"), new Guid("44444444-4444-4444-4444-444444444444"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OUT-0004", new Guid("10000007-0000-0000-0000-000000000007"), null, null, "EnviadaASucursal" },
                    { new Guid("40000005-0000-0000-0000-000000000005"), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OUT-0005", new Guid("10000006-0000-0000-0000-000000000006"), new DateTime(2026, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("10000001-0000-0000-0000-000000000001"), "RecibidoEnSucursal" }
                });

            migrationBuilder.InsertData(
                table: "OutboundDetails",
                columns: new[] { "Id", "OutboundId", "ProductBatchId", "Quantity", "SubTotal" },
                values: new object[,]
                {
                    { new Guid("50000001-0000-0000-0000-000000000001"), new Guid("40000001-0000-0000-0000-000000000001"), new Guid("20000001-0000-0000-0000-000000000001"), 10m, 55.0m },
                    { new Guid("50000002-0000-0000-0000-000000000002"), new Guid("40000001-0000-0000-0000-000000000001"), new Guid("20000005-0000-0000-0000-000000000005"), 5m, 225.0m },
                    { new Guid("50000003-0000-0000-0000-000000000003"), new Guid("40000002-0000-0000-0000-000000000002"), new Guid("20000003-0000-0000-0000-000000000003"), 20m, 64.0m },
                    { new Guid("50000004-0000-0000-0000-000000000004"), new Guid("40000003-0000-0000-0000-000000000003"), new Guid("20000006-0000-0000-0000-000000000006"), 2m, 120.0m },
                    { new Guid("50000005-0000-0000-0000-000000000005"), new Guid("40000003-0000-0000-0000-000000000003"), new Guid("20000007-0000-0000-0000-000000000007"), 15m, 180.0m },
                    { new Guid("50000006-0000-0000-0000-000000000006"), new Guid("40000005-0000-0000-0000-000000000005"), new Guid("2000000b-0000-0000-0000-00000000000b"), 3m, 285.0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_LocationId",
                table: "Inventory",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductBatchId",
                table: "Inventory",
                column: "ProductBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundDetails_OutboundId",
                table: "OutboundDetails",
                column: "OutboundId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundDetails_ProductBatchId",
                table: "OutboundDetails",
                column: "ProductBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Outbounds_DestinationId",
                table: "Outbounds",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Outbounds_OriginLocationId",
                table: "Outbounds",
                column: "OriginLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Outbounds_OutboundNumber",
                table: "Outbounds",
                column: "OutboundNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Outbounds_OutboundUserId",
                table: "Outbounds",
                column: "OutboundUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Outbounds_ReceivedUserId",
                table: "Outbounds",
                column: "ReceivedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBatches_BatchNumber",
                table: "ProductBatches",
                column: "BatchNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductBatches_LocationId",
                table: "ProductBatches",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBatches_ProductId",
                table: "ProductBatches",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Sku",
                table: "Products",
                column: "Sku",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LocationId",
                table: "Users",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "OutboundDetails");

            migrationBuilder.DropTable(
                name: "Outbounds");

            migrationBuilder.DropTable(
                name: "ProductBatches");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
