using ERP.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Domain.AggregatesModel.DepartmentAggregate;

namespace ERP.Domain.AggregatesModel.PositionAggregate
{
    public class Position
      : Entity, IAggregateRoot
    {
        private string _name;
        public Department Department { get; private set; }
        private int _departmentId;
        private string _isActive;

        public Position(string name)
        {
            _name = name;
        }

        public void SetDepartMentId(int id)
        {
            _departmentId = id;
        }
    }
}
