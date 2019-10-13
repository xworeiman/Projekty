using GRC.Domain.Models.Common;
using GRC.Domain.Models.Tree;
using GRC.Domain.Models.Versions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GRC.Domain.Extensions
{
    public interface IChildCreator<TChild,TParent>
        where TChild: IChild<TParent, TChild>
        where TParent : IParent<TChild, TParent>
    {
        TChild Create();
        TChild Create(TParent parent);
        //void SetParent();
    }

    internal class ProcessTreeChildCreator<TChild, TParent> : IChildCreator<TChild, TParent>
        where TChild : class, IChild<TParent, TChild>, IOriginRelation, IVersioned<TChild>, new()
        where TParent : class, IParent<TChild, TParent>, IOriginRelation, IVersioned<TParent>, new()
    {
        public TChild Create()
        {
            return new TChild();
        }

        public TChild Create(TParent parent)
        {
            var child = Create();
            child.Parent = parent;
            child.Version = parent.Version;
            child.Origin = parent.Origin;
            parent.Childs.Add(child);
            return child;
        }
    }
}
