using GRC.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GRC.Domain.Models.Tree
{
    public interface IChild<TParent, TChild>
        where TParent : IParent<TChild, TParent>
        where TChild : IChild<TParent, TChild>
    {
        int ParentId { get; set; }
        TParent Parent { get; set; }
    }

    public interface IChild
    {
        TParent GetParent<TParent>() where TParent : BaseEntity, IParent;
    }
}
