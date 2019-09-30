using GRC.Domain.Models.Common;
using GRC.Domain.Models.Complex;
using GRC.Domain.Models.States;
using GRC.Domain.Models.Versions;
using System;
using System.Collections.Generic;

namespace GRC.Domain.Models
{
    public class ControlMechanism : BaseEntity, IVersioned<ControlMechanism>, ICommonFields, IOriginRelation
    {
        public ControlMechanism()
        {
            ControlMechanismRelations = new HashSet<ControlMechanismRelations>();
            InversePreviusVersion = new HashSet<ControlMechanism>();
        }

        //public int Id { get; set; }
        public int OriginId { get; set; }
        
        
        public DateTime CreateDate { get; set; }
        public DateTime ModyfiDate { get; set; }
        public string Name { get; set; }
        public string EnterpriseId { get; set; }
        public bool Removed { get; set; }
        public MfkStates State { get; set; }
        public Owner Owner { get; set; }
        //public int? OwnerId { get; set; }
        //public string OwnerOrganisationUnit { get; set; }
        public bool Critical { get; set; }
        public bool Monitored { get; set; }

        public virtual Origin Origin { get; set; }
        public virtual ICollection<ControlMechanismRelations> ControlMechanismRelations { get; set; }
        
        public virtual ControlMechanism PreviusVersion { get; set; }
        public virtual ICollection<ControlMechanism> InversePreviusVersion { get; set; }
        public int Version { get; set; }
        public int? PreviusVersionId { get; set; }
    }
}
