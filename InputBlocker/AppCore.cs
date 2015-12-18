using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace InputBlocker
{
    public class AppCore
    {
        #region BlockInputCode

        [DllImport("user32.dll")]
        static extern void BlockInput(bool Block);

        public void BlockAllInput()
        {
            BlockInput(true);
        }

        #endregion

    }
}
