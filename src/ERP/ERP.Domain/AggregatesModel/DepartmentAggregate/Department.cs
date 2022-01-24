using ERP.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP.Domain.AggregatesModel.DepartmentAggregate
{
    public class Department
      : Entity, IAggregateRoot
    {
        private string _name;
        public Department Parent { get; private set; }
        private int? _parentId;
        private string _isActive;

        public Department(string name)
        {
            _name = name;
        }
        public void SetParentId(int id)
        {
            _parentId = id;
        }
    }
}
