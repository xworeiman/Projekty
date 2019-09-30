using System;
using System.Collections.Generic;

namespace GRC.Api.XModels
{
    public partial class SubProcess
    {
        public SubProcess()
        {
            ControlMechanismRelations = new HashSet<ControlMechanismRelations>();
            InversePreviusVersion = new HashSet<SubProcess>();
            Stage = new HashSet<Stage>();
        }

        public int Id { get; set; }
        public int ParrentId { get; set; }
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

        public virtual Process Parrent { get; set; }
        public virtual SubProcess PreviusVersion { get; set; }
        public virtual ProcessOrigin ProcessOrigin { get; set; }
        public virtual ICollection<ControlMechanismRelations> ControlMechanismRelations { get; set; }
        public virtual ICollection<SubProcess> InversePreviusVersion { get; set; }
        public virtual ICollection<Stage> Stage { get; set; }
    }
}
