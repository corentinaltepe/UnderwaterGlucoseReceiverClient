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
    public class GlucoseSensorPacket
    {
        public float Raw
        { get; set; }
        
        public float Filtered
        { get; set; }

        /// <summary>
        /// Transforms the compressed value sent by RF into (16-bit) float format
        /// </summary>
        /// <param name="data">Value sent by RF (2 bytes long)</param>
        /// <returns>Integer format of the same value</returns>
        public static float dex_num_decoder(byte[] data)
        {
            var intVal = BitConverter.ToInt32(new byte[] { data[0], data[1], 0, 0 }, 0);

            int mant = intVal & 0x03ff;
            int exp = intVal & 0x7c00;
            if (exp == 0x7c00) exp = 0x3fc00;
            else if (exp != 0)
            {
                exp += 0x1c000;
                if (mant == 0 && exp > 0x1c400)
                    return BitConverter.ToSingle(BitConverter.GetBytes((intVal & 0x8000) << 16 | exp << 13 | 0x3ff), 0);
            }
            else if (mant != 0)
            {
                exp = 0x1c400;
                do
                {
                    mant <<= 1;
                    exp -= 0x400;
                } while ((mant & 0x400) == 0);
                mant &= 0x3ff;
            }
            return BitConverter.ToSingle(BitConverter.GetBytes((intVal & 0x8000) << 16 | (exp | mant) << 13), 0);
        }
    }
}
