using Vanara.PInvoke;
using static Vanara.PInvoke.User32;

namespace iNote
{
    public partial class WindowHelper
    {
        public static bool SetTopMost()
        {
            var hWnd = GetActiveWindow();
            if (!hWnd.IsNull)
            {
                return TopMost(true, hWnd);
            }
            return false;
        }
        public static bool UnSetTopMost()
        {
            var hWnd = GetActiveWindow();
            if (!hWnd.IsNull)
            {
                return TopMost(false, hWnd);
            }
            return false;
        }
        public static bool TopMost(bool topOrNot, HWND hwnd)
        {
            if (topOrNot)
            {
                var result = SetWindowPos(hwnd, HWND.HWND_TOPMOST, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE);
                return result;
            }
            else
            {
                var result = SetWindowPos(hwnd, HWND.HWND_NOTOPMOST, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE);
                return result;
            }
        }
    }
}
