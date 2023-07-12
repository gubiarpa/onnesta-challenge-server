using System;
using System.Collections.Generic;

namespace gubiarpa.onnesta.api.Models
{
    public partial class Job
    {
        public Job()
        {
            Applyings = new HashSet<Applying>();
            Idkeywords = new HashSet<Keyword>();
        }

        public Guid Idjob { get; set; }
        public string JobTitle { get; set; } = null!;
        public Guid Idemployer { get; set; }
        public decimal? Salary { get; set; }
        public Guid IdworkplaceType { get; set; }
        public Guid IdjobType { get; set; }
        public Guid Idstatus { get; set; }

        public virtual Employer IdemployerNavigation { get; set; } = null!;
        public virtual JobType IdjobTypeNavigation { get; set; } = null!;
        public virtual Status IdstatusNavigation { get; set; } = null!;
        public virtual WorkplaceType IdworkplaceTypeNavigation { get; set; } = null!;
        public virtual ICollection<Applying> Applyings { get; set; }

        public virtual ICollection<Keyword> Idkeywords { get; set; }
    }
}
