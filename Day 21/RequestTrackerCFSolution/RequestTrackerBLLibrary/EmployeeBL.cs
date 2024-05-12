using RequestTrackerCFModals;
using RequestTrackerDALibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IRepository<int, Employee> _repository;

        public EmployeeBL() {
            _repository = new EmployeeRepository(new RequestTrackerContext());
        }

        public Task<Employee> AddEmployee(Employee employee)
        {
            var result = _repository.Add(employee);
            return result;
            throw new NotImplementedException();
        }

        public Task<Employee> DeleteEmployee(int id)
        {
            var result = _repository.Delete(id);
            throw new NotImplementedException();
        }

        public async Task<IList<Employee>> GetAllEmployees()
        {
            var result = await _repository.GetAll();
            return result;
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployee(int id)
        {
            var result = _repository.Get(id);   
            return result;
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = _repository.Update(employee);  
            return result;
            throw new NotImplementedException();
        }

    }
}
