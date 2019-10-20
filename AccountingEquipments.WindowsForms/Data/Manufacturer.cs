using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingEquipments.WindowsForms.Data
{
    public class Manufacturer : ReferenceEntity
    {
         public string Email { get; set; }
         public string Phone { get; set; }
         public override string ToString()
         {
             return Name;
         }
    }
}
