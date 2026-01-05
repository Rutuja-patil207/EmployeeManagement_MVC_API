using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.Data.SqlClient;



namespace EmployeeManagement.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly DbHelper _dbHelper;

        public EmployeeRepository(DbHelper dbhelper)
        {
            _dbHelper = dbhelper;
        }


        //Get All Employee
        public IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            using (SqlConnection con = _dbHelper.GetConnection())
            {
                string query = "select EmployeeId,EmpName,Email,state,City,Dateofjoin,IsActive from employee";
                SqlCommand cmd=new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                        EmpName = reader["EmpName"].ToString(),
                        Email = reader["Email"].ToString(),
                        state = reader["state"].ToString(),
                        City = reader["City"].ToString(),
                        Dateofjoin = Convert.ToDateTime(reader["Dateofjoin"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"])
                    });
                }
            }
            return employees;
        }

        //Get Employee by Id
        public Employee GetEmployeeById(int id)
        {
            Employee employee = null;
            using (SqlConnection con = _dbHelper.GetConnection())
            {
                string query = "select EmployeeId,EmpName,Email,state,City,Dateofjoin,IsActive from employee where EmployeeId=@Id";
                SqlCommand cmd=new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                SqlDataReader reader=cmd.ExecuteReader();
                if(reader.Read())
                {
                    employee = new Employee
                    {
                        EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                        EmpName = reader["EmpName"].ToString(),
                        Email = reader["Email"].ToString(),
                        state = reader["state"].ToString(),
                        City = reader["City"].ToString(),
                        Dateofjoin = Convert.ToDateTime(reader["Dateofjoin"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"])
                    };
                }
            }
            return employee;
        }

        //Add new Employee
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection con = _dbHelper.GetConnection())
            {
                string query = "insert into Employee(EmpName,Email,state,City,Dateofjoin,IsActive) values(@EmpName,@Email,@state,@City,@Dateofjoin,@IsActive)";
                SqlCommand cmd=new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@state", employee.state);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@Dateofjoin", employee.Dateofjoin);
                cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Update Employee
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = _dbHelper.GetConnection())
            {
                string query = @"update Employee set EmpName=@EmpName,Email=@Email,state=@state,City=@City,Dateofjoin=@Dateofjoin,IsActive=@IsActive where EmployeeId=@Id";
                SqlCommand cmd= new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@state", employee.state);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@Dateofjoin", employee.Dateofjoin);
                cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        //Delete Employee
        public void DeleteEmployee(int id)
        {
            using (SqlConnection con = _dbHelper.GetConnection())
            {
                string query = "DELETE FROM Employee WHERE EmployeeId=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
