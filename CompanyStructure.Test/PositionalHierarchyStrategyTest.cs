using CompanyStructLib.Implementations;
using CompanyStructLib.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CompanyStructLib.Tests
{
    public class PositionalHierarchyStrategyTest
    {
        [Fact]
        public void GetHierarchy_Employyes_OrderedListByPosition()
        {
            //Arrange
            var strategy = new PositionalHierarchyStrategy();

            var director = new Director("Director", 20000);
            var workerY = new WorkerY("WorkerY", 5500);
            var saleManager = new SaleManager("SaleManager", 10400);
            var deliveryManager = new DeliveryManager("DeliveryManager", 10400);

            var expectedPositionsOrder = new[]
            {
                Position.Director,
                Position.SaleManager,
                Position.SaleWorkerY,
                Position.DeliveryManager
            };

            director.AddSubordinate(saleManager);
            director.AddSubordinate(deliveryManager);
            saleManager.AddSubordinate(workerY);

            var employees = new List<Employee> { director, workerY, saleManager };

            //Act
            var actual = strategy.GetHierarchy(employees).Select(e => e.Position);

            //Assert
            Assert.Equal(expectedPositionsOrder, actual);}
    }
}
