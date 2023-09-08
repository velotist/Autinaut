using Android.Widget;
using Autinaut.Common;
using Autinaut.Droid;
using Xamarin.Forms;
using Application = Android.App.Application;

[assembly: Dependency(typeof(ToastMessage))]

namespace Autinaut.Droid;

public class ToastMessage : IToast
{
    public void ShortToast(string message)
    {
        Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
    }
}