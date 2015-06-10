using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Data;
using ToDoList.Data.Infrastructure;
using ToDoList.Service;

namespace ToDoList.Test
{
    [TestClass]
    public class NoteServiceTest
    {
        IUnitOfWork _uow;
        NoteService _noteService;

        [TestInitialize]
        public void SetUp()
        {
            _uow = new MockUnitOfWork<MockToDoListDbContext>();
            _noteService = new NoteService(_uow);
        }

        [TestCleanup]
        public void TearDown()
        {
            // Clean resources
        }

        [TestMethod]
        public void NoteService_Can_Retrieve_Note_MakeABrew()
        {
            var note = _noteService.GetByID(1);
            Assert.AreEqual(note.Name, "Make a Brew");
        }

        [TestMethod]
        public void NoteSerivice_Can_Delete_Note_MakeABrew()
        {
            try
            {
                _noteService.DeleteByID(1);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void NoteService_Can_Create_Note_NewNote()
        {
            try
            {
                //Arrange
                var newNote = new Note { Name = "New Note - Yesterday", StartDate = DateTime.Now.AddDays(-1) };

                //Act
                _noteService.Create(newNote);

                //Assert
                Assert.IsNotNull(_noteService.GetAll().Where(n => n.Name == "New Note - Yesterday"));
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void NoteService_Returns_Error_When_Attempting_To_Create_Note_With_Duplicate_Id()
        {
            try
            {
                //Arrange
                var newNote = new Note { id = 1, Name = "New Note - Yesterday", StartDate = DateTime.Now.AddDays(-1) };

                //Act
                _noteService.Create(newNote);

            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

    }
}
