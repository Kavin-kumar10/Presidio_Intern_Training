using RequestTrackerDALLibrary;
using RequestTrackerModalClasses;

namespace RequestTrackerBLLibrary
{
    public class EmployeeBL : IEmployeeService
    {
        IRepository<int,Employee> _employeerepository;

        public EmployeeBL()
        {
            _employeerepository = new EmployeeRepository();
        }
        public int AddEmployee(Employee employee)
        {
            var result = _employeerepository.Add(employee);
            if(result != null)
                return employee.Id;
            throw new DuplicateEmployeeDetailsException();
        }

        public int DeleteEmployee(int Id)
        {
            var result = _employeerepository.Delete(Id);
            if (result != null) return Id;
            throw new NoEmployeeFoundWithId();
        }

        public List<Employee> GetAllEmployee()
        {
            var result = _employeerepository.GetAll();
            if(result!=null)return result;
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(int Id)
        {
            var result = _employeerepository.Get(Id);
            if (result != null) return result;
            throw new NoEmployeeFoundWithId();
        }

        public Employee UpdateEmployeeName(string OldName, string NewName)
        {
            List<Employee> AllEmployee = _employeerepository.GetAll();
            if (AllEmployee != null)
            {
                for (int i = 0; i < AllEmployee.Count; i++)
                {
                    if (AllEmployee[i].Name == OldName)
                    {
                        AllEmployee[i].Name = NewName;
                        return AllEmployee[i];
                    }
                }
            }
            throw new NotImplementedException();
        }
    }
}
