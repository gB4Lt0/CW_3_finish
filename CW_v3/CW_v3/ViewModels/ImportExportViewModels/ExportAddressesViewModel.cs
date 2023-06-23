using System.Collections.Generic;
using CW_v3.Models;
using CW_v3.ViewModels.Base;

namespace CW_v3.ViewModels.ImportExportViewModels
{
    public class ExportAddressesViewModel : UserControlViewModel
    {
        private List<ExportAddress> _exportAddresses;

        public List<ExportAddress> ExportAddresses
        {
            get => _exportAddresses;
            set => SetField(ref _exportAddresses, value);
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
            _databaseService.CreateExportAddress(SelectedLocationType.Id, CompanyName, Address);
            UpdateData();
            EnterViewDataStateCommand.Execute(p);
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            ExportAddress exportAddress = p as ExportAddress;
            _databaseService.DeleteImportAddress(exportAddress.Id);
            UpdateData();
        }

        public override void UpdateData()
        {
            ExportAddresses = _databaseService.GetAllExportAddresses();
            LocationTypes = _databaseService.GetAllLocationType();
        }

        public ExportAddressesViewModel() : base()
        {
            UpdateData();
        }
    }
}