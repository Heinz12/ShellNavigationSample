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
    public partial class PageAViewModel(INavigationService navigationService) : ViewModelBase(navigationService)
    {
        [RelayCommand]
        private async Task ShowPageBAsync()
        {
            await NavigationService.NavigateToAsync("B");
        }

        [RelayCommand]
        private async Task NavigateDeepAsync()
        {
            await NavigationService.NavigateToAsync("A/B/A/B/A/B");
        }
      
        [RelayCommand]
        private async Task NavigateAbsoluteAsync()
        {
            await NavigationService.NavigateToAsync("//Main/A/B/A/B");
        }
    }
}
