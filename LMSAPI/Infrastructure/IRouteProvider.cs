using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSAPI
{
    public interface IRouteProvider
    {
        void RegisterRoutes(IRouteBuilder routeBuilder);

        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        int Priority { get; }
    }
}
