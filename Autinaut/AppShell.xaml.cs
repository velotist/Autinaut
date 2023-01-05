using System.Windows.Input;
using Xamarin.Forms;

namespace Autinaut
{
    public partial class AppShell : Shell
    {
        public ICommand GoBack { get; }
        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;
            GoBack = new Command(GoBackButton);
        }

        public async void GoBackButton()
        {
            await Navigation.PopToRootAsync();
        }
    }
}