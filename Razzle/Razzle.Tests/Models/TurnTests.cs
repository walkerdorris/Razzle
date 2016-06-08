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
    public class TurnTests
    {
        [TestMethod]
        public void TurnEnsureICanCreateInstance()
        {
            Turn t = new Turn();
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void MyTestMethod()
        {

        }
    }
}
