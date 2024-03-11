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
    public partial class mainPage : ContentPage
    {
        public mainPage()
        {
            InitializeComponent();
        }
        private async void btnplay(object sender, EventArgs e)
        {
            //Taking inputs converting and saving into local variables
            int r = int.Parse(rows_.Text);
            int c = int.Parse(columns_.Text);
            int x = int.Parse(x_coord.Text);
            int y = int.Parse(y_coord.Text);
            int rerun1 = int.Parse(rerun.Text);
            //setting grid to user input
            int[,] array = new int[r, c];

            //counter for testing the 8 different options
            int counter = 0;

            for (int trial = 0; trial < rerun1; trial++)
            {
                //create an arraylist to track visited coords
                ArrayList visited = new ArrayList();

                //while loop for if you can move to a spot we have not seen
                //Does not fall out the grid
                while (visited.Count < r * c)
                {
                    counter = 0;

                    //i is x values (-2 bc lowest value x can be)
                    for (int i = -2; i < 3; i++)
                    {

                        //j is y values (-2 bc lowest value y can be)
                        for (int j = -2; j < 3; j++)
                        {
                            //Absolute x + y always equals to 3 according to all possible knight moves
                            if (Math.Abs(i) + Math.Abs(j) == 3)


                            {

                                //if new coordinates is within bounds
                                //get length(0) for row
                                //get length(1) for columns
                                if (0 <= x + i && x + i < array.GetLength(0) && 0 <= y + j && y + j < array.GetLength(1))
                                {
                                    //create a counter for moves not visited before
                                    if (!visited.Contains((x + i, y + j)))
                                    {
                                        visited.Add((x + i, y + j));

                                        //assigns the visited count to the grid
                                        array[x + i, y + j] = visited.Count;

                                        x += i;
                                        y += j;

                                    }
                                    else
                                    {
                                        //increase counter if its visited spot already
                                        counter += 1;
                                    }

                                }
                                else
                                {
                                    //increase counter if falls out of bound
                                    counter += 1;

                                }

                            }

                        }


                    }
                    //break if counter reaches 8 bc only 8 possible moves knight can make
                    if (counter == 8)
                    {
                        break;
                    }

                }

                //print each coordinate from arraylist
                foreach (var item in visited)
                {
                    //   Console.WriteLine(item);
                }

                if (rerun1 == 1)
                {
                    await Navigation.PushAsync(new game(r,c,array,trial,visited));
                }
                else
                {
                   DisplayAlert("Trails", "Trial " + (trial + 1) + ": " + "The Knight was able to successfully touch " + visited.Count + " Squares", "OK");

                }

            }
        }
    }
}