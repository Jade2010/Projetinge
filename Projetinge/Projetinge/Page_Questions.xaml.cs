﻿using Android.Content.Res;
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
            List<String> question_responses = new List<string>();
            question_responses = get_question(theme, get_question_index());
            changerQuestion(question_responses);
            bouton1.Clicked += async (sender, args) =>
            {
                bouton1.BackgroundColor = question_responses[2] == "oui"? Color.FromHex("01FE32") :Color.FromHex("FE0101");
            };
            bouton2.Clicked += async (sender, args) =>
            {
                bouton2.BackgroundColor = question_responses[4] == "oui" ? Color.FromHex("01FE32") : Color.FromHex("FE0101");
            };
            bouton3.Clicked += async (sender, args) =>
            {
                bouton3.BackgroundColor = question_responses[6] == "oui" ? Color.FromHex("01FE32") : Color.FromHex("FE0101");
            };
            bouton4.Clicked += async (sender, args) =>
            {
                bouton4.BackgroundColor = question_responses[8] == "oui" ? Color.FromHex("01FE32") : Color.FromHex("FE0101");
            };
            bouton5.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new Page_Theme());
            };
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