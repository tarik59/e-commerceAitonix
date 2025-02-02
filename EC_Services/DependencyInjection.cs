﻿using Application.Services;
using EC_Domain.Identity;
using EC_Repository;
using EC_Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EC_Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceContainer
        (this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
