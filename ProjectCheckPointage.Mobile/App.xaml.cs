using ProjectCheckPointage.Mobile.Views;

namespace ProjectCheckPointage.Mobile
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            MainPage = new NavigationPage(serviceProvider.GetService<ConnexionPage>());
            //MainPage = new AppShell(); // pas juste ConnexionPage



        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    //return new Window(new AppShell());

        //}
    }
}