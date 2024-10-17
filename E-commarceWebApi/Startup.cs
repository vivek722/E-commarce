using E_Commrece.Domain;
using Microsoft.EntityFrameworkCore;
using E_commerce.Ef.Core;
using E_Commrece.Domain.services.User;
using E_commerce.Ef.Core.Repository;
using Newtonsoft.Json;
using E_Commrece.Domain.FireBaseSevice;
using E_commarceWebApi.FireBaseSevice;
using E_Commrece.Domain.services.Employee;
namespace E_commarceWebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment webHost)
        {
            _configuration = configuration;
            _environment = webHost;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Register DbContext with the correct name
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<RoleService>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRoleService, RoleService>();

            services.AddScoped<UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddScoped<CountrieService>();
            services.AddTransient<ICountrieRepository, CountrieRepository>();
            services.AddTransient<ICountrieService, CountrieService>();

            services.AddScoped<EmployeeService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            services.AddScoped<DepartmentService>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IDepartmentService, DepartmentService>();

            services.AddScoped<ProjectService>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IProjectService, ProjectService>();

            services.AddScoped<EmployeeProjectService>();
            services.AddTransient<IEmployeeProjectRepository, EmployeeProjectRepository>();
            services.AddTransient<IEmployeeProjectService, EmployeeProjectService>();


            string bucketName = "e-commerce-593f3.appspot.com";
            string firebaseStorageUrl = $"https://firebasestorage.googleapis.com/v0/b/{bucketName}/o/";

            services.AddSingleton(new FireBaseService(bucketName, firebaseStorageUrl));
            services.AddTransient<IFireBaseUploadImageService, FireBaseUploadImageService>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

            }
            ) ;
            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=WeatherForecast}/{action=Get}");

            app.Run();
        }
    }
}
