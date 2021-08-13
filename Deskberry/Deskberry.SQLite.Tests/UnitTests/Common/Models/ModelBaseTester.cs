using Deskberry.Common.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Deskberry.Tests.UnitTests.Common.Models
{
    [Collection("Model Base Tests")]
    public class ModelBaseTester
    {
        [Fact]
        public void ModelBase_CreateDefault()
        {
            // Arrange
            ModelBase model;
            var startDate = DateTime.UtcNow;

            // Act
            model = new ModelBase();

            // Assert
            Assert.NotEqual(default(DateTime), model.CreatedAt);
            Assert.True(model.CreatedAt.Ticks > startDate.Ticks);
        }
    }
}