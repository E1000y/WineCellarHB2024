using Models;

namespace WineCellarHB2024.DTOs
{
    public class CellarGetDTO
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }

        public string? Manufacturer { get; set; }

        public int? Temperature { get; set; }


        public string CellarUserId { get; set; }


    }
}