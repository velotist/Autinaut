using Xamarin.Forms;

namespace AwesomeApp
{
    public partial class App : Application
    {
        public static Theme AppTheme { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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

        public enum Theme
        {
            Dark,
            Light
        }
    }
}
