using System;
using MediatR;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections;
using ERP.API.Application.Models;
using System.Linq;

namespace ERP.API.Application.Commands
{
    [DataContract]
    public class CreateEmployeeCommand
        : IRequest<bool>
    {

        [DataMember]
        public string FirstName { get; private set; }

        [DataMember]
        public string MiddleName { get; private set; }

        [DataMember]
        public string LastName { get; private set; }

        [DataMember]
        public DateTime? DateOfBirth { get; private set; }


        [DataMember]
        public int NationalityId { get; private set; }

        public CreateEmployeeCommand()
        {
            
        }

        public CreateEmployeeCommand(string firstName, string middleName, string lastName, int nationalityId, DateTime? dateOfBirth)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            NationalityId = NationalityId;
            DateOfBirth = dateOfBirth;
        }
    }
}
