using System;
using System.Collections.Generic;
using CW_v3.Models;
using CW_v3.ViewModels.Base;

namespace CW_v3.ViewModels.ImportExportViewModels
{
    public class ExportViewModel : UserControlViewModel
    {
         private List<Export> _exports;

        public List<Export> Exports
        {
            get => _exports;
            set => SetField(ref _exports, value);
        }
        
        private List<ExportAddress> _exportAddresses;

        public List<ExportAddress> ExportAddresses
        {
            get => _exportAddresses;
            set => SetField(ref _exportAddresses, value);
        }
        
        private ExportAddress _selectedExportAddress;

        public ExportAddress SelectedExportAddress
        {
            get => _selectedExportAddress;
            set => SetField(ref _selectedExportAddress, value);
        }
        
        private List<ExportWarehouse> _exportWarehouses;

        public List<ExportWarehouse> ExportWarehouses
        {
            get => _exportWarehouses;
            set => SetField(ref _exportWarehouses, value);
        }
        
        private ExportWarehouse _selectedExportWarehouses;

        public ExportWarehouse SelectedExportWarehouses
        {
            get => _selectedExportWarehouses;
            set => SetField(ref _selectedExportWarehouses, value);
        }
        
        private List<ExportType> _exportTypes;

        public List<ExportType> ExportTypes
        {
            get => _exportTypes;
            set => SetField(ref _exportTypes, value);
        }
        
        private ExportType _selectedExportType;

        public ExportType SelectedExportType
        {
            get => _selectedExportType;
            set => SetField(ref _selectedExportType, value);
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
        
        private DateTime _saleDate = DateTime.Now;

        public DateTime SaleDate
        {
            get => _saleDate;
            set => SetField(ref _saleDate, value);
        }

        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateExport(SelectedExportAddress.Id,
                SelectedExportWarehouses.Id, 
                SelectedExportWarehouses.ExportTypeId, SelectedExportWarehouses.ProductName, 
                SelectedExportWarehouses.Quantity, 
                SelectedExportWarehouses.Quantity * SelectedExportWarehouses.PricePerKilo,
                SaleDate.ToString("yyyy-MM-dd"));
            _databaseService.DeleteExportWarehouse(SelectedExportWarehouses.Id);
            UpdateData();
            EnterViewDataStateCommand.Execute(p);
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            Export export = p as Export;
            _databaseService.DeleteExport(export.Id);
            UpdateData();
        }

        public override void UpdateData()
        {
            Exports = _databaseService.GetAllExport();
            ExportAddresses = _databaseService.GetAllExportAddresses();
            ExportTypes = _databaseService.GetAllExportTypes();
            ExportWarehouses = _databaseService.GetAllExportWarehouse();
        }

        public ExportViewModel() : base()
        {
            UpdateData();
        }
    }
}