using System.Collections.Generic;
using CW_v3.Models;
using CW_v3.ViewModels.Base;

namespace CW_v3.ViewModels.FarmUserControls
{
    public class LandAddressViewModel : UserControlViewModel
    {
        private List<LandAddress> _landAddresses;

        public List<LandAddress> LandAddresses
        {
            get => _landAddresses;
            set => SetField(ref _landAddresses, value);
        }
        
        private List<LocationType> _locationTypes;

        public List<LocationType> LocationTypes
        {
            get => _locationTypes;
            set => SetField(ref _locationTypes, value);
        }

        private LocationType _selectedLocation;
       
        public LocationType SelectedLocation
        {
            get => _selectedLocation;
            set => SetField(ref _selectedLocation, value);
        }

        private string _branchName;
        public string BranchName
        {
            get => _branchName;
            set => SetField(ref _branchName, value);
        }
        
        private string _address;
        public string Address
        {
            get => _address;
            set => SetField(ref _address, value);
        }
        
        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateLandAddress(SelectedLocation.Id, BranchName, Address);
            UpdateData();
            EnterViewDataStateCommand?.Execute(p);
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            LandAddress address = p as LandAddress;
            _databaseService.DeleteLandAddress(address.Id);
            UpdateData();
        }

        public override void UpdateData()
        {
            LandAddresses = _databaseService.GetAllLandAddresses();
            LocationTypes = _databaseService.GetAllLocationType();
        }

        public LandAddressViewModel() : base()
        {
            UpdateData();
        }
    }
}