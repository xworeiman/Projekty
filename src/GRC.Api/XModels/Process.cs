using System;
using System.Collections.Generic;

namespace GRC.Api.XModels
{
    public partial class Process
    {
        public Process()
        {
            ControlMechanismRelations = new HashSet<ControlMechanismRelations>();
            InversePreviusVersion = new HashSet<Process>();
            SubProcess = new HashSet<SubProcess>();
        }

        public int Id { get; set; }
        public int ProcessOriginId { get; set; }
        public int Version { get; set; }
        public int? PreviusVersionId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? AcceptDate { get; set; }
        public string Name { get; set; }
        public string EnterpriseId { get; set; }
        public bool Removed { get; set; }
        public int State { get; set; }
        public int? OwnerId { get; set; }
        public string OwnerOrganisationUnit { get; set; }
        public bool Substantial { get; set; }

        public virtual Process PreviusVersion { get; set; }
        public virtual ProcessOrigin ProcessOrigin { get; set; }
        public virtual ICollection<ControlMechanismRelations> ControlMechanismRelations { get; set; }
        public virtual ICollection<Process> InversePreviusVersion { get; set; }
        public virtual ICollection<SubProcess> SubProcess { get; set; }
    }
}
