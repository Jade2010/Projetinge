using Firebase.Database;
using Firebase.Database.Query;
using Java.Nio.FileNio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirebase.Model;

namespace Projetinge
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Score_page : ContentPage
    {
        FirebaseClient firebase = new FirebaseClient("https://quizzatlas.firebaseio.com/");
        
        public Score_page(int score,List<String> list_string)
        {

            InitializeComponent();
            BackgroundImage = "HachingBackgound.png";
            labelScoreFinal.Text = "Votre score est de :" + score.ToString();

            boutonSave.Clicked += async (sender, args) =>
            {
                _ = AddPreference("toto", "titi");
                await DisplayAlert("Success", "Person Added Successfully", "OK");

            };

        }

        public String get_preference(List<String> list_string)
        {
            String preference="";
            int occurence;
            int preference_occurence=0;

            foreach(String str in list_string)
            {
                occurence = 0;
                foreach (String s in list_string)
                {
                    if (str.Equals(s))
                    {
                        occurence++;
                    }
                }
                occurence -= 1;
                if(occurence>preference_occurence)
                {
                    preference_occurence = occurence;
                    preference = str;
                }

            }
            return preference;
        }

        public async Task AddPreference(string name, string centre)
        {
            await firebase
              .Child("quizzatlas")
              .PostAsync(new CentreInteret() { Name = name, Centre = centre });
        }

    }
}  