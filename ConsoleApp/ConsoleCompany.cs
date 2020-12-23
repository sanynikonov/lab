using CompanyStructLib.Implementations;
using CompanyStructLib.Interfaces;
using CompanyStructLib.Models;
using System;

namespace ConsoleApp
{
    public class ConsoleCompany
    {
        private readonly Company company;
        private readonly ConsoleModelCreation model;
        private IVisitor visitor = new SubordinateVisitor();

        public ConsoleCompany(Company company, ConsoleModelCreation consoleModelCreation)
        {
            this.company = company;
            model = consoleModelCreation;
        }
        
        private const string menu = "\n\t1     - Add director and subordinate!" +
    "\n\t2     - Add SaleManager and subordinate!" +
    "\n\t3     - Add DeliveryManager and subordinate" +
    "\n\t4     - Add WorkerA!" +
    "\n\t5     - Add WorkerB!" +
    "\n\t6     - Add WorkerX!" +
    "\n\t7     - Add WorkerY!" +
    "\n\t8     - Add All Employee!" +
    "\n\t9     - GetStructure!" +
    "\n\t10    - Change to DirectHierarchyStrategy" +
    "\n\t11    - Change to PositionalHierarchyStrategy" +
    "\n\t12    - Get Delivery Workers" +
    "\n\t13    - Get Sale Workers" +
    "\n\t14    - Get Big Wage" +
    "\n\t15    - Get Employee by Wage" +
    "\n\t0  - exit\n";

        public void Run()
        {
            Console.WriteLine("Choose action?");
            int answer = -1;

            while (answer != 0)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine(menu);

                answer = GetIntAnswer();

                switch (answer)
                {
                    case 0:
                        Console.WriteLine("Goodbye!");
                        return;
                    case 1:
                        AddDirectorAndSubordinate();
                        break;
                    case 2:
                        AddSaleManagerAndSubordinate();
                        break;
                    case 3:
                        AddDeliveryManagerAndSubordinate();
                        break;
                    case 4:
                        AddWorkerA();
                        break;
                    case 5:
                        AddWorkerB();
                        break;
                    case 6:
                        AddWorkerX();
                        break;
                    case 7:
                        AddWorkerY();
                        break;
                    case 8:
                        AddAllEmployee();
                        break;
                    case 9:
                        GetStructure();
                        break;
                    case 10:
                        ChangeToDirectHierarchyStrategy();
                        break;
                    case 11:
                        ChangeToPositionalHierarchyStrategy();
                        break;
                    case 12:
                        GetDeliveryWorkers();
                        break;
                    case 13:
                        GetSaleWorkers();
                        break;
                    case 14:
                        GetBiggestWage();
                        break;
                    case 15:
                        GetEmployeeByWage();
                        break;
                    default:
                        Console.WriteLine("I don't understand you, Newt");
                        break;
                }
            }
        }

        private void GetEmployeeByWage()
        {
            Console.WriteLine("Please wage need");
            int wage = GetIntAnswer();
            model.GetEmployeeByWage(wage);
        }

        private void GetBiggestWage()
        {
            Console.WriteLine("Get Big Wage");
            model.GetBigWage();
        }

        private void GetSaleWorkers()
        {
            Console.WriteLine("Get Sale Workers");
            model.GetSaleManager();
        }

        private void GetDeliveryWorkers()
        {
            Console.WriteLine("Get Delivery Workers");
            model.GetDeliveryManager();
        }

        private void ChangeToPositionalHierarchyStrategy()
        {
            Console.WriteLine("Change to PositionalHierarchyStrategy!");
            company.SetHierarchyStrategy(new PositionalHierarchyStrategy());
        }

        private void ChangeToDirectHierarchyStrategy()
        {
            Console.WriteLine("Change to DirectHierarchyStrategy!");
            company.SetHierarchyStrategy(new DirectHierarchyStrategy());
        }

        private void GetStructure()
        {
            Console.WriteLine("GetStructure!");
            var result = company.GetStructure();
            foreach (var r in result)
            {
                Console.WriteLine($"{r.Position}\n");
            }
            Console.WriteLine("=======================");
        }

        private void AddAllEmployee()
        {
            Console.WriteLine("Add All Employee!");
            company.SetHierarchyStrategy(new PositionalHierarchyStrategy());
            company.AddEmployee(model.WorkerA);
            company.AddEmployee(model.WorkerB);
            company.AddEmployee(model.SaleManager);
            company.AddEmployee(model.WorkerX);
            company.AddEmployee(model.DeliveryManager);
            company.AddEmployee(model.WorkerY);
            company.AddEmployee(model.Director);
            company.GetByWage(120);
        }

        private void AddWorkerY()
        {
            Console.WriteLine("Add WorkerY!");
            Console.WriteLine(model.GetEmployeeInfo(model.WorkerY));
        }

        private void AddWorkerX()
        {
            Console.WriteLine("Add WorkerX!");
            Console.WriteLine(model.GetEmployeeInfo(model.WorkerX));
        }

        private void AddWorkerB()
        {
            Console.WriteLine("Add WorkerB!");
            Console.WriteLine(model.GetEmployeeInfo(model.WorkerB));
        }

        private void AddWorkerA()
        {
            Console.WriteLine("Add WorkerA!");
            Console.WriteLine(model.GetEmployeeInfo(model.WorkerA));
        }

        private void AddDeliveryManagerAndSubordinate()
        {
            Console.WriteLine("Add DeliveryManager and subordinate!");
            model.AddSubordinateForDeliveryManager(model.DeliveryManager, model.WorkerA);
            model.AddSubordinateForDeliveryManager(model.DeliveryManager, model.WorkerB);
            Console.WriteLine(model.GetEmployeeInfo(model.SaleManager));
        }

        private void AddSaleManagerAndSubordinate()
        {
            Console.WriteLine("Add SaleManager and subordinate!");
            model.AddSubordinateForSaleManager(model.SaleManager, model.WorkerX);
            model.AddSubordinateForSaleManager(model.SaleManager, model.WorkerY);
            Console.WriteLine(model.GetEmployeeInfo(model.SaleManager));
        }

        private void AddDirectorAndSubordinate()
        {
            Console.WriteLine("Add director and subordinate!");
            model.AddSubordinateForDirector(model.Director, model.SaleManager);
            model.AddSubordinateForDirector(model.Director, model.DeliveryManager);
            model.Director.AcceptVisitor(visitor);
            Console.WriteLine(model.GetEmployeeInfo(model.Director));
        }

        private int GetIntAnswer()
        {
            string answer;
            int choice;

            do
            {
                answer = Console.ReadLine();
            }
            while (!int.TryParse(answer, out choice));

            return choice;

        }
    }
}
