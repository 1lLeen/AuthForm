using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Application.Mapping
{
    public static class MappingRegistration
    {
        public static void RegistrationMapp(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingRegistration));
        }
    }
}
