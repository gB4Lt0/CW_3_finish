using System;
using System.Collections.Generic;
using CW_v3.Models;
using CW_v3.ViewModels.Base;

namespace CW_v3.ViewModels.ImportExportViewModels
{
    public class ImportViewModel : UserControlViewModel
    {
        private List<Import> _imports;

        public List<Import> Imports
        {
            get => _imports;
            set => SetField(ref _imports, value);
        }
        
        private List<ImportAddress> _importAddresses;

        public List<ImportAddress> ImportAddresses
        {
            get => _importAddresses;
            set => SetField(ref _importAddresses, value);
        }
        
        private ImportAddress _selectedImportAddress;

        public ImportAddress SelectedImportAddress
        {
            get => _selectedImportAddress;
            set => SetField(ref _selectedImportAddress, value);
        }
        
        private List<ImportType> _importTypes;

        public List<ImportType> ImportTypes
        {
            get => _importTypes;
            set => SetField(ref _importTypes, value);
        }
        
        private ImportType _selectedImportType;

        public ImportType SelectedImportType
        {
            get => _selectedImportType;
            set => SetField(ref _selectedImportType, value);
        }
        
        private string _name;

        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }
        
        private int _quantity;

        public int Quantity
        {
            get => _quantity;
            set => SetField(ref _quantity, value);
        }
        
        private int _price;

        public int Price
        {
            get => _price;
            set => SetField(ref _price, value);
        }
        
        private DateTime _importDate = DateTime.Now;

        public DateTime ImportDate
        {
            get => _importDate;
            set => SetField(ref _importDate, value);
        }

        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateImport(SelectedImportAddress.Id, SelectedImportType.Id,
            Name, Quantity, Price, ImportDate.ToString("yyyy-MM-dd"));
            UpdateData();
            EnterViewDataStateCommand.Execute(p);
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            Import import = p as Import;
            _databaseService.DeleteImport(import.Id);
            UpdateData();
        }

        public override void UpdateData()
        {
            Imports = _databaseService.GetAllImport();
            ImportAddresses = _databaseService.GetAllImportAddresses();
            ImportTypes = _databaseService.GetAllImportType();
        }

        public ImportViewModel() : base()
        {
            UpdateData();
        }
    }
}