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

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);

            if (CurrentPage is BasePage basePage)
            {
                basePage.ShellPreviousLabel.Text = args.Previous.Location.ToString();
                basePage.ShellSourceLabel.Text = args.Source.ToString();
            }
        }
    }
}
