using ShellNavigationSample.ViewModels;

namespace ShellNavigationSample.Views;

public partial class PageBView : ContentPage
{
	public PageBView(PageBViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}