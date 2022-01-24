using Autofac;
using ERP.BuildingBlocks.EventBus.Abstractions;
using ERP.API.Application.Commands;
using ERP.API.Application.Queries;
using ERP.Infrastructure.Idempotency;
using ERP.Infrastructure.Repositories;
using System.Reflection;
using ERP.Domain.AggregatesModel.EmployeeAggregate;
using ERP.Domain.AggregatesModel.DepartmentAggregate;
using ERP.Domain.AggregatesModel.PositionAggregate;
using ERP.Domain.AggregatesModel.GenderAggregate;

namespace ERP.API.Infrastructure.AutofacModules
{

    public class ApplicationModule
        :Autofac.Module
    {

        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {
            //queries
            builder.Register(c => new EmployeeQueries(QueriesConnectionString))
                .As<IEmployeeQueries>()
                .InstancePerLifetimeScope();

            builder.Register(c => new NationalityQueries(QueriesConnectionString))
                .As<INationalityQueries>()
                .InstancePerLifetimeScope();

            builder.Register(c => new DepartmentQueries(QueriesConnectionString))
                .As<IDepartmentQueries>()
                .InstancePerLifetimeScope();

            builder.Register(c => new PositionQueries(QueriesConnectionString))
                .As<IPositionQueries>()
                .InstancePerLifetimeScope();

            builder.Register(c => new GenderQueries(QueriesConnectionString))
                .As<IGenderQueries>()
                .InstancePerLifetimeScope();

            //repositories
            builder.RegisterType<EmployeeRepository>()
                .As<IEmployeeRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<NationalityRepository>()
                .As<INationalityRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DepartmentRepository>()
                .As<IDepartmentRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PositionRepository>()
                .As<IPositionRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GenderRepository>()
                .As<IGenderRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RequestManager>()
               .As<IRequestManager>()
               .InstancePerLifetimeScope();

            //commands
            builder.RegisterAssemblyTypes(typeof(CreateEmployeeCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

            builder.RegisterAssemblyTypes(typeof(CreateNationalityCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

            builder.RegisterAssemblyTypes(typeof(CreateDepartmentCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

            builder.RegisterAssemblyTypes(typeof(CreatePositionCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

            builder.RegisterAssemblyTypes(typeof(CreateGenderCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));



        }
    }
}
