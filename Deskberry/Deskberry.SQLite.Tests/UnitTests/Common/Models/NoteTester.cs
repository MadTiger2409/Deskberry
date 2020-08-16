using Deskberry.Common.Models;
using Deskberry.Tests.Resources.Helpers;
using Deskberry.Tests.Resources.UnitTestsData.Models.Note;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Deskberry.Tests.UnitTests.Common.Models
{
    [Collection("Note's tests")]
    public class NoteTester
    {
        [Fact]
        public void Note_Create_DefaultConstructor()
        {
            // Arrange
            Note note;
            var startDate = DateTime.UtcNow;

            // Act
            note = new Note();

            // Assert
            Assert.True(ModelTestHelpers.CheckTime(note, startDate));
        }

        [Theory]
        [NoteNormalConstructorData]
        public void Note_Create_NormalConstructor(string title, string content)
        {
            // Arrange
            Note note;
            var startDate = DateTime.UtcNow;

            // Act
            note = new Note(title, content);

            // Assert
            Assert.Equal(title, note.Title);
            Assert.Equal(content, note.Content);
            Assert.True(ModelTestHelpers.CheckTime(note, startDate));
        }

        [Theory]
        [NoteUpdateData]
        public void Note_UpdateData(string title, string content, string newTitle, string newContent)
        {
            // Arrange
            Note note = new Note(title, content);
            var startDate = DateTime.UtcNow;

            // Act
            note.Update(newTitle, newContent);

            // Assert
            Assert.Equal(newTitle, note.Title);
            Assert.Equal(newContent, note.Content);
        }
    }
}