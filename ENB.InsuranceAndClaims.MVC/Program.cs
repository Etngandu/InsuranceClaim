using AutoMapper;
using ENB.InsuranceAndClaims.EF.Repositories;
using ENB.InsuranceAndClaims.Entities.Repositories;
using ENB.InsuranceAndClaims.Entities;
using ENB.InsuranceAndClaims.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ENB.InsuranceAndClaims.EF;
using ENB.InsuranceAndClaims.MVC.Help;
using AspNetCoreHero.ToastNotification;
using ENB.InsuranceAndClaims.MVC.Factory;
using ENB.InsuranceAndClaims.MVC.Models;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<InsuranceAndClaimsContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("InsuranceClaimsCtr")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
               opt =>
               {
                   opt.Password.RequiredLength = 7;
                   opt.Password.RequireDigit = false;
                   opt.Password.RequireUppercase = false;
               })
                .AddEntityFrameworkStores<InsuranceAndClaimsContext>();

builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, CustomClaimsFactory>();
builder.Services.AddAutoMapper(typeof(InsuranceClaimsProfile));
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddScoped<IAsyncCustomerRepository, AsyncCustomerRepository>();
builder.Services.AddScoped<IAsyncStaffRepository, AsyncStaffRepository>();
builder.Services.AddScoped<IAsyncPolicyTypeRepository, AsyncPolicyTypeRepository>(); 
builder.Services.AddScoped<IAsyncClaimProcessingStageRepository, AsyncClaimProcessingStageRepository>();
builder.Services.AddScoped<IAsyncUnitOfWorkFactory, AsyncEFUnitOfWorkFactory>();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
builder.Services.AddScoped<IValidator<CreateAndEditCustomer>, CreateAndEditCustomerValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
