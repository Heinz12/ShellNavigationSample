using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShellNavigationSample.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellNavigationSample.ViewModels.Base
{
    [QueryProperty(nameof(Param1), "p1")]
    [QueryProperty(nameof(Param2), "p2")]
    public abstract partial class ViewModelBase : ObservableObject, IQueryAttributable
    {
        private long _isBusy;

        public bool IsBusy => Interlocked.Read(ref _isBusy) > 0;

        [ObservableProperty]
        private bool _isInitialized;

        [ObservableProperty]
        private string _param1;
        
        [ObservableProperty]
        private string _param2;

        [ObservableProperty]
        private bool _createNewShell;

        [ObservableProperty]
        private string _hashCode;

        public INavigationService NavigationService { get; }

        public IAsyncRelayCommand InitializeAsyncCommand { get; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
            HashCode = this.GetHashCode().ToString("X8");

            InitializeAsyncCommand =
                new AsyncRelayCommand(
                    async () =>
                    {
                        await IsBusyFor(InitializeAsync);
                        IsInitialized = true;
                    },
                    AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler);
        }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task IsBusyFor(Func<Task> unitOfWork)
        {
            Interlocked.Increment(ref _isBusy);
            OnPropertyChanged(nameof(IsBusy));

            try
            {
                await unitOfWork();
            }
            finally
            {
                Interlocked.Decrement(ref _isBusy);
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        [RelayCommand]
        private Task NavigateBackAsync()
        {
            return NavigationService.PopAsync();
        }

        [RelayCommand]
        private async Task NavigateToRouteAsync(string route)
        {
            try
            {
                await NavigationService.NavigateToAsync(route, createNewShell: CreateNewShell);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            foreach (var kvp in query)
            {
                Debug.WriteLine($"ViewModelBase: {kvp.Key}={kvp.Value}");
            }
        }
    }
}
