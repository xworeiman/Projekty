using System;
using System.Collections.Generic;
using System.Text;

namespace GRC.Domain.Models.Versions
{
    public interface IVersioned<T>
    {
        T PreviusVersion { get; set; }
        ICollection<T> InversePreviusVersion { get; set; }
        int Version { get; set; }
        int? PreviusVersionId { get; set; }
        //T CreateNewVersion();
    }
}
