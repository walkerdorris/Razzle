using Microsoft.VisualStudio.TestTools.UnitTesting;
using Razzle.DAL;
using Razzle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.Entity;

namespace Razzle.Tests.DAL
{
    [TestClass]
    public class RazzleRepositoryTest
    {
        List<GameResult> datasource { get; set; }
        Mock<RazzleContext> mock_context { get; set; }
        Mock<DbSet<GameResult>> mock_gameresults_table { get; set; } //Fake GameResults Table
        RazzleRepository repo { get; set; }
        IQueryable<GameResult> data { get; set; }// Turns List<GameResult> into something we can query with LINQ

        [TestInitialize]
        public void Initialize()
        {
            datasource = new List<GameResult>();
            mock_context = new Mock<RazzleContext>();
            mock_gameresults_table = new Mock<DbSet<GameResult>>();//Fake Players Table

            repo = new RazzleRepository(mock_context.Object);//Injects mocked (fake) RazzleContext
            data = datasource.AsQueryable();//Turns List<GameResult> into something we can query with LINQ
        }

        [TestCleanup]
        public void Cleanup()
        {
            datasource = null;
        }

        void ConnectMocksToDataStore()//Utility method
        {
            //Telling our fake DbSet to use our datasource like something Queryable
            mock_gameresults_table.As<IQueryable<GameResult>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_gameresults_table.As<IQueryable<GameResult>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_gameresults_table.As<IQueryable<GameResult>>().Setup(m => m.Expression).Returns(data.Expression);
            mock_gameresults_table.As<IQueryable<GameResult>>().Setup(m => m.Provider).Returns(data.Provider);

            //Tell our mocked RazzleContext to use our fully mocked Datasource. (List<Player>)
            mock_context.Setup(m => m.GameResults).Returns(mock_gameresults_table.Object);
        }

        [TestMethod]
        public void RepoEnsureICanCreateInstance()
        {
            //RazzleRepository repo = new RazzleRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureIsUsingContext()
        {
            //Arrange
            //RazzleRepository repo = new RazzleRepository();
            //Act

            //Assert
            Assert.IsNotNull(repo.context);
        }

        [TestMethod]
        public void RepoEnsureThereAreNoGameResults()
        {
            //Arrange
            ConnectMocksToDataStore();

            //Act
            List<GameResult> list_of_gameresults = repo.GetGameResults();
            List<GameResult> expected = new List<GameResult>();

            //Assert
            Assert.AreEqual(expected.Count, list_of_gameresults.Count);
        }
  
        [TestMethod]
        public void RepoEnsureGameResultCountIsZero()
        {
            //Arrange
            RazzleRepository repo = new RazzleRepository();
            //Act
            int expected = 0;
            int actual = repo.GetGameResultCount();
            //Assert
            Assert.AreEqual(expected, actual);
        }
       
        [TestMethod]
        public void RepoEnsureICanAddPlayerToGameResult()
        {
            //Arrange
            RazzleRepository repo = new RazzleRepository();
            //Act
            repo.AddPlayerToGameResult("Some Name");

            int actual = repo.GetGameResultCount();
            int expected = 1;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
