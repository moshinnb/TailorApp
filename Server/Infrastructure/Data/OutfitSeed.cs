using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Infrastructure.Data
{
    public static class OutfitSeed
    {
        public static void SeedOutfits(ModelBuilder builder)
        {
            var shirtId = new Guid("11111111-1111-1111-1111-111111111111");
            var pantId = new Guid("22222222-2222-2222-2222-222222222222");
            var blazerId = new Guid("33333333-3333-3333-3333-333333333333");

            builder.Entity<Outfit>().HasData(
                new Outfit { Id = shirtId, Name = "Shirt", BasePrice = 500 },
                new Outfit { Id = pantId, Name = "Pant", BasePrice = 600 },
                new Outfit { Id = blazerId, Name = "Blazer", BasePrice = 1500 }
            );
            builder.Entity<OutfitMeasurementField>().HasData(

                // ===== Shirt =====
                new OutfitMeasurementField
                {
                    Id = Guid.Parse("aaaa1111-0000-0000-0000-000000000001"),
                    OutfitId = shirtId,
                    FieldName = "Chest",
                    FieldType = MeasurementFieldType.Number,
                    Unit = MeasurementUnit.Inch,
                    DisplayOrder = 1
                },
                new OutfitMeasurementField
                {
                    Id = Guid.Parse("aaaa1111-0000-0000-0000-000000000002"),
                    OutfitId = shirtId,
                    FieldName = "Shoulder",
                    FieldType = MeasurementFieldType.Number,
                    Unit = MeasurementUnit.Inch,
                    DisplayOrder = 2
                },
                new OutfitMeasurementField
                {
                    Id = Guid.Parse("aaaa1111-0000-0000-0000-000000000003"),
                    OutfitId = shirtId,
                    FieldName = "Sleeve Length",
                    FieldType = MeasurementFieldType.Number,
                    Unit = MeasurementUnit.Inch,
                    DisplayOrder = 3
                },
                new OutfitMeasurementField
                {
                    Id = Guid.Parse("aaaa1111-0000-0000-0000-000000000004"),
                    OutfitId = shirtId,
                    FieldName = "Shirt Length",
                    FieldType = MeasurementFieldType.Number,
                    Unit = MeasurementUnit.Inch,
                    DisplayOrder = 4
                },

                // ===== Pant =====
                new OutfitMeasurementField
                {
                    Id = Guid.Parse("bbbb2222-0000-0000-0000-000000000001"),
                    OutfitId = pantId,
                    FieldName = "Waist",
                    FieldType = MeasurementFieldType.Number,
                    Unit = MeasurementUnit.Inch,
                    DisplayOrder = 1
                },
                new OutfitMeasurementField
                {
                    Id = Guid.Parse("bbbb2222-0000-0000-0000-000000000002"),
                    OutfitId = pantId,
                    FieldName = "Hip",
                    FieldType = MeasurementFieldType.Number,
                    Unit = MeasurementUnit.Inch,
                    DisplayOrder = 2
                },
                new OutfitMeasurementField
                {
                    Id = Guid.Parse("bbbb2222-0000-0000-0000-000000000003"),
                    OutfitId = pantId,
                    FieldName = "Length",
                    FieldType = MeasurementFieldType.Number,
                    Unit = MeasurementUnit.Inch,
                    DisplayOrder = 3
                },

                // ===== Blazer =====
                new OutfitMeasurementField
                {
                    Id = Guid.Parse("cccc3333-0000-0000-0000-000000000001"),
                    OutfitId = blazerId,
                    FieldName = "Chest",
                    FieldType = MeasurementFieldType.Number,
                    Unit = MeasurementUnit.Inch,
                    DisplayOrder = 1
                },
                new OutfitMeasurementField
                {
                    Id = Guid.Parse("cccc3333-0000-0000-0000-000000000002"),
                    OutfitId = blazerId,
                    FieldName = "Shoulder",
                    FieldType = MeasurementFieldType.Number,
                    Unit = MeasurementUnit.Inch,
                    DisplayOrder = 2
                },
                new OutfitMeasurementField
                {
                    Id = Guid.Parse("cccc3333-0000-0000-0000-000000000003"),
                    OutfitId = blazerId,
                    FieldName = "Blazer Length",
                    FieldType = MeasurementFieldType.Number,
                    Unit = MeasurementUnit.Inch,
                    DisplayOrder = 3
                }
            );

        }
    }
}
