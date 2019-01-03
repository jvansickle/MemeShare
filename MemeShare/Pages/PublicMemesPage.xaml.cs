using System;
using System.Collections.Generic;
using MemeShare.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MemeShare.Pages
{
    public partial class PublicMemesPage : ContentPage
    {
        public PublicMemesPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            BindingContext = new PublicMemesViewModel();
        }
    }
}
