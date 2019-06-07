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
            changerTheme(set_theme());
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

        public List<String> set_theme()
        {
            String[] themes = Android.App.Application.Context.Assets.List("Questions/");
            List<string> my_list = new List<string>();
            List<string> result = new List<string>();
            foreach (String file in themes)
            {
                FileInfo info = new FileInfo(file);
                my_list.Add(info.Name.Replace(".json", ""));
            }

            Random rand = new Random();
            for(int i = 0; i < 4; i++)
            {
                int question = rand.Next(my_list.Count);
                result.Add(my_list[question]);
                my_list.RemoveAt(question);
            }
            return result;
        }

        /*role : sert à changer les thèmes marqués sur les boutons et les couleurs 
         * entrée : 4 string qui correspondent aux thèmes à marquer sur les boutons et 4 couleurs pour la couleur du fond des boutons
         * sortie : vide
         */
        public void changerTheme(List<String> list_themes)
        {
            bouton1.Text = list_themes[0];
            bouton2.Text = list_themes[1];
            bouton3.Text = list_themes[2];
            bouton4.Text = list_themes[3];

            /* bouton1.BackgroundColor = Cbouton1;
             bouton2.BackgroundColor = Cbouton2;
             bouton3.BackgroundColor = Cbouton3;
             bouton4.BackgroundColor = Cbouton4;*/
        }
    }
}