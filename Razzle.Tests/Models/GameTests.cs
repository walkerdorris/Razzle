using Microsoft.VisualStudio.TestTools.UnitTesting;
using Razzle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzle.Tests.Models
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GameEnsureICanCreateInstance()
        {
            Game g = new Game();
            Assert.IsNotNull(g);
        }
    }
}
