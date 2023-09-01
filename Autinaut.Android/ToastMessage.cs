using Android.Widget;
using Autinaut;
using Autinaut.Common;
using Xamarin.Forms;
using Application = Android.App.Application;

[assembly: Dependency(typeof(ToastMessage))]

namespace Autinaut
{
    public class ToastMessage : IToast
    {
        public void ShortToast(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}