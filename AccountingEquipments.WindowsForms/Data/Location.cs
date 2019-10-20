using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingEquipments.WindowsForms.Data
{
    public class Location : ReferenceEntity
    {
        public string Address { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }
}
