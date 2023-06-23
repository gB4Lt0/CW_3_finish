using System.Collections.Generic;
using CW_v3.Models;
using CW_v3.ViewModels.Base;

namespace CW_v3.ViewModels.FarmUserControls
{
    public class AnimalTypeViewModel : UserControlViewModel
    {
        private List<AnimalType> _animalsTypes;

        public List<AnimalType> AnimalsTypes
        {
            get => _animalsTypes;
            set => SetField(ref _animalsTypes, value);
        }

        private string _animalTypeName;

        public string AnimalTypeName
        {
            get => _animalTypeName;
            set => SetField(ref _animalTypeName, value);
        }

        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateAnimalType(_animalTypeName);
            AnimalsTypes = _databaseService.GetAllAnimalType();
            EnterViewDataStateCommand.Execute(p);
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            AnimalType obj = p as AnimalType;
            _databaseService.DeleteAnimalType(obj.Id);
            UpdateData();
        }

        public override void UpdateData()
        {
            AnimalsTypes = _databaseService.GetAllAnimalType();
        }

        public AnimalTypeViewModel() : base()
        {
            UpdateData();
        }
    }
}