using System.Collections.Generic;
using CW_v3.Models;
using CW_v3.ViewModels.Base;

namespace CW_v3.ViewModels.ImportExportViewModels
{
    public class ExportTypeViewModel : UserControlViewModel
    {
        private List<ExportType> _exportTypes;

        public List<ExportType> ExportTypes
        {
            get => _exportTypes;
            set => SetField(ref _exportTypes, value);
        }
        
        private string _exportName;

        public string ExportName
        {
            get => _exportName;
            set => SetField(ref _exportName, value);
        }

        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateExportType(ExportName);
            UpdateData();
            EnterViewDataStateCommand.Execute(p);
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            ExportType exportType = p as ExportType;
            _databaseService.DeleteExportType(exportType.Id);
            UpdateData();
        }

        public override void UpdateData()
        {
            ExportTypes = _databaseService.GetAllExportTypes();
        }

        public ExportTypeViewModel() : base()
        {
            UpdateData();
        }
    }
}