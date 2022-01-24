using ERP.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Domain.AggregatesModel.GenderAggregate;
using ERP.Domain.AggregatesModel.PositionAggregate;

namespace ERP.Domain.AggregatesModel.EmployeeAggregate
{
    public class Employee
      : Entity, IAggregateRoot
    {
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private DateTime? _dateOfBirth;
        public Nationality Nationality { get; private set; }
        private int _nationalityId;
        public Gender Gender { get; private set; }
        private int _genderId;
        public Position Position { get; private set; }
        private int _positionId;


        public Employee(string firstName, string lastName, string middleName, DateTime? dateOfBirth)
        {
            _firstName = firstName;
            _lastName = lastName;
            _middleName = middleName;
            _dateOfBirth = dateOfBirth;
        }

        public void SetNationalityId(int id)
        {
            _nationalityId = id;
        }

        public void SetGenderId(int id)
        {
            _genderId = id;
        }

        public void SetPositionId(int id)
        {
            _positionId = id;
        }
    }
}
