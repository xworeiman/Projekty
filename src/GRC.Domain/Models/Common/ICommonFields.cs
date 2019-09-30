using GRC.Domain.Models.Complex;

namespace GRC.Domain.Models.Common
{
    public interface ICommonFields
    {
        string Name { get; set; }
        string EnterpriseId { get; set; }

        Owner Owner { get; set; }
    }
}
