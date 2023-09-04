using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using DB_Layer.Models;
using Repo_Layer.Repositry;
using Repo_Layer.UnitOfWork;
using System.Text;
using Services_Layer.Services.Product_Services;
using Services_Layer.Services.Pharmacy_Services;
using Services_Layer.Services.Country_Services;
using Services_Layer;
using Repo_Layer.Repositry.Pharmacy_Repo;
using Services_Layer.Services.Distributor_Services;
using Services_Layer.Services.Role_Services;
using Services_Layer.Services.Branch_Services;
using Repo_Layer.Repositry.Branch_Repo;
using Services_Layer.Services.Order_Services;
using Repo_Layer.Repositry.Order_Repo;
using Services_Layer.Services.User_Services;
using System.Net;

namespace Web_api_task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);




            builder.Services.AddAutoMapper(typeof(MappingProfile));
            // Add services to the container.
            #region swagger setting
            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SPOC Orders API",
                    Description = " EvaPharma Company "
                });
                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
{
new OpenApiSecurityScheme
{
Reference = new OpenApiReference
{
Type = ReferenceType.SecurityScheme,
Id = "Bearer"
}
},
new string[] {}
}
    });
            });
            #endregion
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();




            builder.Services.AddDbContext<DataDbContext>(option =>option.UseSqlServer(builder.Configuration.GetConnectionString("server")));

            ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

            builder.Services.AddIdentity<CustomUser, CustomRole>(
                options =>
                {
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    //options.Password.RequiredLength = 6;
                }
                ).AddEntityFrameworkStores<DataDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =
                    JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme =
                    JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration["JWT:Issues"],
                    ValidAudience = builder.Configuration["JWT:Audiance"],
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                };
            });

            // Repositries
            builder.Services.AddScoped<IRepository<Country>, Repository<Country>>();
            builder.Services.AddScoped<IBranchRepository, BranchRepository>();
            builder.Services.AddScoped<IRepository<Distributor>, Repository<Distributor>>();
            builder.Services.AddScoped<IPharmacyRepository, PharmacyRepository>();
            builder.Services.AddScoped<IRepository<Role>, Repository<Role>>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IRepository<Order_Products>, Repository<Order_Products>>();
            builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();

            builder.Services.AddScoped<IUnitOFWork, UnitOFWork>();

            //// Services
            builder.Services.AddScoped<IProductServices,ProductServices>();
            builder.Services.AddScoped<IPharmacyServices, PharmacyServices>();
            builder.Services.AddScoped<ICountryServices, CountryServices>();
            builder.Services.AddScoped<IDistributorServices, DistributorServices>();
            builder.Services.AddScoped<IRoleServices, RoleServices>();
            builder.Services.AddScoped<IBranchServices, BranchServices>();
            builder.Services.AddScoped<IOrderServices, OrderServices>();
            builder.Services.AddScoped<IUserServices, UserServices>();
            






            var app = builder.Build();

                app.UseSwagger();
                app.UseSwaggerUI();



            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseRouting();

           // app.UseCors("mypolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }


}