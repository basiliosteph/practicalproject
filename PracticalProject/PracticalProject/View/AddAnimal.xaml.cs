using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PracticalProject.Model;
using PracticalProject.ViewModel;
using System.Xml.Linq;

namespace PracticalProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAnimal : ContentPage
    {
        AnimalViewModel _viewModel;
        bool _isUpdate;
        int animalID;

        public AddAnimal()
        {
            InitializeComponent();
            _viewModel = new AnimalViewModel();
            _isUpdate = false;
        }

        public AddAnimal(AnimalModel obj)
        {
            InitializeComponent();
            _viewModel = new AnimalViewModel();
            if (obj != null)
            {
                animalID = obj.Id;
                txtAnimalCode.Text = obj.AnimalCode;
                txtCharacteristics.Text = obj.Characteristics;
                txtSpecies.Text = obj.Species;
                txtHabitat.Text = obj.Habitat;
                txtThreat.Text = obj.Threat;
                _isUpdate = true;
            }
        }

        // Call Save and Update

        private async void BtnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            AnimalModel obj = new AnimalModel();
            obj.AnimalCode = txtAnimalCode.Text;
            obj.Characteristics = txtCharacteristics.Text;
            obj.Species = txtSpecies.Text;
            obj.Habitat = txtHabitat.Text;
            obj.Threat = txtThreat.Text;

            if (_isUpdate)
            {
                obj.Id = animalID;
                await _viewModel.UpdateAnimal(obj);
            }
            else
            {
                _viewModel.InsertAnimal(obj);
            }

            await this.Navigation.PopAsync();
        }
    }
}