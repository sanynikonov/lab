using CompanyStructLib.Interfaces;
using System;
using System.Collections.Generic;
using CompanyStructure.Exceptions;

namespace CompanyStructLib.Models
{
    public enum Position
    {
        Director,
        DeliveryManager,
        SaleManager,
        DeliveryWorkerA,
        DeliveryWorkerB,
        SaleWorkerX,
        SaleWorkerY,
    }

    public abstract class Employee
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public double Wage { get; protected set; }

        public Position Position { get; protected set; }

        public Employee(string name, double wage)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidNameException("Parameter 'name' cannot be null or blank.");

            if (wage < 0)
                throw new NonPositiveWageException($"Parameter 'wage' cannot be less than zero.\nYour input: {wage}");

            Id = Guid.NewGuid();
            Name = name;
            Wage = wage;
        }

        public virtual IEnumerable<Employee> GetSubordinates()
        {
            return new List<Employee> { this };
        }

        public abstract void AcceptVisitor(IVisitor visitor);
    }
}
