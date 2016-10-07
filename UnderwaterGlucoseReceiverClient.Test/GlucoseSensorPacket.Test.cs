using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnderwaterGlucoseReceiverClient.Test
{
    [TestClass]
    public class GlucoseSensorPacketTest
    {
        [TestMethod]
        public void dex_num_decoderTest()
        {
            GlucoseSensorPacket pckt = new GlucoseSensorPacket();
            byte[] b = { 0x48, 0x39 };
            Assert.IsTrue(Math.Abs(GlucoseSensorPacket.dex_num_decoder(b) - 0.660) < 0.001);
        }
    }
}
