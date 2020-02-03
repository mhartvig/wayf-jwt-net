using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace WayfJwtConector
{
       public class WayfBuilder
    {
        public virtual IServiceCollection Services { get; }
        public WayfBuilder(IServiceCollection services) => Services = services;
    }
}
