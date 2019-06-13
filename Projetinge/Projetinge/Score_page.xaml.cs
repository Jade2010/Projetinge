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
    public partial class Score_page : ContentPage
    {
        public Score_page(int score,List<String> list_string)
        {
            InitializeComponent();
            label.Text = score.ToString();
            labeltheme.Text = get_preference(list_string);
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
    }
}