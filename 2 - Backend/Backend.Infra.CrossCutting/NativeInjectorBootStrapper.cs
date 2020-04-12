﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infra.CrossCutting
{
  public class NativeInjectorBootStrapper
  {
    public static void RegisterServices(IServiceCollection services)
    {
      // ASP.NET HttpContext dependency
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
  }
}
