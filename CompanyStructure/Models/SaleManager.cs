﻿using System.Collections.Generic;
using System.Linq;
using CompanyStructLib.Interfaces;

namespace CompanyStructLib.Models
{
    public class SaleManager : Manager
    {
        private readonly IList<SaleWorker> _workers;

        public SaleManager(string name, double wage) : base(name, wage)
        {
            Position = Position.SaleManager;
            _workers = new List<SaleWorker>();
        }

        public override void AcceptVisitor(IVisitor visitor)
        {
            visitor.Visit(this, _workers);
        }

        public void AddSubordinate(SaleWorker worker)
        {
            var subordinate = _workers.FirstOrDefault(wrkr => wrkr.Id == worker.Id);

            if (subordinate is null)
                _workers.Add(worker);
        }

        public override IEnumerable<Employee> GetSubordinates()
        {
            return base.GetSubordinates().Concat(
                _workers.SelectMany(x => x.GetSubordinates()));
        }
    }
}
