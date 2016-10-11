using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnderwaterGlucoseReceiverClient.Test
{
    [TestClass]
    public class SAM1ConfigurationTest
    {
        [TestMethod]
        public void ThresholdTextTest()
        {
            SAM1ConfigThreshold config = new SAM1ConfigThreshold();

            config.Value = 1;
            Assert.AreEqual("T01", config.Text);


            config.Value = 9;
            Assert.AreEqual("T09", config.Text);


            config.Value = 10;
            Assert.AreEqual("T10", config.Text);


            config.Value = 99;
            Assert.AreEqual("T99", config.Text);


            config.Value = -1;
            Assert.AreEqual("T01", config.Text);


            config.Value = 100;
            Assert.AreEqual("T99", config.Text);
        }

        [TestMethod]
        public void RSTextTest()
        {
            SAM1Configuration config = new SAM1Configuration();

            config.R = 3;
            Assert.AreEqual("R4", config.RText);

            config.R = 4;
            Assert.AreEqual("R4", config.RText);

            config.R = 6;
            Assert.AreEqual("R6", config.RText);
            
            config.R = 7;
            Assert.AreEqual("R6", config.RText);

            config.S = 3;
            Assert.AreEqual("S4", config.SText);

            config.S = 4;
            Assert.AreEqual("S4", config.SText);

            config.S = 6;
            Assert.AreEqual("S6", config.SText);

            config. S= 7;
            Assert.AreEqual("S6", config.SText);

        }

        

    }
}
