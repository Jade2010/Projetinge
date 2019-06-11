using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Configuration;
using static Android.InputMethodServices.InputMethodService;

namespace Projetinge
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            int score = 0;
            int question_number = 0;
            InitializeComponent();
            boutonJouer.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new Page_Theme(score,question_number));
            };
        }

    }
}
