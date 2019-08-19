using Deskberry.SQLite.Data.Extensions.Queries;
using Deskberry.SQLite.Models;
using Deskberry.SQLite.Tests.Resources.Databases;
using Deskberry.SQLite.Tests.Resources.UnitTests.NoteQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Deskberry.SQLite.Tests.UnitTests.Extensions.Queries
{
    [Collection("Note Queries Tests")]
    public class NoteQueriesTester : SQLiteDatabaseFixture
    {
        private void PrepareDbWithOneAvatarOneUserAndOneNote(string title, string content, out Note expectedNote)
        {
            var avatar = new Avatar(new byte[] { 1, 57, 137, 75 });
            var account = new Account("admin", new byte[] { 1, 6, 95, 0 }, new byte[] { 19, 63, 167, 0 }, avatar);
            expectedNote = new Note(title, content);

            account.Notes = new List<Note>
            {
                expectedNote
            };

            DbContext.Avatars.Add(avatar);
            DbContext.Accounts.Add(account);
            DbContext.SaveChanges();
        }

        [Theory]
        [NoteGetByIdQueryData]
        public void GetById_RecordExists_Foud(string title, string content)
        {
            // Arrange
            Note note;
            int count;

            PrepareDbWithOneAvatarOneUserAndOneNote(title, content, out Note expectedNote);

            // Act
            note = DbContext.Notes.GetById(expectedNote.Id).SingleOrDefault();
            count = DbContext.Notes.Count();

            // Assert
            Assert.Equal(expectedNote.Id, note.Id);
            Assert.Equal(expectedNote, note);
        }

        [Fact]
        public void GetById_RecordDoesntExist_NotFound()
        {
            // Arrange
            Note note;

            // Act
            note = DbContext.Notes.GetById(10).SingleOrDefault();

            // Assert
            Assert.Null(note);
        }
    }
}
