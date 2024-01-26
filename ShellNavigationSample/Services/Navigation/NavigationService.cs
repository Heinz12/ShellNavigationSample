namespace ShellNavigationSample.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null, bool createNewShell = false)
        {
            if (createNewShell)
            {
                Application.Current.MainPage = new AppShell();
            }

            var shellNavigation = new ShellNavigationState(route);

            return routeParameters != null
                ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
                : Shell.Current.GoToAsync(shellNavigation);
        }

        public Task PopAsync() =>
            Shell.Current.GoToAsync("..");
    }
}
