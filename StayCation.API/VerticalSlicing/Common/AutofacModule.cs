using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.MapperProfile;
using StayCation.API.VerticalSlicing.Data;
using StayCation.API.VerticalSlicing.Data.Data;
using StayCation.API.VerticalSlicing.Data.Repositories;
using System.Diagnostics;

namespace StayCation.API.VerticalSlicing.Common
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.Register(c =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<Context>();
                var configuration = c.Resolve<IConfiguration>();
                var userState = c.Resolve<UserState>();

                var interceptor = new MyCustomInterceptor(userState);

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                              .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                              .EnableSensitiveDataLogging().AddInterceptors(interceptor);

                return new Context(optionsBuilder.Options);
            }).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<AdminProfile>();
                cfg.AddProfile<CategoryProfile>();
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();


            builder.RegisterType<UserState>().InstancePerLifetimeScope();

            builder.RegisterType<ControllereParameters>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(RequestParameters<>)).InstancePerLifetimeScope();
        }
    }
}
