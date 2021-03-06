﻿using System;
using Microsoft.Extensions.DependencyInjection;

namespace Docs.Extensions
{
    /// <summary>
    /// ServiceCollectionExtensions
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add Docs
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddDocs(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddTransient<IDocumentationService, DocumentationService>();
            services.AddTransient<IAssemblyScanner, AssemblyScanner>();
            services.AddTransient<IConverter, Converter>();

            return services;
        }
    }
}
