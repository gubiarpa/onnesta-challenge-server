using System;
using System.Collections.Generic;

namespace gubiarpa.onnesta.api.Models
{
    public partial class Applicant
    {
        public Applicant()
        {
            Applyings = new HashSet<Applying>();
        }

        public Guid Idapplicant { get; set; }
        public string FullName { get; set; } = null!;
        public Guid IddocumentType { get; set; }
        public string DocumentNumber { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual DocumentType IddocumentTypeNavigation { get; set; } = null!;
        public virtual ICollection<Applying> Applyings { get; set; }
    }
}
