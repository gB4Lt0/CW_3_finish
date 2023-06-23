using System;
using System.Collections.Generic;
using CW_v3.Models;
using CW_v3.ViewModels.Base;

namespace CW_v3.ViewModels.FarmUserControls
{
    public class PlantationViewModel : UserControlViewModel
    {
        private List<LandAddress> _landAddresses;

        public List<LandAddress> LandAddresses
        {
            get => _landAddresses;
            set => SetField(ref _landAddresses, value);
        }
        
        private LandAddress _selectedLandAddress;

        public LandAddress SelectedLandAddress
        {
            get => _selectedLandAddress;
            set => SetField(ref _selectedLandAddress, value);
        }
        
        private List<Plantation> _plantations;

        public List<Plantation> Plantations
        {
            get => _plantations;
            set => SetField(ref _plantations, value);
        }

        private int _plantationQuantity;

        public int PlantationQuantity
        {
            get => _plantationQuantity;
            set => SetField(ref _plantationQuantity, value);
        }
        
        private string _plantationName;

        public string PlantationName
        {
            get => _plantationName;
            set => SetField(ref _plantationName, value);
        }
        private DateTime _plantationDate = DateTime.Now;

        public DateTime PlantationDate
        {
            get => _plantationDate;
            set => SetField(ref _plantationDate, value);
        }

        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreatePlantation(SelectedLandAddress.Id, PlantationName, PlantationQuantity, PlantationDate.ToString("yyyy-MM-dd"));
            UpdateData();
            EnterViewDataStateCommand.Execute(p);
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            Plantation plantation = p as Plantation;
            _databaseService.DeletePlantation(plantation.Id);
            UpdateData();
        }

        public override void UpdateData()
        {
            Plantations = _databaseService.GetAllPlantation();
            LandAddresses = _databaseService.GetAllLandAddresses();
        }

        public PlantationViewModel() : base()
        {
            UpdateData();
        }
    }
}