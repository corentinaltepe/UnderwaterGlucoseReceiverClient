using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnderwaterGlucoseReceiverClient.ModemConfiguration;
using System.Linq;

namespace UnderwaterGlucoseReceiverClient.Test
{
    [TestClass]
    public class SAM1ConfigurationTest
    {
        [TestMethod]
        public void ThresholdTextTest()
        {
            SAM1ConfigThreshold config = new SAM1ConfigThreshold(0);
            Assert.AreEqual("T01", config.Text);

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
            SAM1ConfigReadSpeed R = new SAM1ConfigReadSpeed(0);
            Assert.AreEqual("R4", R.Text);

            R.Value = 3;
            Assert.AreEqual("R4", R.Text);

            R.Value = 4;
            Assert.AreEqual("R4", R.Text);

            R.Value = 6;
            Assert.AreEqual("R6", R.Text);

            R.Value = 7;
            Assert.AreEqual("R6", R.Text);
        }

        [TestMethod]
        public void STextTest()
        {
            SAM1ConfigSendSpeed S = new SAM1ConfigSendSpeed(0);
            S.Value = 3;
            Assert.AreEqual("S4", S.Text);

            S.Value = 4;
            Assert.AreEqual("S4", S.Text);

            S.Value = 6;
            Assert.AreEqual("S6", S.Text);

            S.Value = 7;
            Assert.AreEqual("S6", S.Text);
        }

        [TestMethod]
        public void ConfigListsTest()
        {
            SAM1Configuration config = new SAM1Configuration();

            Assert.AreEqual(99, config.ListOfThresholds.Count);
            Assert.AreEqual(3, config.ListOfRs.Count);
            Assert.AreEqual(3, config.ListOfSs.Count);

            Assert.AreEqual("T01", config.ListOfThresholds.First().Text);
            Assert.AreEqual("R4", config.ListOfRs.First().Text);
            Assert.AreEqual("S4", config.ListOfSs.First().Text);

            Assert.AreEqual("T99", config.ListOfThresholds.Last().Text);
            Assert.AreEqual("R6", config.ListOfRs.Last().Text);
            Assert.AreEqual("S6", config.ListOfSs.Last().Text);

        }
    }
}
