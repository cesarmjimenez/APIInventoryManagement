using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // Roles
        modelBuilder.Entity<Roles>().HasData(
            new Roles { Id = 1, RoleName = "Jefe de Bodega" },
            new Roles { Id = 2, RoleName = "Operario de Bodega" }
        );

        // Locations
        modelBuilder.Entity<Locations>().HasData(
            new Locations { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Bodega Central", Address = "Av. Principal 123", City = "Ciudad A", IsWareHouse = true, IsActive = true },
            new Locations { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Tienda Centro", Address = "Plaza 8 #12", City = "Ciudad A", IsWareHouse = false, IsActive = true },
            new Locations { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Tienda Sur", Address = "Av. Sur 77", City = "Ciudad C", IsWareHouse = false, IsActive = true }
        );

        // Products
        modelBuilder.Entity<Products>().HasData(
            new Products { Id = Guid.Parse("00000001-0000-0000-0000-000000000001"), Sku = "MED-PAR500", Name = "Paracetamol 500mg", Brand = "Genfar", IsActive = true },
            new Products { Id = Guid.Parse("00000002-0000-0000-0000-000000000002"), Sku = "MED-IBU400", Name = "Ibuprofeno 400mg", Brand = "Advil", IsActive = true },
            new Products { Id = Guid.Parse("00000003-0000-0000-0000-000000000003"), Sku = "MED-AMO500", Name = "Amoxicilina 500mg", Brand = "GSK", IsActive = true },
            new Products { Id = Guid.Parse("00000004-0000-0000-0000-000000000004"), Sku = "MED-LOR10", Name = "Loratadina 10mg", Brand = "Bayer", IsActive = true },
            new Products { Id = Guid.Parse("00000005-0000-0000-0000-000000000005"), Sku = "MED-MET500", Name = "Metformina 500mg", Brand = "Merck", IsActive = true },
            new Products { Id = Guid.Parse("00000006-0000-0000-0000-000000000006"), Sku = "MED-ATR20", Name = "Atorvastatina 20mg", Brand = "Pfizer", IsActive = true },
            new Products { Id = Guid.Parse("00000007-0000-0000-0000-000000000007"), Sku = "MED-SAL100", Name = "Salbutamol Inhalador", Brand = "Ventolin", IsActive = true },
            new Products { Id = Guid.Parse("00000008-0000-0000-0000-000000000008"), Sku = "MED-OMP20", Name = "Omeprazol 20mg", Brand = "AstraZeneca", IsActive = true },
            new Products { Id = Guid.Parse("00000009-0000-0000-0000-000000000009"), Sku = "MED-LOS50", Name = "Losartán 50mg", Brand = "MK", IsActive = true },
            new Products { Id = Guid.Parse("0000000a-0000-0000-0000-00000000000a"), Sku = "MED-ASP100", Name = "Aspirina 100mg", Brand = "Bayer", IsActive = true },
            new Products { Id = Guid.Parse("0000000b-0000-0000-0000-00000000000b"), Sku = "MED-DEX4", Name = "Dexametasona 4mg", Brand = "Laboratorios Stein", IsActive = true },
            new Products { Id = Guid.Parse("0000000c-0000-0000-0000-00000000000c"), Sku = "MED-CEP500", Name = "Cefalexina 500mg", Brand = "Abbott", IsActive = true },
            new Products { Id = Guid.Parse("0000000d-0000-0000-0000-00000000000d"), Sku = "MED-AZI500", Name = "Azitromicina 500mg", Brand = "Sandoz", IsActive = true },
            new Products { Id = Guid.Parse("0000000e-0000-0000-0000-00000000000e"), Sku = "MED-ENL10", Name = "Enalapril 10mg", Brand = "Sanofi", IsActive = true },
            new Products { Id = Guid.Parse("0000000f-0000-0000-0000-00000000000f"), Sku = "MED-CLO2", Name = "Clonazepam 2mg", Brand = "Roche", IsActive = true },
            new Products { Id = Guid.Parse("00000010-0000-0000-0000-000000000010"), Sku = "MED-DIC50", Name = "Diclofenaco 50mg", Brand = "Voltaren", IsActive = true },
            new Products { Id = Guid.Parse("00000011-0000-0000-0000-000000000011"), Sku = "MED-KET10", Name = "Ketorolaco 10mg", Brand = "Siegfried", IsActive = true },
            new Products { Id = Guid.Parse("00000012-0000-0000-0000-000000000012"), Sku = "MED-SER50", Name = "Sertralina 50mg", Brand = "Zoloft", IsActive = true },
            new Products { Id = Guid.Parse("00000013-0000-0000-0000-000000000013"), Sku = "MED-LEV50", Name = "Levotiroxina 50mcg", Brand = "Euthyrox", IsActive = true },
            new Products { Id = Guid.Parse("00000014-0000-0000-0000-000000000014"), Sku = "MED-NAP500", Name = "Naproxeno 500mg", Brand = "Flanax", IsActive = true }
        );

        // Users
        modelBuilder.Entity<Users>().HasData(
            new Users { Id = Guid.Parse("10000001-0000-0000-0000-000000000001"), FirstName = "Carlos", SecondName = "Miguel", LastName = "Gonzalez", SecondLastName = "Lopez", FullName = "Carlos Miguel Gonzalez Lopez", Email = "c.gonzalez@example.com", UserName = "cgonzalez", PasswordHash = "HASHED_pw1", IsActive = true, RoleId = 1, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new Users { Id = Guid.Parse("10000002-0000-0000-0000-000000000002"), FirstName = "Mariana", SecondName = "Elena", LastName = "Perez", SecondLastName = "Soto", FullName = "Mariana Elena Perez Soto", Email = "m.perez@example.com", UserName = "mperez", PasswordHash = "HASHED_pw2", IsActive = true, RoleId = 2, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") }
        );

        // Product Batches
        modelBuilder.Entity<ProductBatches>().HasData(
            new ProductBatches { Id = Guid.Parse("20000001-0000-0000-0000-000000000001"), BatchNumber = "BATCH-1001", ExpirationDate = DateTime.Parse("2026-06-30"), Quantity = 500m, UnitCost = 5.50m, ProductId = Guid.Parse("00000001-0000-0000-0000-000000000001"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000002-0000-0000-0000-000000000002"), BatchNumber = "BATCH-1002", ExpirationDate = DateTime.Parse("2027-12-31"), Quantity = 300m, UnitCost = 5.75m, ProductId = Guid.Parse("00000001-0000-0000-0000-000000000001"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000003-0000-0000-0000-000000000003"), BatchNumber = "BATCH-2001", ExpirationDate = DateTime.Parse("2026-03-15"), Quantity = 600m, UnitCost = 3.20m, ProductId = Guid.Parse("00000002-0000-0000-0000-000000000002"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000004-0000-0000-0000-000000000004"), BatchNumber = "BATCH-2002", ExpirationDate = DateTime.Parse("2028-08-01"), Quantity = 400m, UnitCost = 3.00m, ProductId = Guid.Parse("00000002-0000-0000-0000-000000000002"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000005-0000-0000-0000-000000000005"), BatchNumber = "BATCH-3001", ExpirationDate = DateTime.Parse("2027-01-01"), Quantity = 350m, UnitCost = 45.00m, ProductId = Guid.Parse("00000003-0000-0000-0000-000000000003"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000006-0000-0000-0000-000000000006"), BatchNumber = "BATCH-4001", ExpirationDate = DateTime.Parse("2028-11-30"), Quantity = 250m, UnitCost = 60.00m, ProductId = Guid.Parse("00000004-0000-0000-0000-000000000004"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000007-0000-0000-0000-000000000007"), BatchNumber = "BATCH-5001", ExpirationDate = DateTime.Parse("2026-05-20"), Quantity = 800m, UnitCost = 12.00m, ProductId = Guid.Parse("00000005-0000-0000-0000-000000000005"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000008-0000-0000-0000-000000000008"), BatchNumber = "BATCH-6001", ExpirationDate = DateTime.Parse("2027-09-10"), Quantity = 200m, UnitCost = 110.00m, ProductId = Guid.Parse("00000006-0000-0000-0000-000000000006"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000009-0000-0000-0000-000000000009"), BatchNumber = "BATCH-7001", ExpirationDate = DateTime.Parse("2026-02-28"), Quantity = 450m, UnitCost = 25.00m, ProductId = Guid.Parse("00000007-0000-0000-0000-000000000007"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("2000000a-0000-0000-0000-00000000000a"), BatchNumber = "BATCH-8001", ExpirationDate = DateTime.Parse("2027-07-14"), Quantity = 500m, UnitCost = 8.50m, ProductId = Guid.Parse("00000008-0000-0000-0000-000000000008"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("2000000b-0000-0000-0000-00000000000b"), BatchNumber = "BATCH-9001", ExpirationDate = DateTime.Parse("2029-10-10"), Quantity = 300m, UnitCost = 95.00m, ProductId = Guid.Parse("00000009-0000-0000-0000-000000000009"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("2000000c-0000-0000-0000-00000000000c"), BatchNumber = "BATCH-10001", ExpirationDate = DateTime.Parse("2027-04-18"), Quantity = 400m, UnitCost = 40.00m, ProductId = Guid.Parse("0000000a-0000-0000-0000-00000000000a"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("2000000d-0000-0000-0000-00000000000d"), BatchNumber = "BATCH-11001", ExpirationDate = DateTime.Parse("2027-12-25"), Quantity = 350m, UnitCost = 22.50m, ProductId = Guid.Parse("0000000b-0000-0000-0000-00000000000b"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("2000000e-0000-0000-0000-00000000000e"), BatchNumber = "BATCH-12001", ExpirationDate = DateTime.Parse("2026-06-06"), Quantity = 280m, UnitCost = 18.00m, ProductId = Guid.Parse("0000000c-0000-0000-0000-00000000000c"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("2000000f-0000-0000-0000-00000000000f"), BatchNumber = "BATCH-13001", ExpirationDate = DateTime.Parse("2026-09-09"), Quantity = 600m, UnitCost = 4.00m, ProductId = Guid.Parse("0000000d-0000-0000-0000-00000000000d"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000010-0000-0000-0000-000000000010"), BatchNumber = "BATCH-14001", ExpirationDate = DateTime.Parse("2028-01-01"), Quantity = 150m, UnitCost = 150.00m, ProductId = Guid.Parse("0000000e-0000-0000-0000-00000000000e"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000011-0000-0000-0000-000000000011"), BatchNumber = "BATCH-15001", ExpirationDate = DateTime.Parse("2027-03-03"), Quantity = 500m, UnitCost = 2.50m, ProductId = Guid.Parse("0000000f-0000-0000-0000-00000000000f"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000012-0000-0000-0000-000000000012"), BatchNumber = "BATCH-16001", ExpirationDate = DateTime.Parse("2029-08-08"), Quantity = 200m, UnitCost = 180.00m, ProductId = Guid.Parse("00000010-0000-0000-0000-000000000010"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000013-0000-0000-0000-000000000013"), BatchNumber = "BATCH-17001", ExpirationDate = DateTime.Parse("2026-11-11"), Quantity = 180m, UnitCost = 210.00m, ProductId = Guid.Parse("00000011-0000-0000-0000-000000000011"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000014-0000-0000-0000-000000000014"), BatchNumber = "BATCH-18001", ExpirationDate = DateTime.Parse("2027-05-05"), Quantity = 700m, UnitCost = 75.00m, ProductId = Guid.Parse("00000012-0000-0000-0000-000000000012"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000015-0000-0000-0000-000000000015"), BatchNumber = "BATCH-19001", ExpirationDate = DateTime.Parse("2027-07-20"), Quantity = 400m, UnitCost = 30.00m, ProductId = Guid.Parse("00000013-0000-0000-0000-000000000013"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000016-0000-0000-0000-000000000016"), BatchNumber = "BATCH-20001", ExpirationDate = DateTime.Parse("2028-03-15"), Quantity = 550m, UnitCost = 6.00m, ProductId = Guid.Parse("00000014-0000-0000-0000-000000000014"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") }
        );

        // Inventory
        modelBuilder.Entity<Inventory>().HasData(
            new Inventory { Id = Guid.Parse("30000001-0000-0000-0000-000000000001"), StockQuantity = 500m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000001-0000-0000-0000-000000000001") },
            new Inventory { Id = Guid.Parse("30000002-0000-0000-0000-000000000002"), StockQuantity = 300m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000002-0000-0000-0000-000000000002") },
            new Inventory { Id = Guid.Parse("30000003-0000-0000-0000-000000000003"), StockQuantity = 600m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000003-0000-0000-0000-000000000003") },
            new Inventory { Id = Guid.Parse("30000004-0000-0000-0000-000000000004"), StockQuantity = 400m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000004-0000-0000-0000-000000000004") },
            new Inventory { Id = Guid.Parse("30000005-0000-0000-0000-000000000005"), StockQuantity = 350m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000005-0000-0000-0000-000000000005") },
            new Inventory { Id = Guid.Parse("30000006-0000-0000-0000-000000000006"), StockQuantity = 250m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000006-0000-0000-0000-000000000006") },
            new Inventory { Id = Guid.Parse("30000007-0000-0000-0000-000000000007"), StockQuantity = 800m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000007-0000-0000-0000-000000000007") },
            new Inventory { Id = Guid.Parse("30000008-0000-0000-0000-000000000008"), StockQuantity = 200m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000008-0000-0000-0000-000000000008") },
            new Inventory { Id = Guid.Parse("30000009-0000-0000-0000-000000000009"), StockQuantity = 450m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000009-0000-0000-0000-000000000009") },
            new Inventory { Id = Guid.Parse("3000000a-0000-0000-0000-00000000000a"), StockQuantity = 500m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("2000000a-0000-0000-0000-00000000000a") },
            new Inventory { Id = Guid.Parse("3000000b-0000-0000-0000-00000000000b"), StockQuantity = 300m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("2000000b-0000-0000-0000-00000000000b") },
            new Inventory { Id = Guid.Parse("3000000c-0000-0000-0000-00000000000c"), StockQuantity = 400m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("2000000c-0000-0000-0000-00000000000c") },
            new Inventory { Id = Guid.Parse("3000000d-0000-0000-0000-00000000000d"), StockQuantity = 350m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("2000000d-0000-0000-0000-00000000000d") },
            new Inventory { Id = Guid.Parse("3000000e-0000-0000-0000-00000000000e"), StockQuantity = 280m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("2000000e-0000-0000-0000-00000000000e") },
            new Inventory { Id = Guid.Parse("3000000f-0000-0000-0000-00000000000f"), StockQuantity = 600m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("2000000f-0000-0000-0000-00000000000f") },
            new Inventory { Id = Guid.Parse("30000010-0000-0000-0000-000000000010"), StockQuantity = 150m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000010-0000-0000-0000-000000000010") },
            new Inventory { Id = Guid.Parse("30000011-0000-0000-0000-000000000011"), StockQuantity = 500m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000011-0000-0000-0000-000000000011") },
            new Inventory { Id = Guid.Parse("30000012-0000-0000-0000-000000000012"), StockQuantity = 200m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000012-0000-0000-0000-000000000012") },
            new Inventory { Id = Guid.Parse("30000013-0000-0000-0000-000000000013"), StockQuantity = 180m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000013-0000-0000-0000-000000000013") },
            new Inventory { Id = Guid.Parse("30000014-0000-0000-0000-000000000014"), StockQuantity = 700m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000014-0000-0000-0000-000000000014") },
            new Inventory { Id = Guid.Parse("30000015-0000-0000-0000-000000000015"), StockQuantity = 400m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000015-0000-0000-0000-000000000015") },
            new Inventory { Id = Guid.Parse("30000016-0000-0000-0000-000000000016"), StockQuantity = 550m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000016-0000-0000-0000-000000000016") }
        );

        // Outbounds
        modelBuilder.Entity<Outbounds>().HasData(
            new Outbounds
            {
                Id = Guid.Parse("40000001-0000-0000-0000-000000000001"),
                OutboundNumber = "OUT-0001",
                Status = StatusEnum.EnviadaASucursal,
                OutboundDate = DateTime.Parse("2026-01-10"),
                ReceivedDate = null,
                OriginLocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                DestinationId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                OutboundUserId = Guid.Parse("10000001-0000-0000-0000-000000000001"),
                ReceivedUserId = null
            },
            new Outbounds
            {
                Id = Guid.Parse("40000002-0000-0000-0000-000000000002"),
                OutboundNumber = "OUT-0002",
                Status = StatusEnum.EnviadaASucursal,
                OutboundDate = DateTime.Parse("2026-02-05"),
                ReceivedDate = null,
                OriginLocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                DestinationId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                OutboundUserId = Guid.Parse("10000001-0000-0000-0000-000000000001"),
                ReceivedUserId = null
            }
        );

        // OutboundDetails
        modelBuilder.Entity<OutboundDetails>().HasData(
            new OutboundDetails { Id = Guid.Parse("50000001-0000-0000-0000-000000000001"), Quantity = 10m, SubTotal = 55.00m, OutboundId = Guid.Parse("40000001-0000-0000-0000-000000000001"), ProductBatchId = Guid.Parse("20000001-0000-0000-0000-000000000001") },
            new OutboundDetails { Id = Guid.Parse("50000002-0000-0000-0000-000000000002"), Quantity = 5m, SubTotal = 16.00m, OutboundId = Guid.Parse("40000001-0000-0000-0000-000000000001"), ProductBatchId = Guid.Parse("20000003-0000-0000-0000-000000000003") },

            new OutboundDetails { Id = Guid.Parse("50000003-0000-0000-0000-000000000003"), Quantity = 20m, SubTotal = 900.00m, OutboundId = Guid.Parse("40000002-0000-0000-0000-000000000002"), ProductBatchId = Guid.Parse("20000005-0000-0000-0000-000000000005") },
            new OutboundDetails { Id = Guid.Parse("50000004-0000-0000-0000-000000000004"), Quantity = 10m, SubTotal = 1100.00m, OutboundId = Guid.Parse("40000002-0000-0000-0000-000000000002"), ProductBatchId = Guid.Parse("20000008-0000-0000-0000-000000000008") },
            new OutboundDetails { Id = Guid.Parse("50000005-0000-0000-0000-000000000005"), Quantity = 8m, SubTotal = 1200.00m, OutboundId = Guid.Parse("40000002-0000-0000-0000-000000000002"), ProductBatchId = Guid.Parse("20000010-0000-0000-0000-000000000010") },
            new OutboundDetails { Id = Guid.Parse("50000006-0000-0000-0000-000000000006"), Quantity = 10m, SubTotal = 2100.00m, OutboundId = Guid.Parse("40000002-0000-0000-0000-000000000002"), ProductBatchId = Guid.Parse("20000013-0000-0000-0000-000000000013") }
        );
    }
}