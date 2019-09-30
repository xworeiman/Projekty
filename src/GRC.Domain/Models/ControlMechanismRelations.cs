using GRC.Domain.Models.Common;
using GRC.Domain.Models.Versions;
using System;
using System.Collections.Generic;

namespace GRC.Domain.Models
{
    public class ControlMechanismRelations : BaseEntity, IVersioned<ControlMechanismRelations>, IOriginRelation
    {
        public ControlMechanismRelations()
        {
            InversePreviusVersion = new HashSet<ControlMechanismRelations>();
        }

        public DateTime CreateDate { get; set; }
        //todo przeniesc to do statusu!
        public bool Removed { get; set; }

        public int ControlMechanizmId { get; set; }
        public virtual ControlMechanism ControlMechanizm { get; set; }
        public int? ProcessId { get; set; }
        public virtual Process Process { get; set; }
        public int? SubProcessId { get; set; }
        public virtual SubProcess SubProcess { get; set; }
        public int? StageId { get; set; }
        public virtual Stage Stage { get; set; }

        //IOriginRelation
        public virtual Origin Origin { get; set; }
        public int OriginId { get; set; }

        //IVersioned
        public virtual ControlMechanismRelations PreviusVersion { get; set; }
        public virtual ICollection<ControlMechanismRelations> InversePreviusVersion { get; set; }
        public int Version { get; set; }
        public int? PreviusVersionId { get; set; }
    }
}
