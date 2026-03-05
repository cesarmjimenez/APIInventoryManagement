using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Roles>().HasData(
            new Roles { Id = 1, RoleName = "Jefe de Bodega" },
            new Roles { Id = 2, RoleName = "Operario de Bodega" }
        );

        // Locations
        modelBuilder.Entity<Locations>().HasData(
            new Locations { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Bodega Central", Address = "Av. Principal 123", City = "Ciudad A", IsWareHouse = true, IsActive = true },
            new Locations { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Bodega Norte", Address = "Calle Norte 45", City = "Ciudad B", IsWareHouse = true, IsActive = true },
            new Locations { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Tienda Centro", Address = "Plaza 8 #12", City = "Ciudad A", IsWareHouse = false, IsActive = true },
            new Locations { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Tienda Sur", Address = "Av. Sur 77", City = "Ciudad C", IsWareHouse = false, IsActive = true },
            new Locations { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Depósito Temporal", Address = "Km 10 Ruta", City = "Ciudad D", IsWareHouse = true, IsActive = false }
        );

        // Products - Farmacéuticos
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
            new Users { Id = Guid.Parse("10000002-0000-0000-0000-000000000002"), FirstName = "Mariana", SecondName = "Elena", LastName = "Perez", SecondLastName = "Soto", FullName = "Mariana Elena Perez Soto", Email = "m.perez@example.com", UserName = "mperez", PasswordHash = "HASHED_pw2", IsActive = true, RoleId = 2, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new Users { Id = Guid.Parse("10000003-0000-0000-0000-000000000003"), FirstName = "Javier", SecondName = "", LastName = "Ramirez", SecondLastName = "", FullName = "Javier Ramirez", Email = "j.ramirez@example.com", UserName = "jramirez", PasswordHash = "HASHED_pw3", IsActive = true, RoleId = 2, LocationId = Guid.Parse("22222222-2222-2222-2222-222222222222") },
            new Users { Id = Guid.Parse("10000004-0000-0000-0000-000000000004"), FirstName = "Lucia", SecondName = "Beatriz", LastName = "Martinez", SecondLastName = "Diaz", FullName = "Lucia Beatriz Martinez Diaz", Email = "l.martinez@example.com", UserName = "lmartinez", PasswordHash = "HASHED_pw4", IsActive = true, RoleId = 1, LocationId = Guid.Parse("22222222-2222-2222-2222-222222222222") },
            new Users { Id = Guid.Parse("10000005-0000-0000-0000-000000000005"), FirstName = "Pedro", SecondName = "Alberto", LastName = "Sanchez", SecondLastName = "", FullName = "Pedro Alberto Sanchez", Email = "p.sanchez@example.com", UserName = "psanchez", PasswordHash = "HASHED_pw5", IsActive = true, RoleId = 2, LocationId = Guid.Parse("33333333-3333-3333-3333-333333333333") },
            new Users { Id = Guid.Parse("10000006-0000-0000-0000-000000000006"), FirstName = "Ana", SecondName = "", LastName = "Torres", SecondLastName = "", FullName = "Ana Torres", Email = "a.torres@example.com", UserName = "atorres", PasswordHash = "HASHED_pw6", IsActive = true, RoleId = 2, LocationId = Guid.Parse("44444444-4444-4444-4444-444444444444") },
            new Users { Id = Guid.Parse("10000007-0000-0000-0000-000000000007"), FirstName = "Roberto", SecondName = "", LastName = "Vega", SecondLastName = "", FullName = "Roberto Vega", Email = "r.vega@example.com", UserName = "rvega", PasswordHash = "HASHED_pw7", IsActive = true, RoleId = 2, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new Users { Id = Guid.Parse("10000008-0000-0000-0000-000000000008"), FirstName = "Sandra", SecondName = "Mar", LastName = "Rios", SecondLastName = "Garcia", FullName = "Sandra Mar Rios Garcia", Email = "s.rios@example.com", UserName = "srios", PasswordHash = "HASHED_pw8", IsActive = true, RoleId = 1, LocationId = Guid.Parse("33333333-3333-3333-3333-333333333333") }
        );

        // Product Batches
        modelBuilder.Entity<ProductBatches>().HasData(
            // Product 1 batches
            new ProductBatches { Id = Guid.Parse("20000001-0000-0000-0000-000000000001"), BatchNumber = "BATCH-1001", ExpirationDate = DateTime.Parse("2025-06-30"), Quantity = 150m, UnitCost = 5.50m, ProductId = Guid.Parse("00000001-0000-0000-0000-000000000001"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000002-0000-0000-0000-000000000002"), BatchNumber = "BATCH-1002", ExpirationDate = DateTime.Parse("2025-12-31"), Quantity = 80m, UnitCost = 5.75m, ProductId = Guid.Parse("00000001-0000-0000-0000-000000000001"), LocationId = Guid.Parse("22222222-2222-2222-2222-222222222222") },
            // Product 2
            new ProductBatches { Id = Guid.Parse("20000003-0000-0000-0000-000000000003"), BatchNumber = "BATCH-2001", ExpirationDate = DateTime.Parse("2026-03-15"), Quantity = 200m, UnitCost = 3.20m, ProductId = Guid.Parse("00000002-0000-0000-0000-000000000002"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000004-0000-0000-0000-000000000004"), BatchNumber = "BATCH-2002", ExpirationDate = DateTime.Parse("2026-08-01"), Quantity = 120m, UnitCost = 3.00m, ProductId = Guid.Parse("00000002-0000-0000-0000-000000000002"), LocationId = Guid.Parse("33333333-3333-3333-3333-333333333333") },
            // Product 3
            new ProductBatches { Id = Guid.Parse("20000005-0000-0000-0000-000000000005"), BatchNumber = "BATCH-3001", ExpirationDate = DateTime.Parse("2027-01-01"), Quantity = 50m, UnitCost = 45.00m, ProductId = Guid.Parse("00000003-0000-0000-0000-000000000003"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            // Product 4
            new ProductBatches { Id = Guid.Parse("20000006-0000-0000-0000-000000000006"), BatchNumber = "BATCH-4001", ExpirationDate = DateTime.Parse("2028-11-30"), Quantity = 40m, UnitCost = 60.00m, ProductId = Guid.Parse("00000004-0000-0000-0000-000000000004"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            // Product 5
            new ProductBatches { Id = Guid.Parse("20000007-0000-0000-0000-000000000007"), BatchNumber = "BATCH-5001", ExpirationDate = DateTime.Parse("2026-05-20"), Quantity = 300m, UnitCost = 12.00m, ProductId = Guid.Parse("00000005-0000-0000-0000-000000000005"), LocationId = Guid.Parse("22222222-2222-2222-2222-222222222222") },
            // Additional batches for variety
            new ProductBatches { Id = Guid.Parse("20000008-0000-0000-0000-000000000008"), BatchNumber = "BATCH-6001", ExpirationDate = DateTime.Parse("2025-09-10"), Quantity = 90m, UnitCost = 110.00m, ProductId = Guid.Parse("00000006-0000-0000-0000-000000000006"), LocationId = Guid.Parse("22222222-2222-2222-2222-222222222222") },
            new ProductBatches { Id = Guid.Parse("20000009-0000-0000-0000-000000000009"), BatchNumber = "BATCH-7001", ExpirationDate = DateTime.Parse("2026-02-28"), Quantity = 180m, UnitCost = 25.00m, ProductId = Guid.Parse("00000007-0000-0000-0000-000000000007"), LocationId = Guid.Parse("33333333-3333-3333-3333-333333333333") },
            new ProductBatches { Id = Guid.Parse("2000000a-0000-0000-0000-00000000000a"), BatchNumber = "BATCH-8001", ExpirationDate = DateTime.Parse("2025-07-14"), Quantity = 220m, UnitCost = 8.50m, ProductId = Guid.Parse("00000008-0000-0000-0000-000000000008"), LocationId = Guid.Parse("44444444-4444-4444-4444-444444444444") },
            new ProductBatches { Id = Guid.Parse("2000000b-0000-0000-0000-00000000000b"), BatchNumber = "BATCH-9001", ExpirationDate = DateTime.Parse("2029-10-10"), Quantity = 60m, UnitCost = 95.00m, ProductId = Guid.Parse("00000009-0000-0000-0000-000000000009"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("2000000c-0000-0000-0000-00000000000c"), BatchNumber = "BATCH-10001", ExpirationDate = DateTime.Parse("2027-04-18"), Quantity = 70m, UnitCost = 40.00m, ProductId = Guid.Parse("0000000a-0000-0000-0000-00000000000a"), LocationId = Guid.Parse("22222222-2222-2222-2222-222222222222") },
            new ProductBatches { Id = Guid.Parse("2000000d-0000-0000-0000-00000000000d"), BatchNumber = "BATCH-11001", ExpirationDate = DateTime.Parse("2025-12-25"), Quantity = 140m, UnitCost = 22.50m, ProductId = Guid.Parse("0000000b-0000-0000-0000-00000000000b"), LocationId = Guid.Parse("33333333-3333-3333-3333-333333333333") },
            new ProductBatches { Id = Guid.Parse("2000000e-0000-0000-0000-00000000000e"), BatchNumber = "BATCH-12001", ExpirationDate = DateTime.Parse("2026-06-06"), Quantity = 95m, UnitCost = 18.00m, ProductId = Guid.Parse("0000000c-0000-0000-0000-00000000000c"), LocationId = Guid.Parse("44444444-4444-4444-4444-444444444444") },
            new ProductBatches { Id = Guid.Parse("2000000f-0000-0000-0000-00000000000f"), BatchNumber = "BATCH-13001", ExpirationDate = DateTime.Parse("2026-09-09"), Quantity = 260m, UnitCost = 4.00m, ProductId = Guid.Parse("0000000d-0000-0000-0000-00000000000d"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000010-0000-0000-0000-000000000010"), BatchNumber = "BATCH-14001", ExpirationDate = DateTime.Parse("2028-01-01"), Quantity = 30m, UnitCost = 150.00m, ProductId = Guid.Parse("0000000e-0000-0000-0000-00000000000e"), LocationId = Guid.Parse("22222222-2222-2222-2222-222222222222") },
            new ProductBatches { Id = Guid.Parse("20000011-0000-0000-0000-000000000011"), BatchNumber = "BATCH-15001", ExpirationDate = DateTime.Parse("2027-03-03"), Quantity = 110m, UnitCost = 2.50m, ProductId = Guid.Parse("0000000f-0000-0000-0000-00000000000f"), LocationId = Guid.Parse("33333333-3333-3333-3333-333333333333") },
            new ProductBatches { Id = Guid.Parse("20000012-0000-0000-0000-000000000012"), BatchNumber = "BATCH-16001", ExpirationDate = DateTime.Parse("2029-08-08"), Quantity = 45m, UnitCost = 180.00m, ProductId = Guid.Parse("00000010-0000-0000-0000-000000000010"), LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new ProductBatches { Id = Guid.Parse("20000013-0000-0000-0000-000000000013"), BatchNumber = "BATCH-17001", ExpirationDate = DateTime.Parse("2026-11-11"), Quantity = 55m, UnitCost = 210.00m, ProductId = Guid.Parse("00000011-0000-0000-0000-000000000011"), LocationId = Guid.Parse("44444444-4444-4444-4444-444444444444") },
            new ProductBatches { Id = Guid.Parse("20000014-0000-0000-0000-000000000014"), BatchNumber = "BATCH-18001", ExpirationDate = DateTime.Parse("2025-05-05"), Quantity = 400m, UnitCost = 75.00m, ProductId = Guid.Parse("00000012-0000-0000-0000-000000000012"), LocationId = Guid.Parse("22222222-2222-2222-2222-222222222222") }
        );

        // Inventory - link some batches to stock entries
        modelBuilder.Entity<Inventory>().HasData(
            new Inventory { Id = Guid.Parse("30000001-0000-0000-0000-000000000001"), StockQuantity = 150m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000001-0000-0000-0000-000000000001") },
            new Inventory { Id = Guid.Parse("30000002-0000-0000-0000-000000000002"), StockQuantity = 80m, LocationId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ProductBatchId = Guid.Parse("20000002-0000-0000-0000-000000000002") },
            new Inventory { Id = Guid.Parse("30000003-0000-0000-0000-000000000003"), StockQuantity = 200m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000003-0000-0000-0000-000000000003") },
            new Inventory { Id = Guid.Parse("30000004-0000-0000-0000-000000000004"), StockQuantity = 120m, LocationId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ProductBatchId = Guid.Parse("20000004-0000-0000-0000-000000000004") },
            new Inventory { Id = Guid.Parse("30000005-0000-0000-0000-000000000005"), StockQuantity = 50m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("20000005-0000-0000-0000-000000000005") },
            new Inventory { Id = Guid.Parse("30000006-0000-0000-0000-000000000006"), StockQuantity = 300m, LocationId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ProductBatchId = Guid.Parse("20000007-0000-0000-0000-000000000007") },
            new Inventory { Id = Guid.Parse("30000007-0000-0000-0000-000000000007"), StockQuantity = 220m, LocationId = Guid.Parse("44444444-4444-4444-4444-444444444444"), ProductBatchId = Guid.Parse("2000000a-0000-0000-0000-00000000000a") },
            new Inventory { Id = Guid.Parse("30000008-0000-0000-0000-000000000008"), StockQuantity = 60m, LocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ProductBatchId = Guid.Parse("2000000b-0000-0000-0000-00000000000b") }
        );

        // Outbounds
        modelBuilder.Entity<Outbounds>().HasData(
            new Outbounds { Id = Guid.Parse("40000001-0000-0000-0000-000000000001"), OutboundNumber = "OUT-0001", Status = StatusEnum.EnviadaASucursal, OutboundDate = DateTime.Parse("2026-01-10"), ReceivedDate = null, OriginLocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), DestinationId = Guid.Parse("33333333-3333-3333-3333-333333333333"), OutboundUserId = Guid.Parse("10000001-0000-0000-0000-000000000001"), ReceivedUserId = null },
            new Outbounds { Id = Guid.Parse("40000002-0000-0000-0000-000000000002"), OutboundNumber = "OUT-0002", Status = StatusEnum.EnviadaASucursal, OutboundDate = DateTime.Parse("2026-02-05"), ReceivedDate = null, OriginLocationId = Guid.Parse("22222222-2222-2222-2222-222222222222"), DestinationId = Guid.Parse("44444444-4444-4444-4444-444444444444"), OutboundUserId = Guid.Parse("10000004-0000-0000-0000-000000000004"), ReceivedUserId = null },
            new Outbounds { Id = Guid.Parse("40000003-0000-0000-0000-000000000003"), OutboundNumber = "OUT-0003", Status = StatusEnum.RecibidoEnSucursal, OutboundDate = DateTime.Parse("2025-12-20"), ReceivedDate = DateTime.Parse("2025-12-22"), OriginLocationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), DestinationId = Guid.Parse("33333333-3333-3333-3333-333333333333"), OutboundUserId = Guid.Parse("10000002-0000-0000-0000-000000000002"), ReceivedUserId = Guid.Parse("10000005-0000-0000-0000-000000000005") },
            new Outbounds { Id = Guid.Parse("40000004-0000-0000-0000-000000000004"), OutboundNumber = "OUT-0004", Status = StatusEnum.EnviadaASucursal, OutboundDate = DateTime.Parse("2026-03-01"), ReceivedDate = null, OriginLocationId = Guid.Parse("33333333-3333-3333-3333-333333333333"), DestinationId = Guid.Parse("44444444-4444-4444-4444-444444444444"), OutboundUserId = Guid.Parse("10000007-0000-0000-0000-000000000007"), ReceivedUserId = null },
            new Outbounds { Id = Guid.Parse("40000005-0000-0000-0000-000000000005"), OutboundNumber = "OUT-0005", Status = StatusEnum.RecibidoEnSucursal, OutboundDate = DateTime.Parse("2026-01-15"), ReceivedDate = DateTime.Parse("2026-01-16"), OriginLocationId = Guid.Parse("22222222-2222-2222-2222-222222222222"), DestinationId = Guid.Parse("11111111-1111-1111-1111-111111111111"), OutboundUserId = Guid.Parse("10000006-0000-0000-0000-000000000006"), ReceivedUserId = Guid.Parse("10000001-0000-0000-0000-000000000001") }
        );

        // Outbound Details
        modelBuilder.Entity<OutboundDetails>().HasData(
            new OutboundDetails { Id = Guid.Parse("50000001-0000-0000-0000-000000000001"), Quantity = 10m, SubTotal = 55.0m, OutboundId = Guid.Parse("40000001-0000-0000-0000-000000000001"), ProductBatchId = Guid.Parse("20000001-0000-0000-0000-000000000001") },
            new OutboundDetails { Id = Guid.Parse("50000002-0000-0000-0000-000000000002"), Quantity = 5m, SubTotal = 225.0m, OutboundId = Guid.Parse("40000001-0000-0000-0000-000000000001"), ProductBatchId = Guid.Parse("20000005-0000-0000-0000-000000000005") },
            new OutboundDetails { Id = Guid.Parse("50000003-0000-0000-0000-000000000003"), Quantity = 20m, SubTotal = 64.0m, OutboundId = Guid.Parse("40000002-0000-0000-0000-000000000002"), ProductBatchId = Guid.Parse("20000003-0000-0000-0000-000000000003") },
            new OutboundDetails { Id = Guid.Parse("50000004-0000-0000-0000-000000000004"), Quantity = 2m, SubTotal = 120.0m, OutboundId = Guid.Parse("40000003-0000-0000-0000-000000000003"), ProductBatchId = Guid.Parse("20000006-0000-0000-0000-000000000006") },
            new OutboundDetails { Id = Guid.Parse("50000005-0000-0000-0000-000000000005"), Quantity = 15m, SubTotal = 180.0m, OutboundId = Guid.Parse("40000003-0000-0000-0000-000000000003"), ProductBatchId = Guid.Parse("20000007-0000-0000-0000-000000000007") },
            new OutboundDetails { Id = Guid.Parse("50000006-0000-0000-0000-000000000006"), Quantity = 3m, SubTotal = 285.0m, OutboundId = Guid.Parse("40000005-0000-0000-0000-000000000005"), ProductBatchId = Guid.Parse("2000000b-0000-0000-0000-00000000000b") }
        );
    }
}
