﻿using System;
using System.Collections.Generic;

namespace ERP.API.Application.Queries
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }

}
