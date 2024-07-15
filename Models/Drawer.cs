using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Drawer
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int NbOfBottlesPerDrawer { get; set; }

        public Cellar? Cellar { get; set; }

        public int CellarId { get; set; }

        public List<Bottle>? Bottles { get; set; }

    }
}
