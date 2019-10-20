using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingEquipments.WindowsForms.Data
{
    public class LocationHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int RetailEquipmentId { get; set; }
        
        public RetailEquipment RetailEquipment { get; set; }

        public int? FromLocationId { get; set; }
        public Location FromLocation { get; set; }
        public int ToLocationId { get; set; }
        public Location ToLocation { get; set; }
    }
}
