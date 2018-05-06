using JCSoft.SSA.Tools.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class HttpHelperServiceCollectionExtensions
    {
        public static void AddHttpHelper(this IServiceCollection services)
        {
            services.AddSingleton<IHttpHelper, HttpHelper>();
        }
    }
}
