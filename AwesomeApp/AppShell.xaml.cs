using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AwesomeApp
{
    public partial class AppShell : Shell
    {
        public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}