using System;
using System.Collections.Generic;

namespace gubiarpa.onnesta.api.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Applicants = new HashSet<Applicant>();
        }

        public Guid IddocumentType { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}
