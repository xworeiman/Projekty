using GRC.Domain.Models.Common;
using GRC.Domain.Models.Complex;
using GRC.Domain.Models.States;
using GRC.Domain.Models.Tree;
using GRC.Domain.Models.Versions;
using System;
using System.Collections.Generic;

namespace GRC.Domain.Models
{
    public class SubProcess : BaseEntity, 
        IVersioned<SubProcess>, ICommonFields, IParent<Stage, SubProcess>, IChild<Process, SubProcess>, IOriginRelation, IControlMechanismRelation /*, IParent, IChild */
    {
        public SubProcess()
        {
            ControlMechanismRelations = new HashSet<ControlMechanismRelations>();
            InversePreviusVersion = new HashSet<SubProcess>();
            Childs = new HashSet<Stage>();
        }
        //dedykowane pola
        public DateTime CreateDate { get; set; }
        public DateTime ModyfiDate { get; set; }
        public bool Removed { get; set; }
        public MfkStates State { get; set; }

        //IOriginRelation
        public virtual Origin Origin { get; set; }
        public int OriginId { get; set; }

        //IControlMechanismRelation
        public virtual ICollection<ControlMechanismRelations> ControlMechanismRelations { get; set; }

        //IParent
        public virtual ICollection<Stage> Childs { get; set; }

        //IChild
        public virtual Process Parent { get; set; }
        public int ParentId { get; set; }

        //ICommonFields
        public string Name { get; set; }
        public string EnterpriseId { get; set; }
        public Owner Owner { get; set; }
        //public int? OwnerId { get; set; }
        //public string OwnerOrganisationUnit { get; set; }

        //IVersioned
        public int Version { get; set; }
        public int? PreviusVersionId { get; set; }
        public virtual SubProcess PreviusVersion { get; set; }
        public virtual ICollection<SubProcess> InversePreviusVersion { get; set; }
        /*
        public void AddChild<TChild>(TChild child) where TChild : BaseEntity, IChild
        {
            throw new NotImplementedException();
        }

        public TChild GetChildById<TChild>(int id) where TChild : BaseEntity, IChild
        {
            throw new NotImplementedException();
        }

        public ICollection<TChild> GetChilds<TChild>() where TChild : BaseEntity, IChild
        {
            throw new NotImplementedException();
        }

        public TParent GetParent<TParent>() where TParent : BaseEntity, IParent
        {
            throw new NotImplementedException();
        }

        public bool RemoveChild<TChild>(TChild child) where TChild : BaseEntity, IChild
        {
            throw new NotImplementedException();
        }
        */
    }
}
