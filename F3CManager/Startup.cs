using System.Globalization;
using System.Xml.XPath;
using DataAccess;
using F3CManager.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace F3CManager
{
    /// <summary>
    /// Startup configuration.
    /// </summary>
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private IWebHostEnvironment? WebHostEnvironment { get; set; }
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEventServices, EventServices>();

            ConfigureAuthentication(services);

            services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
                //options.EnableEndpointRouting = false;
            });
            
            services.AddRazorPages()
                .AddNewtonsoftJson(setupAction =>
                {
                    setupAction.SerializerSettings.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ssK";
                });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "Frontend/build";
            });

            services.AddHttpClient();
            //services.AddCustomHttpContextAccessor();

            ConfigureDatabaseServices(services);

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement{
                {
                    new OpenApiSecurityScheme{
                        Reference = new OpenApiReference{
                            Id = "Bearer", //The name of the previously defined security scheme.
                            Type = ReferenceType.SecurityScheme
                        }
                    },new List<string>()
                }
                });
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "F3C Manager API",
                        Description = "This is the API documentation for the F3C Manager",
                        Version = "1.0.0"
                    });
                options.IncludeXmlComments($"{System.AppDomain.CurrentDomain.BaseDirectory}F3CManager.xml");

                //This is run after Configure() so 'WebHostEnvironment' is set at this point.
                var xmlDocFile = Path.Combine(AppContext.BaseDirectory, $"{(WebHostEnvironment != null ? WebHostEnvironment.ApplicationName : "F3CManager")}.xml");
                if (File.Exists(xmlDocFile))
                {
                    var comments = new XPathDocument(xmlDocFile);
                    options.OperationFilter<XmlCommentsOperationFilter>(comments);
                }
            });
        }

        /// <summary>
        /// This is virtual so we can inject custom authentication in tests.
        /// </summary>
        /// <param name="services"></param>
        protected virtual void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwtOptions =>
            {
                //jwtOptions.Authority = $"{Configuration["AzureAd:B2C:BaseUri"]}tfp/{Configuration["AzureAd:Tenant"]}/{Configuration["AzureAd:B2C:Policy"]}/v2.0/";
                //jwtOptions.Audience = Configuration["AzureAd:B2C:ClientId"];
                //jwtOptions.TokenValidationParameters = JwtUtil.GetTokenValidationParameters(Configuration);
                jwtOptions.Events = new JwtBearerEvents
                {
                    //OnTokenValidated = async ctx => await AuthenticationMiddleware.SupplyRoleClaimsAsync(ctx)
                };
            });
        }

        /// <summary>
        /// This is virtual so we can inject custom database services in tests.
        /// </summary>
        /// <param name="services"></param>
        protected virtual void ConfigureDatabaseServices(IServiceCollection services)
        {
            //string sqlConnectionString;

            // if (Configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT") == "Development")
            // {
            //     sqlConnectionString = Configuration.GetConnectionString("SqlConnectionString");
            //     if (String.IsNullOrWhiteSpace(sqlConnectionString))
            //     {
            //         sqlConnectionString = GetSqlConnectionStringFromKeyVault();
            //     }
            // }
            // else
            // {
            //     sqlConnectionString = GetSqlConnectionStringFromKeyVault();
            // }

            var sqlConnectionString = Configuration.GetConnectionString("SqlConnectionString");

            if (String.IsNullOrWhiteSpace(sqlConnectionString))
            {
                throw new Exception("SQL connection string was empty!");
            }

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(sqlConnectionString);
                //options.UseLazyLoadingProxies().UseSqlServer(sqlConnectionString);
                //Only use this for debug purposes (https://learn.microsoft.com/nb-no/ef/core/querying/single-split-queries):
                //options.ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
            });
        }


        /// <summary>
        /// Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.WebHostEnvironment = env;
            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseHttpContext();
            app.UseHttpsRedirection();
            app.UseSpaStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "")
                )
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}"
                );
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = "F3C Manager API";
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "F3CManager");
                options.RoutePrefix = "api-docs";
                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "Frontend";

                if (env.IsDevelopment())
                {
                    //Sets the maximum duration that a request will wait for the SPA 
                    //to become ready to serve to the client.
                    spa.Options.StartupTimeout = TimeSpan.FromSeconds(180);
                    spa.Options.DevServerPort = 5173;

                    //The UseSpa middleware handles requests for client scripts and forwards these to the running Vite development server 
                    //on port 5173. Starting the Vite development server is done by abusing the spa.UseReactDevelopmentServer method which 
                    //in fact has nothing to do with React but just executes an npm script in the context of the ASP.NET Core process. 
                    //However, UseReactDevelopmentServer only works properly when the npm script outputs the line ‘Starting the development server’. 
                    //For that reason we have to create that special npm start script in package.json that first echos the ‘Starting the development server’ 
                    //line to keep the middleware happy and then proceeds with starting the Vite development server.
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}