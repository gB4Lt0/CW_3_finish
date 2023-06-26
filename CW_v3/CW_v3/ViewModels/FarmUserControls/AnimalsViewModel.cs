using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;
using CW_v3.Models;
using CW_v3.ViewModels.Base;
using CW_v3.Infrastructure.Commands;

namespace CW_v3.ViewModels.FarmUserControls
{
    public class AnimalsViewModel : UserControlViewModel
    {
        private List<Animal> _animals;
        public List<Animal> Animals
        {
            get => _animals;
            set => SetField(ref _animals, value);
        }

        private List<AnimalType> _animalTypes;
        public List<AnimalType> AnimalTypes
        {
            get => _animalTypes;
            set => SetField(ref _animalTypes, value);
        }

        private List<LandAddress> _landAddresses;
        public List<LandAddress> LandAddresses
        {
            get => _landAddresses;
            set => SetField(ref _landAddresses, value);
        }

        private string _gender;
        public string Gender
        {
            get => _gender;
            set => SetField(ref _gender, value);
        }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set => SetField(ref _quantity, value);
        }

        private int _consumption;
        public int Consumption
        {
            get => _consumption;
            set => SetField(ref _consumption, value);
        }

        private LandAddress _selectedLandAddress;
        public LandAddress SelectedLandAddress
        {
            get => _selectedLandAddress;
            set => SetField(ref _selectedLandAddress, value);
        }

        private AnimalType _selectedAnimalType;
        public AnimalType SelectedAnimalType
        {
            get => _selectedAnimalType;
            set => SetField(ref _selectedAnimalType, value);
        }

        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateAnimal(SelectedLandAddress.Id, SelectedAnimalType.Id,
                                            Gender, Quantity, Consumption);
            UpdateData();
            EnterViewDataStateCommand.Execute(p);
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            Animal animal = p as Animal;
            _databaseService.DeleteAnimal(animal.Id);
            UpdateData();
        }


        private Animal _currentAnimal;

        public ICommand EditRecord { get; }

        private bool CanEditRecordCommandExecute(object p) => true;

        private void OnEditRecordCommandExecute(object p)
        {
            _currentAnimal = p as Animal;
            Quantity = _currentAnimal.Quantity;
            Consumption = _currentAnimal.Consumption;

            EnterEditFieldStateCommand.Execute(p);
        }

        public ICommand SaveEditingRecord { get; }

        private bool CanSaveEditingRecordCommandExecute(object p) => true;

        private void OnSaveEditingRecordCommandExecute(object p)
        {
            EnterViewDataStateCommand.Execute(p);

            _databaseService.EditAnimals(_currentAnimal.Id, _currentAnimal.LandAddressesId, _currentAnimal.AnimalTypeId, _currentAnimal.Gender, Quantity, Consumption);
            UpdateData();
        }

        public override void UpdateData()
        {
            Animals = _databaseService.GetAllAnimals();
            AnimalTypes = _databaseService.GetAllAnimalType();
            LandAddresses = _databaseService.GetAllLandAddresses();
        }

        public AnimalsViewModel() : base()
        {
            UpdateData();
            EditRecord = new LambdaCommand(OnEditRecordCommandExecute, CanEditRecordCommandExecute);
            SaveEditingRecord = new LambdaCommand(OnSaveEditingRecordCommandExecute, CanSaveEditingRecordCommandExecute);
        }
    }
}