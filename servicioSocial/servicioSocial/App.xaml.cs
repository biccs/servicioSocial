using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace servicioSocial
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            MainPage.BackgroundColor = Color.DarkGray;

            //Frame frame = new Frame
            //{
            //    BorderColor = Color.Orange,
            //    CornerRadius = 10,
            //    HasShadow = true,
            //    Content = MainPage,
            //};

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
