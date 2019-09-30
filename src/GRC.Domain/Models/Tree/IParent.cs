using System;
using System.Collections.Generic;
using System.Text;
using GRC.Domain.Models.Common;

namespace GRC.Domain.Models.Tree
{
    public interface IParent<TChild, TParent>
        where TParent: IParent<TChild, TParent>
        where TChild : IChild<TParent, TChild>
    {
        ICollection<TChild> Childs { get; set; }
    }

    public interface IParent
    {
        TChild GetChildById<TChild>(int id) where TChild : BaseEntity, IChild;
        ICollection<TChild> GetChilds<TChild>() where TChild : BaseEntity, IChild;
        void AddChild<TChild>(TChild child) where TChild : BaseEntity, IChild;
        bool RemoveChild<TChild>(TChild child) where TChild : BaseEntity, IChild;
    }
}
