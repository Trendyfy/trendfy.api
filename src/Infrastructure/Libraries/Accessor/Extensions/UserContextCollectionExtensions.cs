using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.IO.UserContext.Extensions
{
    public static class UserContextCollectionExtensions
    {
        /// <summary>
        /// Adds a default implementation for the <see cref="IHttpContextAccessor"/> service.
        /// IMPORTANT: To use UserAccessor, HttpContextAccessor have be adds in service (AddHttpContextAccessor)
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddUserContextAccessor<TTenantContextAccessorFactoryResolver>(this IServiceCollection services)
            where TTenantContextAccessorFactoryResolver : IUserContextAccessorFactoryResolver
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped(typeof(IUserContextAccessorFactoryResolver), typeof(TTenantContextAccessorFactoryResolver));
            services.AddScoped<IUserContextAccessor>(provider =>
            {
                var resolver = provider.GetRequiredService<IUserContextAccessorFactoryResolver>();
                return resolver.Create(provider);
            });
            //
            return services;
        }
    }
}