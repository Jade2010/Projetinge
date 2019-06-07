using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projetinge
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Theme : ContentPage
    {
        public Page_Theme()
        {
            InitializeComponent();
            changerTheme();
            bouton1.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new Page_Questions(bouton1.Text));
            };
            bouton2.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new Page_Questions(bouton2.Text));
            };
            bouton3.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new Page_Questions(bouton3.Text));
            };
            bouton4.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new Page_Questions(bouton4.Text));
            };
        }

        public String set_theme()
        {
            String[] themes = Android.App.Application.Context.Assets.List("Questions/");
            List<string> my_list = new List<string>();
            foreach (String file in themes)
            {
                FileInfo info = new FileInfo(file);
                my_list.Add(info.Name.Replace(".json", ""));
            }

            Random rand = new Random();
            int question = rand.Next(my_list.Count);
            return my_list[question];
        }

        /*role : sert à changer les thèmes marqués sur les boutons et les couleurs 
         * entrée : 4 string qui correspondent aux thèmes à marquer sur les boutons et 4 couleurs pour la couleur du fond des boutons
         * sortie : vide
         */
        public void changerTheme()
        {
            bouton1.Text = set_theme();
            bouton2.Text = set_theme();
            bouton3.Text = set_theme();
            bouton4.Text = set_theme();

            /* bouton1.BackgroundColor = Cbouton1;
             bouton2.BackgroundColor = Cbouton2;
             bouton3.BackgroundColor = Cbouton3;
             bouton4.BackgroundColor = Cbouton4;*/
        }
    }
}