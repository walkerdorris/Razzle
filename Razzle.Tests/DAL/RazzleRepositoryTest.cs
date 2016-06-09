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
        List<Player> datasource { get; set; }
        Mock<RazzleContext> mock_context { get; set; }
        Mock<DbSet<Player>> mock_players_table { get; set; } //Fake Players Table
        RazzleRepository repo { get; set; }
        IQueryable<Player> data { get; set; }// Turns List<Player> into something we can query with LINQ

        [TestInitialize]
        public void Initialize()
        {
            datasource = new List<Player>();
            mock_context = new Mock<RazzleContext>();
            mock_players_table = new Mock<DbSet<Player>>();//Fake Players Table

            repo = new RazzleRepository(mock_context.Object);//Injects mocked (fake) VotrContext
            data = datasource.AsQueryable();//Turns List<Player> into something we can query with LINQ
        }
        [TestCleanup]
        public void Cleanup()
        {
            datasource = null;
        }

        void ConnectMocksToDataStore()//Utility method
        {
            //Telling our fake DbSet to use our datasource like something Queryable
            mock_players_table.As<IQueryable<Player>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_players_table.As<IQueryable<Player>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_players_table.As<IQueryable<Player>>().Setup(m => m.Expression).Returns(data.Expression);
            mock_players_table.As<IQueryable<Player>>().Setup(m => m.Provider).Returns(data.Provider);

            //Tell our mocked RazzleContext to use our fully mocked Datasource. (List<Player>)
            mock_context.Setup(m => m.Players).Returns(mock_players_table.Object);
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
        public void RepoEnsureThereAreNoPlayers()
        {

            //Arrange
            ConnectMocksToDataStore();

            //Act
            List<Player> list_of_players = repo.GetPlayers();
            List<Player> expected = new List<Player>();

            //Assert
            Assert.AreEqual(expected.Count, list_of_players.Count);



        }

        [TestMethod]
        public void RepoEnsureThereAreNoTurns()
        {
            //Arrange
            RazzleRepository repo = new RazzleRepository();
            //Act
            List<Turn> list_of_turns = repo.GetTurns();
            List<Turn> expected = new List<Turn>();
            //Assert
            Assert.AreEqual(expected.Count, list_of_turns.Count);
        }
        [TestMethod]
        public void RepoEnsureThereAreNoGames()
        {
            //Arrange
            RazzleRepository repo = new RazzleRepository();
            //Act
            List<Game> list_of_games = repo.GetGames();
            List<Game> expected = new List<Game>();
            //Assert
            Assert.AreEqual(expected.Count, list_of_games.Count);
        }
        [TestMethod]
        public void RepoEnsurePlayerCountIsZero()
        {
            //Arrange
            RazzleRepository repo = new RazzleRepository();
            //Act
            int expected = 0;
            int actual = repo.GetPlayerCount();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RepoEnsureTurnCountIsZero()
        {
            //Arrange
            RazzleRepository repo = new RazzleRepository();
            //Act
            int expected = 0;
            int actual = repo.GetTurnCount();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RepoEnsureGameCountIsZero()
        {
            //Arrange
            RazzleRepository repo = new RazzleRepository();
            //Act
            int expected = 0;
            int actual = repo.GetGameCount();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RepoEnsureICanAddPlayer()
        {
            //Arrange
            RazzleRepository repo = new RazzleRepository();
            //Act
            repo.AddPlayer("Some Name");

            int actual = repo.GetPlayerCount();
            int expected = 1;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
