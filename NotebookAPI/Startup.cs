using NotebookAPI.Interfaces;
using NotebookAPI.Data;
using NotebookAPI.Model;
using Microsoft.OpenApi.Models;

namespace NotebookAPI
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<Settings>(options =>
      {
        options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
        options.Database = Configuration.GetSection("MongoConnection:Database").Value;
      });

      services.AddControllers();

      services.AddTransient<INoteRepository, NoteRepository>();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo() { Title = "NotebookAPI", Version = "v1" });
      });

      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseCors("CorsPolicy");
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notebook API v1");
      });

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }
      //app.UseAuthentication();
      app.UseRouting();
      //app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}