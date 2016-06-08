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
    public class PlayerTests
    {
        [TestMethod]
        public void PlayerEnsureICanCreateInstance()
        {
            Player p = new Player();
            Assert.IsNotNull(p);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PlayerEnsureICanSaveAPlayer()
        {
            //Assert
            RazzleContext context = new RazzleContext();
            Player p = new Player();
            //Act
            context.Players.Add(p);
            context.SaveChanges();
            //Assert
            Assert.AreEqual(1, context.Players.Find().PlayerID);
        }
        [TestMethod]
        public void PlayerInsureInstanceIsValid1()
        {
            //Arrange
            RazzleContext context = new RazzleContext();
            Player p = new Player();

            p.PlayerName = "My First Player";
            //Act
            context.Players.Add(p);
            //Assert
            Assert.IsTrue(context.Players.Count() > 1);
        }
        [TestMethod]
        public void PlayerInsureInstanceIsValid2()
        {
            //Arrange
            RazzleContext context = new RazzleContext();
            //Different way of Initializing a Player
            Player p = new Player { PlayerName = "Another Player" };
            //Act
            context.Players.Add(p);
            //Assert
            Assert.IsTrue(context.Players.Count() > 1);
        }
    }
}
