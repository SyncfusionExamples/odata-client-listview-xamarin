using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ListViewXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Simple.OData.Client.V4Adapter.Reference();
            MainPage = new NavigationPage(new ResultsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
