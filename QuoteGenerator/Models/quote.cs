using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteGenerator.Models
{
    public class quote
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DOB { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int DUI { get; set; }
        public int tickets { get; set; }
        public int Insurance { get; set; }
        public int Quote { get; set; }

    }
}
