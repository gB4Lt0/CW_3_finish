using System.Collections.Generic;
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

        public override void UpdateData()
        {
            TypeOfWorks = _databaseService.GetAllTypeOfWork();
        }

        public TypeOfWorkViewModel() : base()
        {
            UpdateData();
        }
    }
}