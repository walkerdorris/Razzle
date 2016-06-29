using Microsoft.VisualStudio.TestTools.UnitTesting;
using Razzle.DAL;
using Razzle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzle.Tests.Models
{
    [TestClass]
    public class GameResultTests
    {
        [TestMethod]
        public void GameResultEnsureICanCreateInstance()
        {
            GameResult g = new GameResult();
            Assert.IsNotNull(g);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GameResultEnsureICanSaveAGameResult()
        {
            //Assert
            RazzleContext context = new RazzleContext();
            GameResult g = new GameResult();
            //Act
            context.GameResults.Add(g);
            context.SaveChanges();
            //Assert
            Assert.AreEqual(1, context.GameResults.Find().GameResultId);
        }
        [TestMethod]
        public void GameResultEnsureInstanceIsValid1()
        {
            //Arrange
            RazzleContext context = new RazzleContext();
            GameResult g = new GameResult();

            g.Player = "My First Player";
            //Act
            context.GameResults.Add(g);
            //Assert
            Assert.IsTrue(context.GameResults.Count() > 1);
        }
        [TestMethod]
        public void PlayerInsureInstanceIsValid2()
        {
            //Arrange
            RazzleContext context = new RazzleContext();
            //Different way of Initializing a Player
            GameResult g = new GameResult { Player = "Another Player" };
            //Act
            context.GameResults.Add(g);
            //Assert
            Assert.IsTrue(context.GameResults.Count() > 1);
        }
    }
}
