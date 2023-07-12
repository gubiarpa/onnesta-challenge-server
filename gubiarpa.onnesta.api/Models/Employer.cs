using System;
using System.Collections.Generic;

namespace gubiarpa.onnesta.api.Models
{
    public partial class Employer
    {
        public Employer()
        {
            Jobs = new HashSet<Job>();
        }

        public Guid Idemployer { get; set; }
        public string Description { get; set; } = null!;
        public string? Ruc { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
