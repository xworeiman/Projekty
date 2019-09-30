using System;
using System.Collections.Generic;
using System.Text;

namespace GRC.Domain.Models.States
{
    public enum MfkStates
    {
        New = 0,
        Accepted = 1,
        SendedForAccept=3,
        Removed = 4
    }
}
