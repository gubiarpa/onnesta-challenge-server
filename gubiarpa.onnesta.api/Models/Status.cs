﻿using System;
using System.Collections.Generic;

namespace gubiarpa.onnesta.api.Models
{
    public partial class Status
    {
        public Status()
        {
            Jobs = new HashSet<Job>();
        }

        public Guid Idstatus { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
