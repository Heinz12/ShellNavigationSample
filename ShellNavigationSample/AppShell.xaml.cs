using ShellNavigationSample.Views;

namespace ShellNavigationSample
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            AppShell.InitializeRouting();
            InitializeComponent();
        }

        private static void InitializeRouting()
        {
            Routing.RegisterRoute(nameof(PageAView), typeof(PageAView));
            Routing.RegisterRoute(nameof(PageBView), typeof(PageBView));
        }
    }
}
