using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingEquipments.WindowsForms.Data
{
    public class EquipmentType : ReferenceEntity
    {
        public override string ToString()
        {
            return Name;
        }
    }
}
