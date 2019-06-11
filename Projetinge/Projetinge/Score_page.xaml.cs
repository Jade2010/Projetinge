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
        public Score_page(int score)
        {
            InitializeComponent();
            label.Text = score.ToString();
        }
    }
}