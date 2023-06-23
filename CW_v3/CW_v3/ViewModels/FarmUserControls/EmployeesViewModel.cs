using System.Collections.Generic;
using CW_v3.Models;
using CW_v3.ViewModels.Base;

namespace CW_v3.ViewModels.FarmUserControls
{
    public class EmployeesViewModel : UserControlViewModel
    {
        private List<Employee> _employees;

        public List<Employee> Employees
        {
            get => _employees;
            set => SetField(ref _employees, value);
        }

        private List<LandAddress> _landAddresses;

        public List<LandAddress> LandAddresses
        {
            get => _landAddresses;
            set => SetField(ref _landAddresses, value);
        }

        private List<TypeOfWork> _typesOfWork;

        public List<TypeOfWork> TypesOfWork
        {
            get => _typesOfWork;
            set => SetField(ref _typesOfWork, value);
        }

        private LandAddress _selectedLandAddress;

        public LandAddress SelectedLandAddress
        {
            get => _selectedLandAddress;
            set => SetField(ref _selectedLandAddress, value);
        }

        private TypeOfWork _selectedTypeOfWork;

        public TypeOfWork SelectedTypeOfWork
        {
            get => _selectedTypeOfWork;
            set => SetField(ref _selectedTypeOfWork, value);
        }

        private string _fullName;

        public string FullName
        {
            get => _fullName;
            set => SetField(ref _fullName, value);
        }

        private string _addressOfResidence;

        public string AddressOfResidence
        {
            get => _addressOfResidence;
            set => SetField(ref _addressOfResidence, value);
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetField(ref _phoneNumber, value);
        }

        protected override void OnCreateRecordCommandExecute(object p)
        {
            _databaseService.CreateEmployee(SelectedTypeOfWork.Id, SelectedLandAddress.Id, FullName, AddressOfResidence,
                PhoneNumber);
            UpdateData();
            EnterViewDataStateCommand.Execute(p);
        }

        protected override void OnDeleteRecordCommandExecute(object p)
        {
            Employee employee = p as Employee;
            _databaseService.DeleteEmployee(employee.Id);
            UpdateData();
        }

        public override void UpdateData()
        {
            Employees = _databaseService.GetAllEmployees();
            LandAddresses = _databaseService.GetAllLandAddresses();
            TypesOfWork = _databaseService.GetAllTypeOfWork();
        }

        public EmployeesViewModel() : base()
        {
            UpdateData();
        }
    }
}