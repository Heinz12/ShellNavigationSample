using ShellNavigationSample.ViewModels;

namespace ShellNavigationSample.Views;

public partial class PageAView : ContentPage
{
	public PageAView(PageAViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}