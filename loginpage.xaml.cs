using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class loginpage : ContentPage
    {
        public loginpage()
        {
            InitializeComponent();
        }

        private async void btnlogin(object sender, EventArgs e)
        {       
                if (userid.Text == "topg" && password.Text == "1234")
                {
                    await Navigation.PushAsync(new mainPage());
                }
                else
                {
                    DisplayAlert("Invalid","Please enter valid Username and Password","Try Again");
                    userid.Text = string.Empty;
                    password.Text = string.Empty;
                }
            
        }
    }
}