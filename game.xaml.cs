using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class game : ContentPage
    {
        public game(int row1,int col1, int[,]data,int trial, ArrayList visited)
        {
            InitializeComponent();
            //print out grid according to spots visited
            for (int row = 0; row < row1; row++)
            {
                for (int column = 0; column < col1; column++)
                {
                    Label label1 = new Label
                    {
                        Text = data[row, column].ToString(),
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontSize = 25,
                        TextColor = Color.WhiteSmoke,
                        FontAttributes = FontAttributes.Bold

                    };
                    grid.Children.Add(label1, column, row);
                }
            }
            DisplayAlert("Trails", "Trial " + (trial + 1) + ": " + "The Knight was able to successfully touch " + visited.Count + " Squares", "OK");
        }
    }
}