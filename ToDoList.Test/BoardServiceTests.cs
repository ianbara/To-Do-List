using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Data;
using ToDoList.Data.Infrastructure;
using ToDoList.Data.Models;
using ToDoList.Service;

namespace ToDoList.Test
{
    [TestClass]
    public class BoardServiceTests
    {
        IUnitOfWork _uow;
        BoardService _service;

        [TestInitialize]
        public void SetUp()
        {
            _uow = new MockUnitOfWork<MockToDoListDbContext>();
            _service = new BoardService(_uow);
        }

        [TestCleanup]
        public void TearDown()
        {
            // Clean resources
        }

        [TestMethod]
        public void NoteService_Can_Retrieve_Note_Board_2()
        {
            var board = _service.GetByID(2);
            Assert.AreEqual(board.Name, "Board 2");
        }

        [TestMethod]
        public void NoteService_Can_Retrieve_Note_Board_With_NoteList()
        {
            //Arrange
            var board = new Board();
            var exceptedNoteCount = 3;

            //Act
            board = _service.GetByID(1);

            //Assert
            Assert.AreEqual(exceptedNoteCount, board.NoteList.Count);
        }


        [TestMethod]
        public void NoteSerivice_Can_Delete_Note()
        {
            try
            {
                _service.DeleteByID(1);
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
                var newBoard = new Board { Name = "New Board" };

                //Act
                _service.Create(newBoard);

                //Assert
                Assert.IsNotNull(_service.GetAll().Where(n => n.Name == "New Board"));
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
                var newBoard = new Board { Name = "Board 1" };

                //Act
                _service.Create(newBoard);

            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }


     

    }
}
