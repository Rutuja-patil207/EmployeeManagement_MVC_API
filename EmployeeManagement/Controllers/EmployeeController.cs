using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;


        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }
        //Get Employee
        public IActionResult Index()
        {
            try
            {
                var employees = _employeeService.GetAllActiveEmployees();
                return View(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading employee list");
                return View("Error");

            }
        }

        //Get Action
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(employee);
                }

                var result = _employeeService.AddEmployee(employee);

                if (!result)
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View(employee);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding employee");
                return View("Error");
            }
        }

        //Update
        public IActionResult Edit(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading employee for edit");
                return View("Error");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(employee);
                }

                _employeeService.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating employee");
                return View("Error");
            }
        }


        //Details
        public IActionResult Details(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return View(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading employee details");
                return View("Error");
            }
        }

        //delete
        public IActionResult Delete(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return View(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading delete page");
                return View("Error");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee employee)
        {
            try
            {
                _employeeService.DeleteEmployee(employee.EmployeeId);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting employee");
                return View("Error");
            }
        }

        public IActionResult ApiEmployeeList()
        {
            return View();
        }


    }
}
