using ERP.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP.Domain.AggregatesModel.GenderAggregate
{
    public class Gender
      : Entity, IAggregateRoot
    {
        private string _name;
       

        public Gender(string name)
        {
            _name = name;
        }

    }
}
