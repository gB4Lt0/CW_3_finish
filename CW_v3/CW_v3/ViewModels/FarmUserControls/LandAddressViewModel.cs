using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CW_v3.Infrastructure.Commands;
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

        private LandAddress _currentLandAddress;

        public ICommand EditRecord { get; }

        private bool CanEditRecordCommandExecute(object p) => true;

        private void OnEditRecordCommandExecute(object p)
        {
            EnterEditFieldStateCommand.Execute(p);
            _currentLandAddress = p as LandAddress;
            SelectedLocation = LocationTypes.Where(x => x.Id == _currentLandAddress.LocationTypeId).FirstOrDefault();
            BranchName = _currentLandAddress.BranchName;
            Address = _currentLandAddress.Address;
        }

        public ICommand SaveEditingRecord { get; }

        private bool CanSaveEditingRecordCommandExecute(object p) => true;

        private void OnSaveEditingRecordCommandExecute(object p)
        {
            EnterViewDataStateCommand.Execute(p);

            _databaseService.EditLandAddresses(_currentLandAddress.Id, SelectedLocation.Id, BranchName, Address);
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
            EditRecord = new LambdaCommand(OnEditRecordCommandExecute, CanEditRecordCommandExecute);
            SaveEditingRecord = new LambdaCommand(OnSaveEditingRecordCommandExecute, CanSaveEditingRecordCommandExecute);
        }
    }
}