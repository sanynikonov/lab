using CompanyStructLib.Interfaces;
using CompanyStructLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace CompanyStructLib.Implementations
{
    public class SubordinateVisitor : IVisitor
    {
        public List<Employee> Subordinates { get; private set; } = new List<Employee>();

        public void Visit(Director director, IEnumerable<Employee> subordinates)
        {
            GetSubordinates(subordinates);
        }

        public void Visit(SaleManager saleManager, IEnumerable<Employee> subordinates)
        {
            GetSubordinates(subordinates);
        }

        public void Visit(DeliveryManager deliveryManager, IEnumerable<Employee> subordinates)
        {
            GetSubordinates(subordinates);
        }

        public void Visit(WorkerA workerA)
        {
            ClearSubordinates();
        }

        public void Visit(WorkerB workerB)
        {
            ClearSubordinates();
        }

        public void Visit(WorkerX workerX)
        {
            ClearSubordinates();
        }

        public void Visit(WorkerY workerY)
        {
            ClearSubordinates();
        }

        private void ClearSubordinates()
        {
            Subordinates.Clear();
        }

        private void GetSubordinates(IEnumerable<Employee> subordinates)
        {
            Subordinates = subordinates.ToList();
        }
    }
}
