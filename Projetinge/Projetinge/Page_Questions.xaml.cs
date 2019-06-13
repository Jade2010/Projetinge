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
        public Page_Questions(String theme,int score,int question_number,List<String> list_string)
        {
            BackgroundImageSource = "backgroundinfiltration.png";
            InitializeComponent();
            List<String> question_responses = new List<string>();
            question_responses = get_question(theme, get_question_index());
            changerQuestion(question_responses);
            labelTheme.Text = theme;
            labelScore.Text = "S :" + score;
            labelNBQuestion.Text = "Q :"+question_number.ToString() + "/8";
            bouton1.Clicked += async (sender, args) =>
            {
                bouton1.BackgroundColor = question_responses[2] == "oui"? Color.FromHex("01FE32") :Color.FromHex("FE0101");
                score = question_responses[2] == "oui" ? score + 5 : score;
                show_good_responses(question_responses);
                labelScore.Text = "S :" + score;

            };
            bouton2.Clicked += async (sender, args) =>
            {
                bouton2.BackgroundColor = question_responses[4] == "oui" ? Color.FromHex("01FE32") : Color.FromHex("FE0101");
                score = question_responses[4] == "oui" ? score + 5 : score;
                show_good_responses(question_responses);
                labelScore.Text = "S :" + score;

            };
            bouton3.Clicked += async(sender, args) =>
            {
                bouton3.BackgroundColor = question_responses[6] == "oui" ? Color.FromHex("01FE32") : Color.FromHex("FE0101");
                score = question_responses[6] == "oui" ? score + 5 : score;
                show_good_responses(question_responses);
                labelScore.Text = "S :" + score;

            };
            bouton4.Clicked += async (sender, args) =>
            {
                bouton4.BackgroundColor = question_responses[8] == "oui" ? Color.FromHex("01FE32") : Color.FromHex("FE0101");
                score = question_responses[8] == "oui" ? score + 5 : score;
                show_good_responses(question_responses);
                labelScore.Text = "S :" + score;

            };
            bouton5.Clicked += async (sender, args) =>
            {
                if (question_number < 8)
                {
                    await Navigation.PushAsync(new Page_Theme(score, question_number,list_string));
                    
                }
                else
                {
                    await Navigation.PushAsync(new Score_page(score,list_string));
                    
                }
               
            };
        }

        private void show_good_responses(List<String> question_responses)
        {
            Button[] button_list = { bouton1, bouton2, bouton3, bouton4 };
            for (int i = 1; i < 5; i++)
            {
                if(question_responses[i*2] == "oui")
                {
                    button_list[i-1].BackgroundColor = Color.FromHex("01FE32");
                }
                button_list[i-1].IsEnabled = false;
            }
           
        }

        private int get_question_index()
        {
            Random rand = new Random();
            int index = rand.Next(6);
            return index;
        }

        private List<String> get_question(String theme, int index)
        {
            List<String> result = new List<string>();
            string my_file = "";
            AssetManager assetManager = Android.App.Application.Context.Assets;
            System.IO.StreamReader file = new System.IO.StreamReader(assetManager.Open("Questions/"+theme+".json"));
            {
                my_file = file.ReadToEnd();
            }
            file.Close();
            dynamic parser = JObject.Parse(my_file);
            result.Add((string)parser.SelectToken("questions[" + index + "].question"));
            Random rand = new Random();
            int[] list_index = { 0, 1, 2, 3 };
            for (int i = 0; i <4; i++)
            {
                // tirage au sort d'un index entre 0 et la valeur courante de "i"
                int randomIndex = rand.Next(i);
                // intervertion des éléments situés aux index "i" et "randomIndex"
                int temp = list_index[i];
                list_index[i] = list_index[randomIndex];
                list_index[randomIndex] = temp;
            }
            foreach(int i in list_index)
            {
                result.Add((string)parser.SelectToken("questions[" + index + "].responses[" + i + "].reponse"));
                result.Add((string)parser.SelectToken("questions[" + index + "].responses[" + i + "].vrai"));
            }
            return result;

        }

  
        /*role : sert à changer les thèmes marqués sur les boutons et les couleurs 
         * entrée : 5 string qui correspondent aux thèmes à marquer sur les boutons et le label qui est pour la question
         * sortie : vide
         */
        public void changerQuestion(List<String> question_responses)
        {
            label_.Text = question_responses[0];
            bouton1.Text = question_responses[1]; 
            bouton2.Text = question_responses[3];
            bouton3.Text = question_responses[5];
            bouton4.Text = question_responses[7];
        }
    }
}