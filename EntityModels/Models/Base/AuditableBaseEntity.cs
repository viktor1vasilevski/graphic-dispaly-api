using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels.Models.Base
{
    public abstract class AuditableBaseEntity : BaseEntity
    {
        public virtual DateTime Created { get; set; }
    }
}
