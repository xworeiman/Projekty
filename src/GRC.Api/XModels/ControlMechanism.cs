using System;
using System.Collections.Generic;

namespace GRC.Api.XModels
{
    public partial class ControlMechanism
    {
        public ControlMechanism()
        {
            ControlMechanismRelations = new HashSet<ControlMechanismRelations>();
            InversePreviusVersion = new HashSet<ControlMechanism>();
        }

        public int Id { get; set; }
        public int ProcessOriginId { get; set; }
        public int Version { get; set; }
        public int? PreviusVersionId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModyfiDate { get; set; }
        public string Name { get; set; }
        public string EnterpriseId { get; set; }
        public bool Removed { get; set; }
        public int State { get; set; }
        public int? OwnerId { get; set; }
        public string OwnerOrganisationUnit { get; set; }
        public bool Critical { get; set; }
        public bool Monitored { get; set; }

        public virtual ControlMechanism PreviusVersion { get; set; }
        public virtual ProcessOrigin ProcessOrigin { get; set; }
        public virtual ICollection<ControlMechanismRelations> ControlMechanismRelations { get; set; }
        public virtual ICollection<ControlMechanism> InversePreviusVersion { get; set; }
    }
}
