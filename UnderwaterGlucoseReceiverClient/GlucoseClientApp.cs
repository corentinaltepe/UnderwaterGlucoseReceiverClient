using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderwaterGlucoseReceiverClient
{
    public class GlucoseClientApp
    {
        public IAcousticModem ModemInterface;

        public GlucoseClientApp()
        {
            // By default
            ModemInterface = new SM1Modem();
        }

        #region Function & Methods



        #endregion


    }
}
