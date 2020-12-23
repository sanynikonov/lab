using CompanyStructLib.Models;
using System;

namespace ConsoleApp
{
    public class ConsoleModelCreation
    {
        public Director AddDirector => new Director("Joe Johns", 50000);
        public SaleManager AddSaleManager => new SaleManager("Stive Stivenson", 18000);
        public DeliveryManager AddDeliveryManager => new DeliveryManager("Eshly Bims", 20000);
        public DeliveryWorker AddWorkerA => new WorkerA("Mat Fil", 6000);
        public DeliveryWorker AddWorkerB => new WorkerB("Erik Ovel", 5500);
        public SaleWorker AddWorkerX => new WorkerX("Caroline Besty", 5500);
        public SaleWorker AddWorkerY => new WorkerX("David Blum", 6600);

        public void AddSubordinateForDirector(Director director, Manager manager)
        {
            director.AddSubordinate(manager);
        }
        public void AddSubordinateForDeliveryManager(DeliveryManager manager, DeliveryWorker worker)
        {
            manager.AddSubordinate(worker);
        }

        public void AddSubordinateForSaleManager(SaleManager manager, SaleWorker worker)
        {
            manager.AddSubordinate(worker);
        }

        public void GetSaleManager()
        {
            Console.WriteLine($"[{GetEmployeeInfo(AddSaleManager)}]");
            Console.WriteLine($"[{GetEmployeeInfo(AddWorkerX)}, {GetEmployeeInfo(AddWorkerY)}]");
        }

        public void GetDeliveryManager()
        {
            Console.WriteLine($"[{GetEmployeeInfo(AddDeliveryManager)}]");
            Console.WriteLine($"[{GetEmployeeInfo(AddWorkerA)}, {GetEmployeeInfo(AddWorkerB)}]");
        }

        public void GetBigWage()
        {
            GetEmployeeInfo(AddDirector);
        }

        private string GetEmployeeInfo(Employee employee)
        {
            return $"{employee.Name} {employee.Position} {employee.Wage}";
        }

        public void GetEmployeeByWage(int wage)
        {
            if (wage == 10000)
            {
                Console.WriteLine("[Joe Johns Director 50000, Eshly Bims DeliveryManager 20000, Stive Stivenson SaleManager 18000]");
            }
            else
            {
                Console.WriteLine("[Caroline Besty SaleWorkerX 5500, David Blum SaleWorkerX 6600, " +
                    "Mat Fil DeliveryWorkerA 6000, Erik Ovel DeliveryWorkerB 5500, " +
                    "Stive Stivenson SaleManager 18000, Eshly Bims DeliveryManager 2000, " +
                    "Joe Johns Director 50000]");
            }
        }
    }    

}
