﻿namespace WineCellarHB2024.DTOs
{
    public class BottlePostDTO
    {
        public string? Color { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public int? VintageYear { get; set; }
        public int? YearsOfKeep { get; set; }
        public string? DomainName { get; set; }
        public DateOnly? PeakInDate { get; set; }
        public DateOnly? PeakOutDate { get; set; }

        public string? GrapeVariety { get; set; }

        public int? Tava { get; set; }

        public int? Capacity { get; set; }

        public string? WineMakerName { get; set; } = string.Empty;

        public string? VintageName { get; set; }

        public string? Aroma { get; set; }

        public int? Price { get; set; }

        public DateOnly? PurchaseDate { get; set; }

        public string? RelatedMeals { get; set; }

        public int? DrawerPosition { get; set; }
        public int DrawerId { get; set; }
    }
}