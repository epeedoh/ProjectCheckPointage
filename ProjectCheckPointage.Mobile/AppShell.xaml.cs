namespace ProjectCheckPointage.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("DashboardPromoteurPage", typeof(Views.DashboardPromoteurPage));

        }
    }
}
