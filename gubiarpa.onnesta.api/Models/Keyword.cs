using System;
using System.Collections.Generic;

namespace gubiarpa.onnesta.api.Models
{
    public partial class Keyword
    {
        public Keyword()
        {
            Idjobs = new HashSet<Job>();
        }

        public Guid Idkeyword { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Job> Idjobs { get; set; }
    }
}
