using System;
using System.Collections.Generic;

namespace GRC.Api.XModels
{
    public partial class ControlMechanismRelations
    {
        public ControlMechanismRelations()
        {
            InversePreviusVersion = new HashSet<ControlMechanismRelations>();
        }

        public int Id { get; set; }
        public int ProcessOriginId { get; set; }
        public int ControlMechanizmId { get; set; }
        public int? ProcessId { get; set; }
        public int? SubProcessId { get; set; }
        public int? StageId { get; set; }
        public int Version { get; set; }
        public int? PreviusVersionId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Removed { get; set; }

        public virtual ControlMechanism ControlMechanizm { get; set; }
        public virtual ControlMechanismRelations PreviusVersion { get; set; }
        public virtual Process Process { get; set; }
        public virtual ProcessOrigin ProcessOrigin { get; set; }
        public virtual Stage Stage { get; set; }
        public virtual SubProcess SubProcess { get; set; }
        public virtual ICollection<ControlMechanismRelations> InversePreviusVersion { get; set; }
    }
}
