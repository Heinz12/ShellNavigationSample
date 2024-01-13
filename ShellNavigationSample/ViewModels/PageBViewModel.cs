using CommunityToolkit.Mvvm.Input;
using ShellNavigationSample.Services.Navigation;
using ShellNavigationSample.ViewModels.Base;
using ShellNavigationSample.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellNavigationSample.ViewModels
{
    public partial class PageBViewModel(INavigationService navigationService) : ViewModelBase(navigationService)
    {
        [RelayCommand]
        private async Task ShowPageAAsync()
        {
            await NavigationService.NavigateToAsync(nameof(PageAView));
        }
    }
}
