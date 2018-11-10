using System.Collections.Generic;

namespace TUZ.Entities
{
    public class Truck
    {
        public TruckType Type { get; set; }
        public List<Place> Places { get; set; }   
    }
}