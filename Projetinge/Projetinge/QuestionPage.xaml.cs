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
    public partial class QuestionPage : ContentView
    {/*label_
         * bouton1
         * bouton2
         * bouton3
         * bouton4
         * 
         */

        public QuestionPage()
        {
            InitializeComponent();

        }

        /*role : sert à changer les thèmes marqués sur les boutons et les couleurs 
         * entrée : 5 string qui correspondent aux thèmes à marquer sur les boutons et le label qui est pour la question
         * sortie : vide
         */
        public void changerQuestion(String question,String Sbouton1, String Sbouton2, String Sbouton3, String Sbouton4)
        {
            label_.Text = question;
            bouton1.Text = Sbouton1;
            bouton2.Text = Sbouton2;
            bouton3.Text = Sbouton3;
            bouton4.Text = Sbouton4;

            /*bouton1.BackgroundColor = ;
             * bouton2.BackgroundColor = ;
             * bouton3.BackgroundColor = ;
             * bouton4.BackgroundColor = ;
            */
        }
    }
}