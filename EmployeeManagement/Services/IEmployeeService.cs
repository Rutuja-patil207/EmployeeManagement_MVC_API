using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllActiveEmployees();
        Employee GetEmployeeById(int id);
        bool AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
