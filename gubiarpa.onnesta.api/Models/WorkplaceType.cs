using System;
using System.Collections.Generic;

namespace gubiarpa.onnesta.api.Models
{
    public partial class WorkplaceType
    {
        public WorkplaceType()
        {
            Jobs = new HashSet<Job>();
        }

        public Guid IdworkplaceType { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
