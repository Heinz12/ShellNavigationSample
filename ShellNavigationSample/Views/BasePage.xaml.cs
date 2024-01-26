using ShellNavigationSample.ViewModels.Base;
using System.Diagnostics;

namespace ShellNavigationSample.Views;

[QueryProperty(nameof(Param1), "p1")]
[QueryProperty(nameof(Param2), "p2")]
public partial class BasePage : ContentPage, IQueryAttributable
{
    private bool _isInitialized;
    private string _param1;
    public string Param1
    {
        get { return _param1; }
        set { if (_param1 == value) return; _param1 = value; OnPropertyChanged(); }
    }

    private string _param2;
    public string Param2
    {
        get { return _param2; }
        set { if (_param2 == value) return; _param2 = value; OnPropertyChanged(); }
    }

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

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        foreach (var kvp in query)
        {
            Debug.WriteLine($"{kvp.Key}={kvp.Value}");
        }
    }
}