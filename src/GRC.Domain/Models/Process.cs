using GRC.Domain.Models.Common;
using GRC.Domain.Models.Complex;
using GRC.Domain.Models.States;
using GRC.Domain.Models.Tree;
using GRC.Domain.Models.Versions;
using System;
using System.Collections.Generic;

namespace GRC.Domain.Models
{
    public class Process : BaseEntity, IVersioned<Process>, ICommonFields, IParent<SubProcess, Process>, IOriginRelation, IControlMechanismRelation /*, IParent */
    {
        public Process()
        {
            ControlMechanismRelations = new HashSet<ControlMechanismRelations>();
            InversePreviusVersion = new HashSet<Process>();
            Childs = new HashSet<SubProcess>();
        }

        //IOriginRelation
        public int OriginId { get; set; }
        public virtual Origin Origin { get; set; }
        //ICommonFields
        public string Name { get; set; }
        public string EnterpriseId { get; set; }
        public Owner Owner { get; set; }
        //public int? OwnerId { get; set; }
        //public string OwnerOrganisationUnit { get; set; }

        //przeniesc Removed do Stanu!
        public bool Removed { get; set; }
        public MfkStates State { get; set; }

        //dedykowane pola 
        public DateTime CreateDate { get; set; }
        public DateTime? AcceptDate { get; set; }
        public bool Substantial { get; set; }

        //IControlMechanismRelation
        public virtual ICollection<ControlMechanismRelations> ControlMechanismRelations { get; set; }
        //IParent
        public virtual ICollection<SubProcess> Childs { get; set; }

        //IVersioned
        public int Version { get; set; }
        public int? PreviusVersionId { get; set; }
        public virtual Process PreviusVersion { get; set; }
        public virtual ICollection<Process> InversePreviusVersion { get; set; }

        /*
        //under construction!

        public void AddChild<TChild>(TChild child) where TChild : BaseEntity, IChild
        {
            throw new NotImplementedException();
        }

        public Process CreateNewVersion()
        {
            //todo
            Process newVersion = MemberwiseClone() as Process;
            newVersion.Version++;
            newVersion.PreviusVersionId = this.Id;
            newVersion.PreviusVersion = this;
            newVersion.Id = 0;
            newVersion.State = 0;
            return newVersion;
        }

        public TChild GetChildById<TChild>(int id) where TChild : BaseEntity, IChild
        {
            throw new NotImplementedException();
        }

        public ICollection<TChild> GetChilds<TChild>() where TChild : BaseEntity, IChild
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
