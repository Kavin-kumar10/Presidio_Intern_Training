using RequestTrackerCFModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeBL
    {
        public Task<IList<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployee(int id);
        public Task<Employee> AddEmployee(Employee employee);
        public Task<Employee> DeleteEmployee(int id);
        public Task<Employee> UpdateEmployee(Employee employee);
    }
}
