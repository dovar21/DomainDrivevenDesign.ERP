using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ERP.Infrastructure;

namespace ERP.API.Migrations
{
    [DbContext(typeof(ERPContext))]
    [Migration("20170208181933_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
           
        }
    }
}
