using Vanara.PInvoke;
using static Vanara.PInvoke.User32;

namespace iNote;

public partial class MainPage : ContentPage
{
    bool _isTopMost = false;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void ForegroundBtn_Clicked(object sender, EventArgs e)
    {
        var hWnd = GetActiveWindow();
        if (!hWnd.IsNull)
        {
            await SetForegroundWindowCustom(hWnd);
        }
    }
    private async Task SetForegroundWindowCustom(HWND hwnd)
    {
        if (_isTopMost)
        {
            var result = SetWindowPos(hwnd, HWND.HWND_NOTOPMOST, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE);
            if (result)
            {
                _isTopMost = !_isTopMost;
                ForegroundBtn.Text = "置顶";
            }
            else
            {
                await DisplayAlert("警告", "取消置顶失败", "确定");
            }
        }
        else
        {
            var result = SetWindowPos(hwnd, HWND.HWND_TOPMOST, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE);
            if (result)
            {
                _isTopMost = !_isTopMost;
                ForegroundBtn.Text = "取消置顶";
            }
            else
            {
                await DisplayAlert("警告", "置顶失败", "确定");
            }
        }
    }
}

