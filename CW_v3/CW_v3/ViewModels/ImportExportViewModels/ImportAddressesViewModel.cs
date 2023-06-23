using System.Collections.Generic;
using CW_v3.Models;
using CW_v3.ViewModels.Base;

namespace CW_v3.ViewModels.ImportExportViewModels
{
    public class ImportAddressesViewModel : UserControlViewModel
    {
        private List<ImportAddress> _importAddresses;

        public List<ImportAddress> ImportAddresses
        {
            get => _importAddresses;
            set => SetField(ref _importAddresses, value);
        }
        
        private List<LocationType> _locationTypes;
        public List<LocationType> LocationTypes
        {
            get => _locationTypes;
            set => SetField(ref _locationTypes, value);
        }

        private LocationType _selectedLocationType;
        public LocationType SelectedLocationType
        {
            get => _selectedLocationType;
            set => SetField(ref _selectedLocationType, value);
        }
        
        private string _companyName;

        public string CompanyName
        {
            get => _companyName;
            set => SetField(ref _companyName, value);
        }
        
        private string _address;

        public string Address
        {
            get => _address;
            set => SetField(ref _address, value);
        }
        
        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateImportAddress(SelectedLocationType.Id, CompanyName, Address);
            UpdateData();
            EnterViewDataStateCommand.Execute(p);
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            ImportAddress importAddress = p as ImportAddress;
            _databaseService.DeleteImportAddress(importAddress.Id);
            UpdateData();
        }

        public override void UpdateData()
        {
            ImportAddresses = _databaseService.GetAllImportAddresses();
            LocationTypes = _databaseService.GetAllLocationType();
        }

        public ImportAddressesViewModel() : base()
        {
            UpdateData();
        }
    }
}