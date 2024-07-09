using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cellar
    {
        public int Id { get; set; }
      public string? Name { get; set; }
        public string? Family { get; set; }

        public string? Manufacturer { get; set; }

        public int? Temperature { get; set; }

        public CellarUser? User { get; set; }

        public int CellarUserId { get; set; }

        public List<Drawer>? Drawers { get; set; }

    }
}
