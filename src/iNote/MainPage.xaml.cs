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
        await SetForegroundWindowCustom();
    }
    private async Task SetForegroundWindowCustom()
    {
        if (_isTopMost)
        {
            var result = WindowHelper.UnSetTopMost();
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
            var result = WindowHelper.SetTopMost();
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

