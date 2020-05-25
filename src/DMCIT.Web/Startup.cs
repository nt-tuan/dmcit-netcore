using Autofac;
using Autofac.Extensions.DependencyInjection;
using DMCIT.Core.Entities.Core;
using DMCIT.Core.Interfaces;
using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Data;
using DMCIT.Infrastructure.Data.Workflow;
using DMCIT.Infrastructure.Services;
using DMCIT.Web.Configurations;
using DMCIT.Web.Hubs;
using DMCIT.Web.Hubs.WorkflowHub;
using DMCIT.Web.Middleware;
using DMCIT.Web.Services;
using Hangfire;
using Hangfire.SqlServer;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DMCIT.Web
{
    public class Startup
    {
        const string PROCESS_HUB_PATH = "/processHub";
        const string WORKFLOW_HUB_PATH = "/workflowHub";

        public Startup(IConfiguration config, IHostingEnvironment env)
        {
            Configuration = config;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        private IHostingEnvironment Env { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var physicalProivder = Env.ContentRootFileProvider;
            services.AddSingleton(physicalProivder);

            // Api setting
            ConfigSettings(services);

            // TODO: Add DbContext and IOC
            ConfigDatabase(services);
            ConfigIdentity(services);
            ConfigSPA(services);
            // Add SignalR
            ConfigSignalR(services);
            // Add Hangfire
            ConfigHangfire(services);
            // Api
            ConfigAPI(services);
            // Jwt token
            ConfigJwtToken(services);
            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            return BuildDependencyInjectionProvider(services);
        }

        public void ConfigIdentity(IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                //Password setting
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;

                //Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;

                //User settings
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";
                options.User.RequireUniqueEmail = true;
            });

            services.AddScoped<SignInManager<AppUser>, SignInManager<AppUser>>();
        }

        public void ConfigJwtToken(IServiceCollection services)
        {
            var key = ApiConfiguration.GetJWTSecretKey();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ClockSkew = TimeSpan.Zero
                    };
                    cfg.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments(PROCESS_HUB_PATH))
                            {
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
        }
        private void ConfigSPA(IServiceCollection services)
        {
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }
        private void ConfigSettings(IServiceCollection services)
        {
            var appConfig = new ApiConfiguration();
            Configuration.Bind("ApiConfiguration", appConfig);
            services.Configure<ApiConfiguration>(Configuration.GetSection("ApiConfiguration"));
        }
        private void ConfigHangfire(IServiceCollection services)
        {
            services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)

    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        UsePageLocksOnDequeue = true,
        DisableGlobalLocks = true
    }));

            // Add the processing server as IHostedService
            services.AddHangfireServer();
        }
        private void ConfigSignalR(IServiceCollection services)
        {
            //Add SignalR
            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
                hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(10);
            }).AddJsonProtocol(options =>
            {
                options.PayloadSerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            });
        }
        private void ConfigDatabase(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x =>
            {
                x.MigrationsAssembly("DMCIT.Infrastructure");
                x.CommandTimeout(300);
            }));
        }
        private void ConfigAPI(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                })
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<ApiBehaviorOptions>(o =>
            {
                o.SuppressModelStateInvalidFilter = true;
            });
        }
        private static IServiceProvider BuildDependencyInjectionProvider(IServiceCollection services)
        {
            Assembly webAssembly = Assembly.GetExecutingAssembly();
            Assembly coreAssembly = Assembly.GetAssembly(typeof(Base));
            Assembly infrastructureAssembly = Assembly.GetAssembly(typeof(EfRepository));
            services.AddMediatR(webAssembly, coreAssembly, infrastructureAssembly);
            var builder = new ContainerBuilder();

            // Populate the container using the service collection
            builder.Populate(services);

            // TODO: Add Registry Classes to eliminate reference to Infrastructure

            // TODO: Move to Infrastucture Registry
            builder.RegisterAssemblyTypes(webAssembly, coreAssembly, infrastructureAssembly)
                .Where(u => u.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(webAssembly, coreAssembly, infrastructureAssembly)
                .Where(u => u.Name.EndsWith("Dispatcher"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(webAssembly, coreAssembly, infrastructureAssembly)
                .Where(u => u.Name.EndsWith("Service"))
                .Except<IProcessManagerService>()
                .AsImplementedInterfaces();
            //builder.RegisterType<AppDbContext>().AsImplementedInterfaces();
            builder.RegisterType<SettingRepository>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<ProgressManagerService>().As<IProcessManagerService>().SingleInstance();
            builder.RegisterType<WorkflowStorage>().SingleInstance();
            IContainer applicationContainer = builder.Build();
            return new AutofacServiceProvider(applicationContainer);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                //app.UseExceptionHandler("/Home/Error");
                //app.UseHsts();
                //app.UseDeveloperExceptionPage();
                app.UseMiddleware<MyExceptionMiddleware>();
            }
            else
            {
                app.UseMiddleware<MyExceptionMiddleware>();
            }

            app.UseAuthentication();

            //config.TemplateRoot = env.WebRootPath;

            app.UseMvc();
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "AppData")),
                RequestPath = "/AppData"
            });

            app.UseCookiePolicy();
            app.UseSpaStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseSignalR((configure) =>
            {
                var desiredTransports =
                    HttpTransportType.WebSockets |
                    HttpTransportType.LongPolling;

                configure.MapHub<ProcessHub>(PROCESS_HUB_PATH, (options) =>
                {
                    options.Transports = desiredTransports;
                });
                configure.MapHub<WorkflowHub>(WORKFLOW_HUB_PATH, (options) =>
                {
                    options.Transports = desiredTransports;
                });
            });

            //var scopeFactory = serviceProvider.GetService<IServiceScopeFactory>();

            //if(scopeFactory != null)
            //    GlobalConfiguration.Configuration.UseActivator(new AspNetCoreJobActivator(scopeFactory));
            app.UseHangfireServer();
            app.UseHangfireDashboard();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //spa.UseReactDevelopmentServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
                }
                else
                {

                }
            });
        }
    }
}
