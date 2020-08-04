using Deskberry.Common.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Deskberry.SQLite.Tests.UnitTests.Models
{
    [Collection("Model Base Tests")]
    public class ModelBaseTester
    {
        [Fact]
        public void ModelBase_CreateObject_Success()
        {
            // Arrange
            ModelBase model;
            var startDate = DateTime.UtcNow;

            // Act
            model = new ModelBase();

            // Assert
            Assert.NotEqual(default, model.CreatedAt);
            Assert.True(model.CreatedAt.Ticks > startDate.Ticks);
        }
    }
}