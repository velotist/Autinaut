﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DarkTheme : ResourceDictionary
    {
        public DarkTheme()
        {
            InitializeComponent();
        }
    }
}