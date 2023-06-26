using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CW_v3.Models;
using System.Data.SQLite;
using System.Windows;
using System.Data;
using System.Xml.Linq;

namespace CW_v3.Database
{
    public class DatabaseService
    {
        private const string Path = "database.db";
        private const string ConnectionString = "Data Source=" + Path;

        private readonly SQLiteConnection _connection;

        public static DatabaseService Instance { get; } = new DatabaseService();

        private DatabaseService()
        {
            _connection = new SQLiteConnection(ConnectionString);
        }

        private void ExecuteQuery(string query)
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public DataView ExecuteCustomQuery(string query)
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand(query, _connection);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable datatable = new DataTable("DataTable");
            try
            {
                adapter.Fill(datatable);
                _connection.Close();
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Query error");
                _connection.Close();
            }

            return datatable.DefaultView;
        }


        #region Location_Type

        public void CreateLocationType(string name)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO Location_Type (name)");
            query.Append($"VALUES (\"{name}\")");
            ExecuteQuery(query.ToString());
        }

        public List<LocationType> GetAllLocationType()
        {
            List<LocationType> locationTypes = new List<LocationType>();

            string query = "SELECT * FROM Location_Type";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                locationTypes.Add(new LocationType(reader.GetInt32(0), reader.GetString(1)));
            }

            _connection.Close();

            return locationTypes;
        }

        public void DeleteLocationType(int locationTypeId)
        {
            string query = $"DELETE FROM Location_Type WHERE id={locationTypeId}";
            ExecuteQuery(query);
        }

        public void EditLocationType(int locationTypeId, string name)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"UPDATE Location_Type SET name = \"{name}\"");
            query.Append($"WHERE id = {locationTypeId}");
            ExecuteQuery(query.ToString());
        }

        #endregion

        #region Land_Addresses

        public void CreateLandAddress(int locationTypeId, string branchName, string address)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO Land_Addresses (location_type_id, branch_name, address)");
            query.Append($"VALUES (\"{locationTypeId}\",\"{branchName}\",\"{address}\")");
            ExecuteQuery(query.ToString());
        }

        public List<LandAddress> GetAllLandAddresses()
        {
            List<LandAddress> landAddresses = new List<LandAddress>();

            string query = "SELECT * FROM Land_Addresses";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                landAddresses.Add(new LandAddress(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                    reader.GetString(3)));
            }

            _connection.Close();

            return landAddresses;
        }

        public void DeleteLandAddress(int landAddressesId)
        {
            string query = $"DELETE FROM Land_Addresses WHERE id={landAddressesId}";
            ExecuteQuery(query);
        }

        public void EditLandAddresses(int landAddressesId, int locationTypeId, string branchName, string address)
        {
            StringBuilder query = new StringBuilder();
            query.Append(
                $"UPDATE Land_Addresses SET location_type_id = \"{locationTypeId}\", branch_name= \"{branchName}\", address = \"{address}\"");
            query.Append($"WHERE id = {landAddressesId}");
            ExecuteQuery(query.ToString());
        }

        #endregion

        #region Plantation

        public void CreatePlantation(int landAddressesId, string plantationTypeName, int quantity, string plantingDate)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO Plantation (land_addresses_id, plantation_type_name, quantity, planting_date)");
            query.Append(
                $"VALUES (\"{landAddressesId}\",\"{plantationTypeName}\", \"{quantity}\", \"{plantingDate}\")");
            ExecuteQuery(query.ToString());
        }


        public List<Plantation> GetAllPlantation()
        {
            List<Plantation> plantation = new List<Plantation>();

            string query = "SELECT * FROM Plantation";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                plantation.Add(new Plantation(reader.GetInt32(0), reader.GetInt32(1), 
                    reader.GetString(2), reader.GetInt32(3), 
                    reader.GetString(4)));
            }

            _connection.Close();

            return plantation;
        }

        #endregion


        public void DeletePlantation(int plantationId)
        {
            string query = $"DELETE FROM Plantation WHERE id={plantationId}";
            ExecuteQuery(query);
        }

        public void EditPlantation(int plantationId, int landAddressesId, int plantationTypeId, string name,
            int plantationArea, string plantingDate)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"UPDATE Plantation SET land_addresses_id = \"{landAddressesId}\", plantation_type_id= \"{plantationTypeId}\", name = \"{name}\", plantation_area = \"{plantationArea}\", planting_date = \"{plantingDate}\"");
            query.Append($"WHERE id = {plantationId}");
            ExecuteQuery(query.ToString());
        }

        #region Type_Of_Work

        public void CreateTypeOfWork(string name, int salary)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO Type_Of_Work (name, salary)");
            query.Append($"VALUES (\"{name}\",\"{salary}\")");
            ExecuteQuery(query.ToString());
        }

        public List<TypeOfWork> GetAllTypeOfWork()
        {
            List<TypeOfWork> typeOfWork = new List<TypeOfWork>();

            string query = "SELECT * FROM Type_Of_Work";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                typeOfWork.Add(new TypeOfWork(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
            }

            _connection.Close();

            return typeOfWork;
        }

        public void DeleteTypeOfWork(int typeOfWorkId)
        {
            string query = $"DELETE FROM Type_Of_Work WHERE id={typeOfWorkId}";
            ExecuteQuery(query);
        }

        public void EditTypeOfWork(int typeOfWorkId, string name, int salary)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"UPDATE Type_Of_Work SET name = \"{name}\", salary= \"{salary}\"");
            query.Append($"WHERE id = {typeOfWorkId}");
            ExecuteQuery(query.ToString());
        }

        #endregion

        #region Employees

        public void CreateEmployee(int typeOfWorkId, int landAddressesId, string fullName, string addressOfResidence,
            string phoneNumber)
        {
            StringBuilder query = new StringBuilder();
            query.Append(
                "INSERT INTO Employees (type_of_work_id, land_addresses_id, full_name, address_of_residence, phone_number)");
            query.Append(
                $"VALUES (\"{typeOfWorkId}\",\"{landAddressesId}\",\"{fullName}\", \"{addressOfResidence}\", \"{phoneNumber}\")");
            ExecuteQuery(query.ToString());
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            string query = "SELECT * FROM Employees";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                employees.Add(new Employee(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
                    reader.GetString(3), reader.GetString(4), reader.GetString(5)));
            }

            _connection.Close();

            return employees;
        }

        public void DeleteEmployee(int employeesId)
        {
            string query = $"DELETE FROM Employees WHERE id={employeesId}";
            ExecuteQuery(query);
        }

        public void EditEmployees(int employeesId, int typeOfWorkId, int landAddressesId, string fullName,
            int addressOfResidence, string phoneNumber)
        {
            StringBuilder query = new StringBuilder();
            query.Append(
                $"UPDATE Employees SET type_of_work_id = \"{typeOfWorkId}\", land_addresses_id= \"{landAddressesId}\", full_name = \"{fullName}\", address_of_residence = \"{addressOfResidence}\", phone_number = \"{phoneNumber}\"");
            query.Append($"WHERE id = {employeesId}");
            ExecuteQuery(query.ToString());
        }

        #endregion

        #region Animal_Type

        public void CreateAnimalType(string name)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO Animal_Type (name)");
            query.Append($"VALUES (\"{name}\")");
            ExecuteQuery(query.ToString());
        }

        public List<AnimalType> GetAllAnimalType()
        {
            List<AnimalType> animalType = new List<AnimalType>();

            string query = "SELECT * FROM Animal_Type";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                animalType.Add(new AnimalType(reader.GetInt32(0), reader.GetString(1)));
            }

            _connection.Close();

            return animalType;
        }

        public void DeleteAnimalType(int animalTypeId)
        {
            string query = $"DELETE FROM Animal_Type WHERE id={animalTypeId}";
            ExecuteQuery(query);
        }

        public void EditAnimalType(int animalTypeId, string name)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"UPDATE Animal_Type SET name = \"{name}\"");
            query.Append($"WHERE id = {animalTypeId}");
            ExecuteQuery(query.ToString());
        }

        #endregion

        #region Animals

        public void CreateAnimal(int landAddressesId, int animalTypeId, string gender, int quantity, int consumption)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO Animals (land_addresses_id, animal_type_id, geneder, quantity, consumption)");
            query.Append(
                $"VALUES (\"{landAddressesId}\",\"{animalTypeId}\",\"{gender}\", \"{quantity}\", \"{consumption}\")");
            ExecuteQuery(query.ToString());
        }

        public List<Animal> GetAllAnimals()
        {
            List<Animal> animals = new List<Animal>();

            string query = "SELECT * FROM Animals";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                animals.Add(new Animal(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3),
                    reader.GetInt32(4), reader.GetInt32(5)));
            }

            _connection.Close();

            return animals;
        }

        public void DeleteAnimal(int animalsId)
        {
            string query = $"DELETE FROM Animals WHERE id={animalsId}";
            ExecuteQuery(query);
        }

        public void EditAnimals(int animalsId, int landAddressesId, int animalTypeId, string gender, int quantity,
            int consumption)
        {
            StringBuilder query = new StringBuilder();
            query.Append(
                $"UPDATE Animals SET land_addresses_id = \"{landAddressesId}\", animal_type_id=\"{animalTypeId}\", geneder=\"{gender}\", quantity = \"{quantity}\", consumption = \"{consumption}\"");
            query.Append($"WHERE id = {animalsId}");
            ExecuteQuery(query.ToString());
        }

        #endregion

        #region Export_Addresses

        public void CreateExportAddress(int locationTypeId, string nameCompanies, string address)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO Export_Addresses (location_type_id, name_companies, address)");
            query.Append($"VALUES (\"{locationTypeId}\",\"{nameCompanies}\",\"{address}\")");
            ExecuteQuery(query.ToString());
        }

        public List<ExportAddress> GetAllExportAddresses()
        {
            List<ExportAddress> exportAddresses = new List<ExportAddress>();

            string query = "SELECT * FROM Export_Addresses";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                exportAddresses.Add(new ExportAddress(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                    reader.GetString(3)));
            }

            _connection.Close();

            return exportAddresses;
        }

        public void DeleteExportAddresses(int exportAddressesId)
        {
            string query = $"DELETE FROM Export_Addresses WHERE id={exportAddressesId}";
            ExecuteQuery(query);
        }

        public void EditExportAddresses(int exportAddressesId, int locationTypeId, string nameCompanies, string address)
        {
            StringBuilder query = new StringBuilder();
            query.Append(
                $"UPDATE Export_Addresses SET location_type_id = \"{locationTypeId}\", name_companies= \"{nameCompanies}\", address = \"{address}\"");
            query.Append($"WHERE id = {exportAddressesId}");
            ExecuteQuery(query.ToString());
        }

        #endregion

        #region Export_Type

        public void CreateExportType(string name)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO Export_Type (name)");
            query.Append($"VALUES (\"{name}\")");
            ExecuteQuery(query.ToString());
        }

        public List<ExportType> GetAllExportTypes()
        {
            List<ExportType> exportType = new List<ExportType>();

            string query = "SELECT * FROM Export_Type";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                exportType.Add(new ExportType(reader.GetInt32(0), reader.GetString(1)));
            }

            _connection.Close();

            return exportType;
        }

        public void DeleteExportType(int exportTypeId)
        {
            string query = $"DELETE FROM Export_Type WHERE id={exportTypeId}";
            ExecuteQuery(query);
        }

        public void EditExportType(int exportTypeId, string name)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"UPDATE Export_Type SET name = \"{name}\"");
            query.Append($"WHERE id = {exportTypeId}");
            ExecuteQuery(query.ToString());
        }

        #endregion

        #region Export_Warehouse

        public void CreateExportWarehouse(int exportTypeId, string name, int quantity, int pricePerKilo)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO Export_Warehouse (export_type_id, name, quantity, price_per_kilo)");
            query.Append($"VALUES (\"{exportTypeId}\",\"{name}\",\"{quantity}\", \"{pricePerKilo}\")");
            ExecuteQuery(query.ToString());
        }

        public List<ExportWarehouse> GetAllExportWarehouse()
        {
            List<ExportWarehouse> exportWarehouse = new List<ExportWarehouse>();

            string query = "SELECT * FROM Export_Warehouse";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                exportWarehouse.Add(new ExportWarehouse(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                    reader.GetInt32(3), reader.GetInt32(4)));
            }

            _connection.Close();

            return exportWarehouse;
        }

        public void DeleteExportWarehouse(int exportWarehouseId)
        {
            string query = $"DELETE FROM Export_Warehouse WHERE id={exportWarehouseId}";
            ExecuteQuery(query);
        }

        public void EditExportWarehouse(int exportWarehouseId, int exportTypeId, string name, int quantity,
            int pricePerKilo)
        {
            StringBuilder query = new StringBuilder();
            query.Append(
                $"UPDATE Export_Warehouse SET export_type_id = \"{exportTypeId}\", name = \"{name}\", quantity = \"{quantity}\", price_per_kilo = \"{pricePerKilo}\"");
            query.Append($"WHERE id = {exportWarehouseId}");
            ExecuteQuery(query.ToString());
        }

        #endregion

        #region Export

        public void CreateExport(int exportAddressesId, int exportWarehouseId, int exportTypeId, string name,
            int quantity, int price, string saleDate)
        {
            StringBuilder query = new StringBuilder();
            query.Append(
                "INSERT INTO Export (export_addresses_id, export_warehouse_id, export_type_id, name, quantity, price, sale_date)");
            query.Append(
                $"VALUES (\"{exportAddressesId}\", \"{exportWarehouseId}\", \"{exportTypeId}\", \"{name}\", \"{quantity}\", \"{price}\", \"{saleDate}\")");
            ExecuteQuery(query.ToString());
        }

        public List<Export> GetAllExport()
        {
            List<Export> export = new List<Export>();

            string query = "SELECT * FROM Export";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                export.Add(new Export(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
                    reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7)));
            }

            _connection.Close();

            return export;
        }

        public void DeleteExport(int exportId)
        {
            string query = $"DELETE FROM Export WHERE id={exportId}";
            ExecuteQuery(query);
        }

        public void EditExport(int exportId, int exportAddressesId, int exportWarehouseId, int exportTypeId,
            string name, int quantity, int price, string saleDate)
        {
            StringBuilder query = new StringBuilder();
            query.Append(
                $"UPDATE Export SET export_addresses_id = \"{exportAddressesId}\", export_warehouse_id = \"{exportWarehouseId}\", export_type_id = \"{exportTypeId}\", name = \"{name}\", quantity = \"{quantity}\", price = \"{price}\", sale_date = \"{saleDate}\"");
            query.Append($"WHERE id = {exportId}");
            ExecuteQuery(query.ToString());
        }

        #endregion

        #region Import_Addresses

        public void CreateImportAddress(int locationTypeId, string companyName, string address)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO Import_Addresses (location_type_id, company_name, address)");
            query.Append($"VALUES (\"{locationTypeId}\",\"{companyName}\",\"{address}\")");
            ExecuteQuery(query.ToString());
        }

        public List<ImportAddress> GetAllImportAddresses()
        {
            List<ImportAddress> importAddresses = new List<ImportAddress>();

            string query = "SELECT * FROM Import_Addresses";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                importAddresses.Add(new ImportAddress(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                    reader.GetString(3)));
            }

            _connection.Close();

            return importAddresses;
        }

        public void DeleteImportAddress(int importAddressesId)
        {
            string query = $"DELETE FROM Import_Addresses WHERE id={importAddressesId}";
            ExecuteQuery(query);
        }

        public void EditImportAddresses(int importAddressesId, int locationTypeId, string nameCompanies, string address)
        {
            StringBuilder query = new StringBuilder();
            query.Append(
                $"UPDATE Import_Addresses SET location_type_id = \"{locationTypeId}\", name_companies = \"{nameCompanies}\", address = \"{address}\"");
            query.Append($"WHERE id = {importAddressesId}");
            ExecuteQuery(query.ToString());
        }

        #endregion

        #region Import_Type

        public void CreateImportType(string name)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO Import_Type (name)");
            query.Append($"VALUES (\"{name}\")");
            ExecuteQuery(query.ToString());
        }

        public List<ImportType> GetAllImportType()
        {
            List<ImportType> importType = new List<ImportType>();

            string query = "SELECT * FROM Import_Type";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                importType.Add(new ImportType(reader.GetInt32(0), reader.GetString(1)));
            }

            _connection.Close();

            return importType;
        }

        public void DeleteImportType(int importTypeId)
        {
            string query = $"DELETE FROM Import_Type WHERE id={importTypeId}";
            ExecuteQuery(query);
        }

        public void EditImportType(int importTypeId, string name)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"UPDATE Import_Type SET name = \"{name}\"");
            query.Append($"WHERE id = {importTypeId}");
            ExecuteQuery(query.ToString());
        }

        #endregion

        #region Import

        public void CreateImport(int importAddressesId, int importTypeId, string name, int quantity, int price,
            string importDate)
        {
            StringBuilder query = new StringBuilder();
            query.Append(
                "INSERT INTO Import (import_addresses_id, import_type_id, name, quantity, price, import_date)");
            query.Append(
                $"VALUES (\"{importAddressesId}\", \"{importTypeId}\", \"{name}\", \"{quantity}\", \"{price}\", \"{importDate}\")");
            ExecuteQuery(query.ToString());
        }

        public List<Import> GetAllImport()
        {
            List<Import> import = new List<Import>();

            string query = "SELECT * FROM Import";

            _connection.Open();
            using SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            using SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                import.Add(new Import(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3),
                    reader.GetInt32(4), reader.GetInt32(5), reader.GetString(6)));
            }

            _connection.Close();

            return import;
        }

        public void DeleteImport(int importId)
        {
            string query = $"DELETE FROM Import WHERE id={importId}";
            ExecuteQuery(query);
        }

        public void EditImport(int importId, int importAddressesId, int importTypeId, string name, int quantity,
            int price, string importDate)
        {
            StringBuilder query = new StringBuilder();
            query.Append(
                $"UPDATE Import SET import_addresses_id = \"{importAddressesId}\", import_type_id = \"{importTypeId}\", name = \"{name}\", quantity = \"{quantity}\", price = \"{price}\", import_date = \"{importDate}\"");
            query.Append($"WHERE id = {importId}");
            ExecuteQuery(query.ToString());
        }

        #endregion
    }
}