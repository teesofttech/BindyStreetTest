using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using BindyStreet.Shared.Interfaces;
using BindyStreet.Shared;
using MediatR;
using BindyStreet.Application.Repositories;
using BindyStreet.Application.Specifications;

namespace BindyStreet.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {

        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IResult<>), typeof(Result<>));
            services.AddScoped(typeof(ISpecifications<>), typeof(BaseSpecification<>));
            return services;
        }

    }
}
