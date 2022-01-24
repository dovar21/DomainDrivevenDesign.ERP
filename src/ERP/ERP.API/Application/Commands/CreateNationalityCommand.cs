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
    public class CreateNationalityCommand
        : IRequest<bool>
    {

        [DataMember]
        public string Name { get; private set; }

        public CreateNationalityCommand()
        {
            
        }

        public CreateNationalityCommand(string name)
        {
            Name = name;
        }
    }
}
