using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Data;
using ToDoList.Data.Infrastructure;
using ToDoList.Service;

namespace ToDoList.Test
{
    [TestClass]
    public class NoteTests
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
        public void NoteSerivice_Can_Delete_Note()
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
                var newNote = new Note(1) { Name = "New Note - Yesterday", StartDate = DateTime.Now.AddDays(-1) };

                //Act
                _noteService.Create(newNote);

            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void NoteService_NewNote_Defaults_ToAllDay()
        {
            //Arrange
            var newNote = new Note(1) { Name = "New Note - Yesterday", StartDate = DateTime.Now.AddDays(-1) };
            var expected = true;

            //Act
            var actual = newNote.AllDay;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoteService_NewNote_Defaults_StartDate_To_Today()
        {
            //Arrange
            var newNote = new Note(1) { Name = "New Note - Yesterday" };
            var expected = DateTime.Now;

            //Act
            var actual = newNote.StartDate;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetWeekView_Returns_5_Items()
        {
            //Arrange
            var correctItemCount = 5;

            //Act
            var weekView = _noteService.GetInitialWeekView();


            //Assert
            Assert.IsTrue(weekView.Count == correctItemCount);
        }

        [TestMethod]
        public void GetNextDay_Return_Next_DayColumn()
        {
            //Arrange
            DateTime currentDate = Convert.ToDateTime("14/08/2014");
            DateTime expectedDate = Convert.ToDateTime("15/08/2014");          

            //Act
            var resultDate = _noteService.NextDay(currentDate);

            //Assert
            Assert.AreEqual(expectedDate, resultDate.DataDate, "Incorrect Next Date");
        }

    }
}
