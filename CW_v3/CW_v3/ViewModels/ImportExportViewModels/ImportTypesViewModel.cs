using System.Collections.Generic;
using CW_v3.Models;
using CW_v3.ViewModels.Base;

namespace CW_v3.ViewModels.ImportExportViewModels
{
    public class ImportTypesViewModel : UserControlViewModel
    {
        private List<ImportType> _importTypes;

        public List<ImportType> ImportTypes
        {
            get => _importTypes;
            set => SetField(ref _importTypes, value);
        }
        
        private string _importName;

        public string ImportName
        {
            get => _importName;
            set => SetField(ref _importName, value);
        }

        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateImportType(ImportName);
            UpdateData();
            EnterViewDataStateCommand.Execute(p);
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            ImportType importType = p as ImportType;
            _databaseService.DeleteImportType(importType.Id);
            UpdateData();
        }

        public override void UpdateData()
        {
            ImportTypes = _databaseService.GetAllImportType();
        }

        public ImportTypesViewModel() : base()
        {
            UpdateData();
        }
    }
}