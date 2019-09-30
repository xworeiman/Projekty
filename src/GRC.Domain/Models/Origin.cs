using GRC.Domain.Models.Common;
using System;
using System.Collections.Generic;

namespace GRC.Domain.Models
{
    public class Origin : BaseEntity
    {
        public Origin()
        {
            ControlMechanism = new HashSet<ControlMechanism>();
            ControlMechanismRelations = new HashSet<ControlMechanismRelations>();
            Process = new HashSet<Process>();
            Stage = new HashSet<Stage>();
            SubProcess = new HashSet<SubProcess>();
        }

        //public int Id { get; set; }

        //public int ActiveVersion { get; set; }

        //public int LastVersion { get; set; }

        public virtual ICollection<ControlMechanism> ControlMechanism { get; set; }
        public virtual ICollection<ControlMechanismRelations> ControlMechanismRelations { get; set; }
        public virtual ICollection<Process> Process { get; set; }
        public virtual ICollection<Stage> Stage { get; set; }
        public virtual ICollection<SubProcess> SubProcess { get; set; }
    }
}
