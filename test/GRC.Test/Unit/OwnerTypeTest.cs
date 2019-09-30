using GRC.Domain.Models.Complex;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GRC.Test.Unit
{
    public class OwnerTypeTest
    {
        [Fact]
        public void ClonedOwnerEqualsOrginal()
        {
            //Arrange
            Owner ownerStub = new Owner(1, "Centrum IT");
            //Act
            var clone = ownerStub.Clone() as Owner;
            //Assert
            Assert.Equal(ownerStub, clone);
        }
    }
}
