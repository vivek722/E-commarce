﻿using E_Commrece.Domain;
using Microsoft.EntityFrameworkCore;
using E_Commrece.Domain.services.User;
using E_commerce.Ef.Core.Repository;
using Newtonsoft.Json;
using E_Commrece.Domain.FireBaseSevice;
using E_commarceWebApi.FireBaseSevice;
using E_Commrece.Domain.services.Employee;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using E_Commrece.Domain.services.productData;
using E_Commrece.Domain.services.Base;
using E_commerce.Ef.Core.Repository.Base;
using E_Commrece.Domain.services.Payment;
using E_Commrece.Domain.Email_SMS_Sender;
using Microsoft.Extensions.DependencyInjection;
using E_Commrece.Domain.services.Admin;
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

            services.AddScoped<ProductService>();
            services.AddTransient<IProductRepository, ProductSupplier>();
            services.AddTransient<IProductService, ProductService>();

            services.AddScoped<SupplierService>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<ISupplierService, SupplierService>();

            services.AddScoped<InventoryService>();
            services.AddTransient<InventoryIRepository, InvenoryRepository>();
            services.AddTransient<InventoryIService, InventoryService>();

            services.AddScoped<warehouseService>();
            services.AddTransient<IWarehouseRepository, warehouseRepository>();
            services.AddTransient<IWarehouseService, warehouseService>();


            services.AddScoped<WishListService>();
            services.AddTransient<IWishlistRepository, WishListRepository>();
            services.AddTransient<IWishListService, WishListService>();

            services.AddScoped<AddToCartService>();        
            services.AddTransient<IAddToCartRepository, AddToCartRepoSitory>();
            services.AddTransient<IAddToCartService, AddToCartService>();

            services.AddScoped<AdminService>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IAdminService, AdminService>();


            services.AddScoped<CustomerPageSettingService>();
            services.AddTransient<ICustomerPageSettingRepository, CustomerPageSettingRepository>();
            services.AddTransient<ICustomerPageSettingService, CustomerPageSettingService>();

            services.AddScoped<SupplierPageSettingService>();
            services.AddTransient<ISupplierPageSettingRepository, SupplierPagesettingRepository>();
            services.AddTransient<ISupplierPageSettingService, SupplierPageSettingService>();

            services.AddScoped(typeof(IGenricRepository<>), typeof(GenericRepository<>));


            var bucketName = "e-commerce-593f3.appspot.com";
            string firebaseStorageUrl = $"https://firebasestorage.googleapis.com/v0/b/{bucketName}/o/";

            services.AddSingleton(new FireBaseService(bucketName, firebaseStorageUrl));
            services.AddTransient<IFireBaseUploadImageService, FireBaseUploadImageService>();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JWTToken_Auth_API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

            }
            );

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options => {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidAudience = _configuration["JWT:ValidAudience"],
                        ValidIssuer = _configuration["JWT:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]))
                    };
                });
            
            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();
            app.UseCors("MyCorsPolicy");
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=WeatherForecast}/{action=Get}");
            app.Run();
        }
    }
}
