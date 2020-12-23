using CompanyStructLib.Interfaces;
using CompanyStructLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace CompanyStructLib.Implementations
{
    public class PositionalHierarchyStrategy : IHierarchyStrategy
    {
        public IEnumerable<Employee> GetHierarchy(IEnumerable<Employee> employees)
        {
            var highestEmployee = employees.OrderBy(emp => emp.Position).FirstOrDefault();

            if (highestEmployee is null)
                return new List<Employee>();

            return highestEmployee.GetSubordinates();

        }
    }
}
