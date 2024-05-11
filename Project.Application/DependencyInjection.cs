
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Mapper;
namespace Project.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(
                        typeof(ProductSizeMappingProfile),
                        typeof(RetaileMappingProfile),
                        typeof(CompanyMappingProfile),
                        typeof(DeliveryAddressMappingProfile),
                        typeof(OrderMappingProfile),
                        typeof(ProdReturnMappingProfile),
                        typeof(ProductMappingProfile),
                        typeof(StockMappingProfile),
                        typeof(TraderMappingProfile),
                        typeof(ValveMappingProfile)
                        );
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(assembly));

            //object value = services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
