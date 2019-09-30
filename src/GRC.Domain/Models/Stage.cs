using GRC.Domain.Models.Common;
using GRC.Domain.Models.Complex;
using GRC.Domain.Models.States;
using GRC.Domain.Models.Tree;
using GRC.Domain.Models.Versions;
using System;
using System.Collections.Generic;

namespace GRC.Domain.Models
{
    public class Stage : BaseEntity, 
        IVersioned<Stage>, ICommonFields, IChild<SubProcess, Stage>, IOriginRelation, IControlMechanismRelation
    {
        public Stage()
        {
            ControlMechanismRelations = new HashSet<ControlMechanismRelations>();
            InversePreviusVersion = new HashSet<Stage>();
        }

        //dedykowane pola
        public DateTime CreateDate { get; set; }
        public DateTime ModyfiDate { get; set; }
        public bool Removed { get; set; }
        public MfkStates State { get; set; }

        //ICommonFields
        public string Name { get; set; }
        public string EnterpriseId { get; set; }
        public Owner Owner { get; set; }
        //public int? OwnerId { get; set; }
        //public string OwnerOrganisationUnit { get; set; }
        
        //IControlMechanismRelation
        public virtual ICollection<ControlMechanismRelations> ControlMechanismRelations { get; set; }

        //IChild
        public virtual SubProcess Parent { get; set; }
        public int ParentId { get; set; }

        //IOriginRelation
        public virtual Origin Origin { get; set; }
        public int OriginId { get; set; }

        //IVersioned
        public int? PreviusVersionId { get; set; }
        public int Version { get; set; }
        public virtual Stage PreviusVersion { get; set; }
        public virtual ICollection<Stage> InversePreviusVersion { get; set; }
    }
}
