using EmployeeManagement.Models;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();

        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
