using System;
using System.Collections.Generic;
using System.Text;
using static System.Object;
namespace GRC.Domain.Models.Complex
{
    public class Owner : ICloneable,  IEquatable<Owner>
    {
        public int OwnerId { get; set; }
        public string OwnerOrganisationUnit { get; set; }

        public Owner()
        {
        }

        public Owner(int ownerId, string ownerOrganisationUnit)
        {
            OwnerId = ownerId;
            OwnerOrganisationUnit = ownerOrganisationUnit;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Deconstruct(out int OwnerId, out string OwnerOrganisationUnit)
        {
            OwnerId = this.OwnerId;
            OwnerOrganisationUnit = this.OwnerOrganisationUnit;
        }

        public bool Equals(Owner other)
        {
            return Equals(this.OwnerId, other?.OwnerId) && Equals(this.OwnerOrganisationUnit, other?.OwnerOrganisationUnit);
        }

        public override bool Equals(object obj)
        {
            return (obj as Owner)?.Equals(this) == true;
        }

        public override int GetHashCode()
        {
            return (OwnerId.GetHashCode() * 17 + (OwnerOrganisationUnit?.GetHashCode()).GetValueOrDefault());
        }

        public override string ToString()
        {
            return $"{OwnerOrganisationUnit},{OwnerId}";
        }

        public static bool operator !=(Owner obj1, Owner obj2)
        {
            return !(obj1 == obj2);
        }

        public static bool operator ==(Owner obj1, Owner obj2)
        {
            if (obj1 == null)
            {
                if (obj2 == null)
                {
                    return true;
                }
                return false;
            }
            return obj1.Equals(obj2);
        }

    }
}

