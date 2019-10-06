using GRC.Domain.Models;
using GRC.Domain.Models.Common;
using GRC.Domain.Models.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace GRC.Domain.Extensions
{
    public static class ModelsExtensions
    {
        public static void AddChild<TParent, TChild>(this TParent parent, TChild child)
            where TParent : class, IParent<TChild, TParent>, IOriginRelation
            where TChild : class, IChild<TParent, TChild>, IOriginRelation
        {
            var binder = new ProcessTreeBinder<TParent, TChild>(parent, child);
            binder.Bind();
        } 

        public static void SetParent<TParent, TChild>(this TChild child, TParent parent)
            where TParent : class, IParent<TChild, TParent>, IOriginRelation
            where TChild :class, IChild<TParent, TChild>, IOriginRelation
        {
            var binder = new ProcessTreeBinder<TParent, TChild>(parent, child);
            binder.Bind();            
        }

        public static void SetSameOrigin(this IOriginRelation @this, IOriginRelation master)
        {
            SetOrigin(@this, master.Origin);
        }

        public static void SetOrigin(this IOriginRelation @this, Origin origin)
        {
            @this.Origin = origin;
        }
    }

    internal class ProcessTreeBinder<TParent, TChild>
        where TParent : class, IParent<TChild, TParent>, IOriginRelation
        where TChild : class, IChild<TParent, TChild>, IOriginRelation
    {
        readonly TParent _parent;
        readonly TChild _child;

        public ProcessTreeBinder(TParent parent, TChild child)
        {
            _parent = parent;
            _child = child;
        }

        public void Bind() 
        {
            _parent.Childs.Add(_child);
            _child.Parent = _parent;
            _child.Origin = _parent.Origin;
        }
    }
}
