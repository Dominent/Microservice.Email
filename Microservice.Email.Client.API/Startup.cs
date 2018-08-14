namespace Microservice.Email.Client.API
{
    using Microservice.Email.Client.API.Contracts;
    using Microservice.Email.Client.API.Controllers;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Email Microservice",
                    Description = "Microservice used to send plain text and HTML emails",
                    Contact = new Contact()
                    {
                        Name = "Petromil Pavlov",
                        Email = "petromilpavlov@gmail.com",
                        Url = "https://ppavlov.net/"
                    }
                });
            });

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IEmailService>(new GmailService(Configuration));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(
                "/swagger/v1/swagger.json",
                "Email Microservice V1"));
        }
    }
}
