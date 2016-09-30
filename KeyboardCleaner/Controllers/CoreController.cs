using InputBlocker.Interfaces;
using System.Runtime.InteropServices;

namespace InputBlocker
{
    public class CoreController : ICoreController
    {
        [DllImport("user32.dll")]
        static extern void BlockInput(bool Block);

        public void BlockAllInput()
        {
            BlockInput(true);
        }
    }
}
