using System.Collections.Generic;
using System.Windows.Input;
using CW_v3.Infrastructure.Commands;
using CW_v3.Models;
using CW_v3.ViewModels.Base;

namespace CW_v3.ViewModels.FarmUserControls
{
    public class TypeOfWorkViewModel : UserControlViewModel
    {
        private List<TypeOfWork> _typeOfWorks;

        public List<TypeOfWork> TypeOfWorks
        {
            get => _typeOfWorks;
            set => SetField(ref _typeOfWorks, value);
        }

        private string _typeOfWorkName;

        public string TypeOfWorkName
        {
            get => _typeOfWorkName;
            set => SetField(ref _typeOfWorkName, value);
        }
        
        private int _salary;

        public int Salary
        {
            get => _salary;
            set => SetField(ref _salary, value);
        }
        
        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateTypeOfWork(TypeOfWorkName, Salary);
            UpdateData();
            EnterViewDataStateCommand?.Execute(p);
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            TypeOfWork work = p as TypeOfWork;
            _databaseService.DeleteTypeOfWork(work.Id);
            UpdateData();
        }

        private TypeOfWork _currentTypeOfWork;

        public ICommand EditRecord { get; }

        private bool CanEditRecordCommandExecute(object p) => true;

        private void OnEditRecordCommandExecute(object p)
        {
            _currentTypeOfWork = p as TypeOfWork;
            Salary = _currentTypeOfWork.Salary;

            EnterEditFieldStateCommand.Execute(p);
        }

        public ICommand SaveEditingRecord { get; }

        private bool CanSaveEditingRecordCommandExecute(object p) => true;

        private void OnSaveEditingRecordCommandExecute(object p)
        {
            EnterViewDataStateCommand.Execute(p);

            _databaseService.EditTypeOfWork(_currentTypeOfWork.Id, _currentTypeOfWork.TypeOfWorkName, Salary);
            UpdateData();
        }

        public override void UpdateData()
        {
            TypeOfWorks = _databaseService.GetAllTypeOfWork();
        }

        public TypeOfWorkViewModel() : base()
        {
            UpdateData();

            EditRecord = new LambdaCommand(OnEditRecordCommandExecute, CanEditRecordCommandExecute);
            SaveEditingRecord = new LambdaCommand(OnSaveEditingRecordCommandExecute, CanSaveEditingRecordCommandExecute);
        }
    }
}