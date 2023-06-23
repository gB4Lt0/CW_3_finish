using System.Collections.Generic;
using System.Windows;
using CW_v3.Models;
using CW_v3.ViewModels.Base;

namespace CW_v3.ViewModels.ImportExportViewModels
{
    public class LocationTypeViewModel : UserControlViewModel
    {
        
        private List<LocationType> _locationTypes;
        public List<LocationType> LocationTypes
        {
            get => _locationTypes;
            set => SetField(ref _locationTypes, value);
        }
        
        private string _name;

        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateLocationType(_name);
            UpdateData();
            EnterViewDataStateCommand.Execute(p);
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            LocationType obj = p as LocationType;
            _databaseService.DeleteLocationType(obj.Id);
            UpdateData();
        }

        public override void UpdateData()
        {
            LocationTypes = _databaseService.GetAllLocationType();
        }

        public LocationTypeViewModel() : base()
        {
            UpdateData();
        }
    }
}