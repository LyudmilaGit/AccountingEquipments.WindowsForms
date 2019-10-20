using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingEquipments.WindowsForms.Data
{
    public class RetailEquipment : ReferenceEntity
    {
        public string Description { get; set; }
        public int EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; }
        
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

    }
}
