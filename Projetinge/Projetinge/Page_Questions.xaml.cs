using Android.Content.Res;
using Newtonsoft.Json.Linq;
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
    public partial class Page_Questions : ContentPage
    {
        public Page_Questions(String theme)
        {
            InitializeComponent();
            changerQuestion(theme);
        }

        private String get_question(String theme)
        {
            string my_file = "";
            AssetManager assetManager = Android.App.Application.Context.Assets;
            System.IO.StreamReader file = new System.IO.StreamReader(assetManager.Open("Questions/"+theme+".json"));
            {
                my_file = file.ReadToEnd();
            }
            file.Close();
            Random rand = new Random();
            int ques = rand.Next(6);
            dynamic parser = JObject.Parse(my_file);
            string question = (string)parser.SelectToken("questions[" + ques + "].question");
            return question;

        }


        /*role : sert à changer les thèmes marqués sur les boutons et les couleurs 
         * entrée : 5 string qui correspondent aux thèmes à marquer sur les boutons et le label qui est pour la question
         * sortie : vide
         */
        public void changerQuestion(String theme)
        {
           
            label_.Text = get_question(theme);
            /*bouton1.Text = Sbouton1;
            bouton2.Text = Sbouton2;
            bouton3.Text = Sbouton3;
            bouton4.Text = Sbouton4;*/

            /*bouton1.BackgroundColor = ;
             * bouton2.BackgroundColor = ;
             * bouton3.BackgroundColor = ;
             * bouton4.BackgroundColor = ;
            */
        }
    }
}