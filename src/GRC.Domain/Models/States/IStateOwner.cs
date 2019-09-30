using GRC.Domain.Models.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace GRC.Domain.Models.Common
{
    public interface IStateOwner
    {
        IState State { get; }
    }
}
