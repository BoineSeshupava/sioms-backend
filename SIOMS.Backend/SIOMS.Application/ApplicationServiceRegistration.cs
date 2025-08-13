using Microsoft.Extensions.DependencyInjection;
using SIOMS.Application.Interfaces;
using SIOMS.Application.Services;

namespace SIOMS.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
