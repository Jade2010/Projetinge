using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projetinge
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemePage : ContentView
    {
        /*label_
         * bouton1
         * bouton2
         * bouton3
         * bouton4
         * 
         */

        public ThemePage()
        {
            InitializeComponent();

        }

        /*role : sert à changer les thèmes marqués sur les boutons et les couleurs 
         * entrée : 4 string qui correspondent aux thèmes à marquer sur les boutons et 4 couleurs pour la couleur du fond des boutons
         * sortie : vide
         */
        public void changerTheme(String Sbouton1, String Sbouton2, String Sbouton3, String Sbouton4, Color Cbouton1, Color Cbouton2, Color Cbouton3, Color Cbouton4)
        {

            bouton1.Text = Sbouton1;
            bouton2.Text = Sbouton2;
            bouton3.Text = Sbouton3;
            bouton4.Text = Sbouton4;

            bouton1.BackgroundColor = Cbouton1;
            bouton2.BackgroundColor = Cbouton2;
            bouton3.BackgroundColor = Cbouton3;
            bouton4.BackgroundColor = Cbouton4;
        }
    }
}