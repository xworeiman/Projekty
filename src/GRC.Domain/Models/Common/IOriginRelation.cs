using System;
using System.Collections.Generic;
using System.Text;

namespace GRC.Domain.Models.Common
{
    public interface IOriginRelation
    {
        int OriginId { get; set; }
        Origin Origin { get; set; }
    }
}
