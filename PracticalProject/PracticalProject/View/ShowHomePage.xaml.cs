using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracticalProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowHomePage : ContentPage
    {
        public ShowHomePage()
        {
            InitializeComponent();
        }

        private async void OnAnimalTableClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowAnimalPage());
        }
    }
}