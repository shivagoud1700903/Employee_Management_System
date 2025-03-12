using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Employee_Management_System
{
    public class Employee_Functionalities
    {

        private readonly employeedbcontext _context;

        // Constructor to inject database context
        public Employee_Functionalities(employeedbcontext context)
        {
            _context = context;
        }

     //   public List<Employee> employees = new List<Employee>();
        public void AddEmployee()
        {
            Employee emp = new Employee();
            while (true)
            {
                Console.WriteLine("Enter Employee Id");
                if (int.TryParse(Console.ReadLine(), out int id)) 
                {
                    if (_context.Employees.Any(e => e.Id == id))
                    {
                        Console.WriteLine("Employee Id already exists");
                    }
                    else
                    {
                        emp.Id = id;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Employee Id should be a number");
                }
            }       
            
            while (true)
            {
                Console.WriteLine("Enter Employee Name");
                emp.Name = Console.ReadLine();
                if (!(int.TryParse(emp.Name, out int result)))
                {
                    if(emp.Name == null || emp.Name == "")
                    {
                        Console.WriteLine("Employee name should not be empty");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Employee name should not be a number");
                }
            }
            while (true)
            {
                Console.WriteLine("Enter Employee Age");
                emp.Age = Convert.ToInt32(Console.ReadLine());
                if (emp.Age < 18 || emp.Age >= 100)
                {
                    Console.WriteLine("Employee age should be greater than 18 and less than 100");
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Enter Employee Department");
                emp.Department = Console.ReadLine();
                if (int.TryParse(emp.Department, out int result))
                {
                    Console.WriteLine("Employee department should not be a number");
                }
                else
                if (emp.Department == null || emp.Department == "")
                {
                    Console.WriteLine("Employee department should not be empty");
                }
                else
                { 
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Enter Employee Salary");
               // emp.salary = Convert.ToDouble(Console.ReadLine());
                
                if(double.TryParse(Console.ReadLine(),out double result))
                if (emp.Salary < 0)
                {
                    Console.WriteLine("Employee Salary should be greater than 0");
                }
                    else
                    {
                        emp.Salary = result;
                        break;
                    }
                else
                {
                    Console.WriteLine("enter valid numbers");
                }
            }
            _context.Employees.Add(emp);
            _context.SaveChanges();
        }



        public void UpdateEmployee()
        {
            Console.WriteLine("Enter Employee Id to update");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee emp = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                Console.WriteLine("Enter Employee Name");
                emp.Name = Console.ReadLine();
                Console.WriteLine("Enter Employee Age");
                emp.Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee Department");
                emp.Department = Console.ReadLine();
                Console.WriteLine("Enter Employee Salary");
                emp.Salary = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }

        public void DeleteEmployee()
        {
            Console.WriteLine("Enter Employee Id to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee emp = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                Console.WriteLine("Employee deleted successfully");
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }

        public void DisplayEmployees()
        {
            var employees = _context.Employees.ToList();

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees to display");
                return;
            }
            else {
                Console.WriteLine("Employeee Id \t   Employee Name \t Employee Age \t Employee Department \t Employee Salary");
                foreach (var emp in employees)
                {
                    Console.WriteLine($"{emp.Id} \t\t  {emp.Name} \t\t {emp.Age} \t\t  {emp.Department} \t\t {emp.Salary.ToString("C")}$");
                }
            }
        }
        
    
   
}

}
