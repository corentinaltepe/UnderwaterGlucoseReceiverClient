using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderwaterGlucoseReceiverClient
{
    /*
     * Values sent by the glucose sensor through RF
     * */
    class GlucoseSensorPacket
    {
        private int raw;
        public int Raw
        {
            get { return raw; }
            set { raw = dex_num_decoder((UInt16)value); }
        }

        private int filtered;
        public int Filtered
        {
            get { return filtered; }
            set { filtered = dex_num_decoder((UInt16)value); }
        }

        /// <summary>
        /// Transforms the compressed value sent by RF into Integer format
        /// </summary>
        /// <param name="data">Value sent by RF (2 bytes long)</param>
        /// <returns>Integer format of the same value</returns>
        private int dex_num_decoder(UInt16 value)
        {
            byte[] data = BitConverter.GetBytes(value);
            if(BitConverter.IsLittleEndian) Array.Reverse(data);
            int usExponent = (data[0] >> 5) & 0x07;
            int usMantissa = ((data[0] & 0x1F) << 8) | data[1];
            return usMantissa << usExponent;
        }
    }
}
