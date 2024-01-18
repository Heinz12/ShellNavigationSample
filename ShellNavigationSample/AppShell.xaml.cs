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
            Routing.RegisterRoute("A", typeof(PageAView));
            Routing.RegisterRoute("B", typeof(PageBView));
        }
    }
}
