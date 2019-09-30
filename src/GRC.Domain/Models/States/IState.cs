using System;
using System.Collections.Generic;
using System.Text;

namespace GRC.Domain.Models.States
{
    public interface IState
    {
        MfkStates State { get; }
    }
}
