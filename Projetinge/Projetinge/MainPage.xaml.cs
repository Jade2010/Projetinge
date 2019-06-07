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
            InitializeComponent();
            boutonJouer.Clicked += async (sender, args) =>
            {
                   await Navigation.PushAsync(new Page_Theme());
            };

        }

        /*role : sert à changer les thèmes marqués sur les boutons et les couleurs 
         * entrée : 4 string qui correspondent aux thèmes à marquer sur les boutons et 4 couleurs pour la couleur du fond des boutons
         * sortie : vide
         */
        public void changerTheme(String Sbouton1, String Sbouton2, String Sbouton3, String Sbouton4, Color Cbouton1, Color Cbouton2, Color Cbouton3, Color Cbouton4)
        {
           
              
              
        }




    }
}
