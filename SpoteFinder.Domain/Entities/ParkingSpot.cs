using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpoteFinder.Domain.Entities
{
    public class ParkingSpot
    {
        [Key] 
        public int SpotId { get; set; }
        public string Address { get; set; }
        public decimal PricePerHour { get; set; }
        public bool IsAvailable { get; set; }
    }
}
