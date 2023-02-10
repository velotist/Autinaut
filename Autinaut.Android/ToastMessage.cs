using Android.Widget;
using Autinaut;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastMessage))]

namespace Autinaut
{
    public class ToastMessage : IToast
    {
        public void ShortToast(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }

        public void LongToast(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}