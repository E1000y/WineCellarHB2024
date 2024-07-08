using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Bottle
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public string FullName{ get; set; }
        public int VintageYear{ get; set; }
        public int YearsOfKeep { get; set; }
        public string DomainName { get; set; }
        public DateOnly PeakInDate { get; set; }
        public DateOnly PeakOutDate { get; set; }

        public int GrapeVariety { get; set; }



    }
}
