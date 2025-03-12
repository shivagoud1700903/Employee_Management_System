using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System
{
     class Program
    {
          static int choice = 0;
                public static void Main(string[] args)
              
              {

            // Configure Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddDbContext<employeedbcontext>(options =>
                    options.UseSqlServer("Your_Connection_String_Here"))
                .BuildServiceProvider();

            var dbContext = serviceProvider.GetService<employeedbcontext>();

            Employee_Functionalities empFunc = new Employee_Functionalities(dbContext);
            Console.WriteLine("===========================");
            Console.WriteLine("EMPLOYEE MANAGEMENT SYSTEM");
            Console.WriteLine("===========================");
            while (true)
            {
                Console.WriteLine(" 1.Add Employee \n 2.Update Employee \n 3.Delete Employee \n 4.Display Employees \n 5.Exit");
                Console.WriteLine("Enter your choice(between 1 to 5)");
                try
                {
                     choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Enter integer values");
                }
                if(choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid choice");
                    Console.WriteLine("Please enter between 1 to 5");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                       empFunc.AddEmployee();
                        break;
                    case 2:
                        empFunc.UpdateEmployee();
                        break;
                    case 3:
                        empFunc.DeleteEmployee();
                        break;
                    case 4:
                        empFunc.DisplayEmployees();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        Console.WriteLine("Please enter between 1 to 5");
                        break;
                }
            }
        }
    }
}
