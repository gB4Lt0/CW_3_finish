using System.Collections.Generic;
using System.Windows.Input;
using CW_v3.Infrastructure.Commands;
using CW_v3.Models;
using CW_v3.ViewModels.Base;

namespace CW_v3.ViewModels.ImportExportViewModels
{
    public class ExportWarehousesViewModel : UserControlViewModel
    {
        private List<ExportWarehouse> _exportWarehouses;

        public List<ExportWarehouse> ExportWarehouses
        {
            get => _exportWarehouses;
            set => SetField(ref _exportWarehouses, value);
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
        
        private string _warehouseName;

        public string WarehouseName
        {
            get => _warehouseName;
            set => SetField(ref _warehouseName, value);
        }
        
        private int _quantity;

        public int Quantity
        {
            get => _quantity;
            set => SetField(ref _quantity, value);
        }
        
        private int _pricePerKilo;

        public int PricePerKilo
        {
            get => _pricePerKilo;
            set => SetField(ref _pricePerKilo, value);
        }

        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateExportWarehouse(SelectedExportType.Id, WarehouseName, Quantity, PricePerKilo);
            UpdateData();
            EnterViewDataStateCommand.Execute(p);
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            ExportWarehouse exportWarehouse = p as ExportWarehouse;
            _databaseService.DeleteExportWarehouse(exportWarehouse.Id);
            UpdateData();
        }

        public override void UpdateData()
        {
            ExportWarehouses = _databaseService.GetAllExportWarehouse();
            ExportTypes = _databaseService.GetAllExportTypes();
        }

        public ExportWarehousesViewModel() : base()
        {
            UpdateData();
        }
    }
}