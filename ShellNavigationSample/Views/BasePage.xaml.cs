using ShellNavigationSample.ViewModels.Base;

namespace ShellNavigationSample.Views;

public partial class BasePage : ContentPage
{
    private bool _isInitialized;

    public IList<IView> BasePageContent => BaseContentGrid.Children;
    public Label ShellPreviousLabel => ShellPrevious;
    public Label ShellSourceLabel => ShellSource;

    public BasePage(object viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (!_isInitialized) 
        {
            _isInitialized = true;
            Title += $" - {DateTime.Now:HH:mm:ss}";
        }

        SetNaviPath();
    }

    private void SetNaviPath()
    {
        var path = $"{Shell.Current.CurrentState.Location}";
        RouteEntry.Text = path;
        NaviPath.Text = path;
        Info.Text = $"last navigated to at {DateTime.Now:HH:mm:ss}";
    }
}