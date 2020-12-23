using System.Collections.Generic;
using System.Linq;
using CompanyStructLib.Interfaces;

namespace CompanyStructLib.Models
{
    public class Director : Employee
    {
        private readonly IList<Manager> _managers;

        public Director(string name, double wage) : base(name, wage)
        {
            Position = Position.Director;
            _managers = new List<Manager>();
        }

        public override void AcceptVisitor(IVisitor visitor)
        {
            visitor.Visit(this, _managers);
        }

        public void AddSubordinate(Manager manager)
        {
            var subordinate = _managers.FirstOrDefault(mng => mng.Id == manager.Id);

            if (subordinate is null)
                _managers.Add(manager);
        }

        public override IEnumerable<Employee> GetSubordinates()
        {
            return base.GetSubordinates().Concat(
                _managers.SelectMany(x => x.GetSubordinates()));
        }
    }
}
