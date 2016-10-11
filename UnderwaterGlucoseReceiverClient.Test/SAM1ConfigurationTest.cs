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
            SAM1Configuration config = new SAM1Configuration();

            config.Threshold = 1;
            Assert.AreEqual("T01", config.ThresholdText);


            config.Threshold = 9;
            Assert.AreEqual("T09", config.ThresholdText);


            config.Threshold = 10;
            Assert.AreEqual("T10", config.ThresholdText);


            config.Threshold = 99;
            Assert.AreEqual("T99", config.ThresholdText);


            config.Threshold = -1;
            Assert.AreEqual("T01", config.ThresholdText);


            config.Threshold = 100;
            Assert.AreEqual("T99", config.ThresholdText);
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

        [TestMethod]
        public void ValidTTextTest()
        {
            List<string> res = SAM1Configuration.ValidTTexts;

            Assert.AreEqual("T01", res[0]);
            Assert.AreEqual("T10", res[9]);
            Assert.AreEqual("T99", res[98]);
        }

    }
}
