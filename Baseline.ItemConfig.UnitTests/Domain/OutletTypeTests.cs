using Baseline.ItemConfig.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Baseline.ItemConfig.UnitTests.Domain
{
    public class OutletTypeTests
    {
        [Fact]
        public void Should_Create_OutletType_Succeed()
        {
            // Act
            var result = OutletType.Create("Internet");

            // Assert
            Assert.Equal("Internet", result.Name);
        }
    }
}
