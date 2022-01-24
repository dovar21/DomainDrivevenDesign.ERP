using ERP.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP.Domain.AggregatesModel.EmployeeAggregate
{
    public class Nationality
      : Entity, IAggregateRoot
    {
        private string _name;
       

        public Nationality(string name)
        {
            _name = name;
        }

    }
}
