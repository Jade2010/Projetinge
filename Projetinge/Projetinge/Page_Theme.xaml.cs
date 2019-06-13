﻿using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projetinge
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Theme : ContentPage
    {
        public Page_Theme(int score,int question_number, List<String> list_string)
        {
            InitializeComponent();
            BackgroundImageSource = "DecoderBackground.png";
            changerTheme(set_theme());
            question_number++;
            labelScore.Text = "S :"+score.ToString();
            labelNBQuestion.Text = "Q :" +question_number.ToString() + "/8";
            bouton1.Clicked += async (sender, args) =>
            {
                list_string.Add(bouton1.Text);
                await Navigation.PushAsync(new Page_Questions(bouton1.Text,score, question_number, list_string));
                new Page_Questions(bouton1.Text, score, question_number, list_string);
            };
            bouton2.Clicked += async (sender, args) =>
            {
                list_string.Add(bouton2.Text);
                await Navigation.PushAsync(new Page_Questions(bouton2.Text,score, question_number, list_string));
            };
            bouton3.Clicked += async (sender, args) =>
            {
                list_string.Add(bouton3.Text);
               await Navigation.PushAsync(new Page_Questions(bouton3.Text,score, question_number, list_string));
            };
            bouton4.Clicked += async (sender, args) =>
            {
                list_string.Add(bouton4.Text);
               await Navigation.PushAsync(new Page_Questions(bouton4.Text,score, question_number, list_string));
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
        }
    }
}