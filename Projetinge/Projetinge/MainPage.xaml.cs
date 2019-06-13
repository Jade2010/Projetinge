using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Projetinge
{
    public partial class MainPage : ContentPage
    {
        /*label_
         * bouton1
         * bouton2
         * bouton3
         * bouton4
         * 
         */

        public MainPage()
        {
            InitializeComponent();
            BackgroundImage = "HachingBackgound.png";
            //imageLogo.Source = Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("logo.png") : ImageSource.FromFile("Images/logo.png");
            //imageLogo.Source = Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("Images/logo.png") : ImageSource.FromFile("Drawable/Images/logo.png");

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
