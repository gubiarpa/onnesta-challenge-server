using System;
using System.Collections.Generic;

namespace gubiarpa.onnesta.api.Models
{
    public partial class Applying
    {
        public Guid Idapplying { get; set; }
        public Guid Idjob { get; set; }
        public Guid Idapplicant { get; set; }

        public virtual Applicant IdapplicantNavigation { get; set; } = null!;
        public virtual Job IdjobNavigation { get; set; } = null!;
    }
}
