using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaOrganizer.Data;
using MediaOrganizer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace MediaOrganizer.WebAPI
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      var connectionString = Configuration.GetConnectionString("DefaultConnection");
      services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

      // use this if adding User Auth
      // also install package Microsoft.AspNetCore.Http.Abstractions
      // services.AddHttpContextAccessor();

      // Solving the DI with multiple concrete implementations issue (IService -> Service*3)
      // set multiple concrete registrations
      services.AddScoped<MediaObjectService>();
      services.AddScoped<MediaTypeService>();
      services.AddScoped<MediaCatalogService>();
      // manual mapping of the above types
      services.AddTransient<ServiceResolver>(serviceProvider => key =>
      {
        switch (key)
        {
          case nameof(MediaObjectService):
            return serviceProvider.GetService<MediaObjectService>();
          case nameof(MediaTypeService):
            return serviceProvider.GetService<MediaTypeService>();
          case nameof(MediaCatalogService):
            return serviceProvider.GetService<MediaCatalogService>();
          default:
            throw new KeyNotFoundException();
        }
      });

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "MediaOrganizer.WebAPI", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MediaOrganizer.WebAPI v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
