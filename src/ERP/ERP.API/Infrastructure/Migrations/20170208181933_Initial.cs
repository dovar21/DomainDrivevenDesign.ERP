using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ERP.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Employees",
               schema: "dbo",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   FirstName = table.Column<string>(maxLength: 200, nullable: false),
                   MiddleName = table.Column<string>(maxLength: 200, nullable: true),
                   LastName = table.Column<string>(maxLength: 200, nullable: false),
                   DateOfBirth = table.Column<DateTime?>(maxLength: 200, nullable: true),
                   NationalityId = table.Column<int>(nullable: false),
                   GenderId = table.Column<int>(nullable: false),
                   PositionId = table.Column<int>(nullable: false),
                   IsEnabled = table.Column<bool>(nullable: false),
                   CreatedOn = table.Column<DateTime>(nullable: false),
                   DeletedOn = table.Column<DateTime?>(nullable: true),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_employees", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "Nationalities",
               schema: "dbo",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   Name = table.Column<string>(maxLength: 200, nullable: false),
                   IsEnabled = table.Column<bool>(nullable: false),
                   CreatedOn = table.Column<DateTime>(nullable: false),
                   DeletedOn = table.Column<DateTime?>(nullable: true),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_nationalities", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "Departments",
               schema: "dbo",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   Name = table.Column<string>(maxLength: 200, nullable: false),
                   ParentId = table.Column<int?>(maxLength: 200, nullable: true),
                   IsActive = table.Column<bool>(nullable: false),
                   IsEnabled = table.Column<bool>(nullable: false),
                   CreatedOn = table.Column<DateTime>(nullable: false),
                   DeletedOn = table.Column<DateTime?>(nullable: true),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_departments", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "Positions",
               schema: "dbo",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   Name = table.Column<string>(maxLength: 200, nullable: false),
                   IsActive = table.Column<bool>(nullable: false),
                   IsEnabled = table.Column<bool>(nullable: false),
                   CreatedOn = table.Column<DateTime>(nullable: false),
                   DeletedOn = table.Column<DateTime?>(nullable: true),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_positions", x => x.Id);
               });

            migrationBuilder.CreateTable(
              name: "Genders",
              schema: "dbo",
              columns: table => new
              {
                  Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                  Name = table.Column<string>(maxLength: 200, nullable: false),
                  IsEnabled = table.Column<bool>(nullable: false),
                  CreatedOn = table.Column<DateTime>(nullable: false),
                  DeletedOn = table.Column<DateTime?>(nullable: true),
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_genders", x => x.Id);
              });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
