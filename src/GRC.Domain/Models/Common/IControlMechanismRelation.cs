using System;
using System.Collections.Generic;
using System.Text;

namespace GRC.Domain.Models.Common
{
    public interface IControlMechanismRelation
    {
        public ICollection<ControlMechanismRelations> ControlMechanismRelations { get; set; }
    }
}
