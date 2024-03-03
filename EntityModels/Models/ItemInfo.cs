using EntityModels.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels.Models
{
    public class ItemInfo : AuditableBaseEntity
    {
        public string Color { get; set; }
        public int Number { get; set; }
        public string Label { get; set; }
    }
}
