using System.Data;
using System.Windows.Controls;
using System.Windows.Input;
using CW_v3.Database;
using CW_v3.Infrastructure.Commands;
using CW_v3.ViewModels.Base;
using CW_v3.ViewModels.FarmUserControls;
using CW_v3.ViewModels.ImportExportViewModels;
using CW_v3.Views.UserControls;

namespace CW_v3.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region view models

        private ViewModel _currentViewModelInFarm;

        public ViewModel CurrentViewModelInFarm
        {
            get => _currentViewModelInFarm;
            set => SetField(ref _currentViewModelInFarm, value);
        }
        private ViewModel _currentViewModelInImportExport;

        public ViewModel CurrentViewModelInImportExport
        {
            get => _currentViewModelInImportExport;
            set => SetField(ref _currentViewModelInImportExport, value);
        }

        #endregion
        #region user controls
        
        private UserControl _currentExportImportUS;
        private UserControl _currentFarmUS;

        public UserControl CurrentExportImportUS
        {
            get => _currentExportImportUS;
            set => SetField(ref _currentExportImportUS, value);
        }
        public UserControl CurrentFarmUS
        {
            get => _currentFarmUS;
            set => SetField(ref _currentFarmUS, value);
        }
        
        #endregion

        #region Commands
        
        public ICommand LoadAnimalsTypes { get; }
        private bool CanLoadAnimalsTypesCommandExecute(object p) => true;

        private void OnLoadAnimalsTypesCommandExecute(object p)
        {
            CurrentViewModelInFarm = new AnimalTypeViewModel();
            CurrentFarmUS = new AnimalTypeUS(CurrentViewModelInFarm);
        }
        
        public ICommand LoadAnimals { get; }
        private bool CanLoadAnimalsCommandExecute(object p) => true;

        private void OnLoadAnimalsCommandExecute(object p)
        {
            CurrentViewModelInFarm = new AnimalsViewModel();
            CurrentFarmUS = new AnimalsUS(CurrentViewModelInFarm);
        }
        
        public ICommand LoadLocationType { get; }
        private bool CanLoadLocationTypeCommandExecute(object p) => true;

        private void OnLoadLocationTypeCommandExecute(object p)
        {
            CurrentViewModelInImportExport = new LocationTypeViewModel();
            CurrentExportImportUS = new LocationTypeUS(CurrentViewModelInImportExport);
        }
        
        public ICommand LoadLandAddress { get; }
        private bool CanLoadLandAddressCommandExecute(object p) => true;

        private void OnLoadLandAddressCommandExecute(object p)
        {
            CurrentViewModelInFarm = new LandAddressViewModel();
            CurrentFarmUS = new LandAddressUS(CurrentViewModelInFarm);
        }
        
        public ICommand LoadEmployees { get; }
        private bool CanLoadEmployeesCommandExecute(object p) => true;

        private void OnLoadEmployeesCommandExecute(object p)
        {
            CurrentViewModelInFarm = new EmployeesViewModel();
            CurrentFarmUS = new EmployeesUS(CurrentViewModelInFarm);
        }
        
        public ICommand LoadPlantations { get; }
        private bool CanLoadPlantationsCommandExecute(object p) => true;

        private void OnLoadPlantationsCommandExecute(object p)
        {
            CurrentViewModelInFarm = new PlantationViewModel();
            CurrentFarmUS = new PlantationsUS(CurrentViewModelInFarm);
        }
        
        public ICommand LoadTypeOfWorks { get; }
        private bool CanLoadTypeOfWorksCommandExecute(object p) => true;

        private void OnLoadTypeOfWorksCommandExecute(object p)
        {
            CurrentViewModelInFarm = new TypeOfWorkViewModel();
            CurrentFarmUS = new TypeOfWorkUS(CurrentViewModelInFarm);
        }
        
        public ICommand LoadExportTypes { get; }
        private bool CanLoadExportTypesCommandExecute(object p) => true;

        private void OnLoadExportTypesCommandExecute(object p)
        {
            CurrentViewModelInImportExport = new ExportTypeViewModel();
            CurrentExportImportUS = new ExportTypesUS(CurrentViewModelInImportExport);
        }
        
        public ICommand LoadImportTypes { get; }
        private bool CanLoadImportTypesCommandExecute(object p) => true;

        private void OnLoadImportTypesCommandExecute(object p)
        {
            CurrentViewModelInImportExport = new ImportTypesViewModel();
            CurrentExportImportUS = new ImportTypesUS(CurrentViewModelInImportExport);
        }
        
        public ICommand LoadImportAddresses { get; }
        private bool CanLoadImportAddressesCommandExecute(object p) => true;

        private void OnLoadImportAddressesCommandExecute(object p)
        {
            CurrentViewModelInImportExport = new ImportAddressesViewModel();
            CurrentExportImportUS = new ImportAddressesUS(CurrentViewModelInImportExport);
        }
        
        public ICommand LoadExportAddresses { get; }
        private bool CanLoadExportAddressesCommandExecute(object p) => true;

        private void OnLoadExportAddressesCommandExecute(object p)
        {
            CurrentViewModelInImportExport = new ExportAddressesViewModel();
            CurrentExportImportUS = new ExportAddressesUS(CurrentViewModelInImportExport);
        }
        
        public ICommand LoadExportWarehouses { get; }
        private bool CanLoadExportWarehousesCommandExecute(object p) => true;

        private void OnLoadExportWarehousesCommandExecute(object p)
        {
            CurrentViewModelInImportExport = new ExportWarehousesViewModel();
            CurrentExportImportUS = new ExportWarehouseUS(CurrentViewModelInImportExport);
        }
        
        public ICommand LoadImports { get; }
        private bool CanLoadImportsCommandExecute(object p) => true;

        private void OnLoadImportsCommandExecute(object p)
        {
            CurrentViewModelInImportExport = new ImportViewModel();
            CurrentExportImportUS = new ImportUS(CurrentViewModelInImportExport);
        }
        
        public ICommand LoadExports { get; }

        private bool CanLoadExportsCommandExecute(object p) => true;

        private void OnLoadExportsCommandExecute(object p)
        {
            CurrentViewModelInImportExport = new ExportViewModel();
            CurrentExportImportUS = new ExportUS(CurrentViewModelInImportExport);
        }
        
        #endregion

        private string _currentCustomQuery;

        public string CurrentCustomQuery
        {
            get => _currentCustomQuery;
            set => SetField(ref _currentCustomQuery, value);
        }
        private DataView _currentDataView;

        public  DataView CurrentDataView
        {
            get => _currentDataView;
            set => SetField(ref _currentDataView, value);
        }
        
        public ICommand ExecuteCustomQuery { get; }

        private bool CanExecuteCustomQueryCommandExecute(object p) => true;

        private void OnExecuteCustomQueryCommandExecute(object p)
        {
            CurrentDataView = DatabaseService.Instance.ExecuteCustomQuery(CurrentCustomQuery);
        }
        
        public MainWindowViewModel()
        {
            LoadAnimalsTypes = new LambdaCommand(OnLoadAnimalsTypesCommandExecute, CanLoadAnimalsTypesCommandExecute);
            LoadAnimals = new LambdaCommand(OnLoadAnimalsCommandExecute, CanLoadAnimalsCommandExecute);
            LoadLocationType = new LambdaCommand(OnLoadLocationTypeCommandExecute, CanLoadLocationTypeCommandExecute);
            LoadLandAddress = new LambdaCommand(OnLoadLandAddressCommandExecute, CanLoadLandAddressCommandExecute);
            LoadEmployees = new LambdaCommand(OnLoadEmployeesCommandExecute, CanLoadEmployeesCommandExecute);
            LoadPlantations = new LambdaCommand(OnLoadPlantationsCommandExecute, CanLoadPlantationsCommandExecute);
            LoadTypeOfWorks = new LambdaCommand(OnLoadTypeOfWorksCommandExecute, CanLoadTypeOfWorksCommandExecute);
            LoadExportTypes = new LambdaCommand(OnLoadExportTypesCommandExecute, CanLoadExportTypesCommandExecute);
            LoadImportTypes = new LambdaCommand(OnLoadImportTypesCommandExecute, CanLoadImportTypesCommandExecute);
            LoadImportAddresses = new LambdaCommand(OnLoadImportAddressesCommandExecute, CanLoadImportAddressesCommandExecute);
            LoadExportAddresses = new LambdaCommand(OnLoadExportAddressesCommandExecute, CanLoadExportAddressesCommandExecute);
            LoadExportWarehouses = new LambdaCommand(OnLoadExportWarehousesCommandExecute, CanLoadExportWarehousesCommandExecute);
            LoadImports = new LambdaCommand(OnLoadImportsCommandExecute, CanLoadImportsCommandExecute);
            LoadExports = new LambdaCommand(OnLoadExportsCommandExecute, CanLoadExportsCommandExecute);
            ExecuteCustomQuery = new LambdaCommand(OnExecuteCustomQueryCommandExecute, CanExecuteCustomQueryCommandExecute);
        }
    }
}