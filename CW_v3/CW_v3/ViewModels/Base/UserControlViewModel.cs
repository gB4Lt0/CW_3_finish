using System.Windows;
using System.Windows.Input;
using CW_v3.Database;
using CW_v3.Infrastructure.Commands;

namespace CW_v3.ViewModels.Base
{
    public abstract class UserControlViewModel : ViewModel
    {
        private int _fontSizeUserControl = 25;
        public int FontSizeUserControl
        {
            get => _fontSizeUserControl;
            set => SetField(ref _fontSizeUserControl, value);
        }

        #region Visibility

        private Visibility _viewDataVisibility = Visibility.Visible;
        private Visibility _creatingVisibility = Visibility.Collapsed;
        private Visibility _editFieldVisibility = Visibility.Collapsed;

        public Visibility ViewDataVisibility
        {
            get => _viewDataVisibility;
            set => SetField(ref _viewDataVisibility, value);
        }

        public Visibility CreatingDataVisibility
        {
            get => _creatingVisibility;
            set => SetField(ref _creatingVisibility, value);
        }

        public Visibility EditDataVisibility
        {
            get => _editFieldVisibility;
            set => SetField(ref _editFieldVisibility, value);
        }

        #endregion

        #region Database

        protected readonly DatabaseService _databaseService;

        #endregion

        #region Commands

        #region Visibility Commands

        public ICommand EnterViewDataStateCommand { get; }

        private bool CanEnterViewDataStateCommandExecute(object p) => true;

        private void OnEnterViewDataStateCommandExecute(object p)
        {
            CreatingDataVisibility = Visibility.Collapsed;
            ViewDataVisibility = Visibility.Visible;
            EditDataVisibility = Visibility.Collapsed;

            UpdateData();
        }

        public ICommand EnterCreatingDataStateCommand { get; }

        private bool CanEnterCreatingDataStateCommandExecute(object p) => true;

        private void OnEnterCreatingDataStateCommandExecute(object p)
        {
            CreatingDataVisibility = Visibility.Visible;
            ViewDataVisibility = Visibility.Collapsed;
            EditDataVisibility = Visibility.Collapsed;

            UpdateData();
        }

        public ICommand EnterEditFieldStateCommand { get; }

        private bool CanEnterEditFieldStateCommandExecute(object p) => true;

        private void OnEnterEditFieldStateCommandExecute(object p)
        {
            CreatingDataVisibility = Visibility.Collapsed;
            ViewDataVisibility = Visibility.Collapsed;
            EditDataVisibility = Visibility.Visible;

            UpdateData();
        }

        #endregion

        #region Creat-Edit Records

        public ICommand CreateRecord { get; }
        protected bool CanCreateRecordCommandExecute(object p) => true;

        protected abstract void OnCreateRecordCommandExecute(object p);

        public ICommand DeleteRecord { get; }
        protected bool CanDeleteRecordCommandExecute(object p) => true;

        protected abstract void OnDeleteRecordCommandExecute(object p);

        #endregion

        #endregion

        public abstract void UpdateData();

        protected UserControlViewModel()
        {
            EnterViewDataStateCommand =
                new LambdaCommand(OnEnterViewDataStateCommandExecute, CanEnterViewDataStateCommandExecute);
            EnterCreatingDataStateCommand = new LambdaCommand(OnEnterCreatingDataStateCommandExecute,
                CanEnterCreatingDataStateCommandExecute);
            EnterEditFieldStateCommand =
                new LambdaCommand(OnEnterEditFieldStateCommandExecute, CanEnterEditFieldStateCommandExecute);

            CreateRecord = new LambdaCommand(OnCreateRecordCommandExecute, CanCreateRecordCommandExecute);
            DeleteRecord = new LambdaCommand(OnDeleteRecordCommandExecute, CanDeleteRecordCommandExecute);

            _databaseService = DatabaseService.Instance;
        }
    }
}