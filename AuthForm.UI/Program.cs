using AuthForm.Application;
using AuthForm.Application.Mapping;
using AuthForm.Infrastucture;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Configuration
.AddJsonFile($"appsettings.json", optional: false)
.AddJsonFile($"appsettings.Environment.json", optional: true)
.AddEnvironmentVariables()
.Build();
builder.Services.AddDbContext<AuthFormDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConneection")));
builder.Services.RegistrationLogger();
builder.Services.RegistrationMapp();
builder.Services.RegistrationRepositories();
builder.Services.RegistrationServices();
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddControllers();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
