using EmployeeManagement.Models;
using EmployeeManagement.Repository;

namespace EmployeeManagement.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //GetallEmployee
        public IEnumerable<Employee> GetAllActiveEmployees()
        {
               return _employeeRepository.GetEmployees().Where(e=>e.IsActive);
        }
        //GetAllemployeebyid
        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }
        //AddEmployee
        public bool AddEmployee(Employee employee)
        {
            var existingEmployees = _employeeRepository.GetEmployees();

            bool emailExists=existingEmployees.Any(e=>e.Email.ToLower()==employee.Email.ToLower());

            if(emailExists)
            {
                return false;
            }
            _employeeRepository.AddEmployee(employee);
            return true;


        }
        //updateEmployee
        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
        }
        //DeleteEmployee
        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }

    }
}
