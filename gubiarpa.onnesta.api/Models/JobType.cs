using System;
using System.Collections.Generic;

namespace gubiarpa.onnesta.api.Models
{
    public partial class JobType
    {
        public JobType()
        {
            Jobs = new HashSet<Job>();
        }

        public Guid IdjobType { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
