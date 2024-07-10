﻿using Models;

namespace WineCellarHB2024.DTOs
{
    internal class CellarGetDTO
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }

        public string? Manufacturer { get; set; }

        public int? Temperature { get; set; }


        public int CellarUserId { get; set; }


    }
}