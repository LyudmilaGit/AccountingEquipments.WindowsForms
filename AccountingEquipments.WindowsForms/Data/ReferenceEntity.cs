using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingEquipments.WindowsForms.Data
{
    public class ReferenceEntity : IEntityName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
