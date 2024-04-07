using Hedin.ChangeTires.Api.Settings;
using Hedin.ChangeTires.Infrastructure;
using Hedin.ChangeTires.Infrastructure.ExternalIntegrations.SlotClient;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

IConfiguration _configuration = builder.Configuration;
IConfigurationSection settingsSection = _configuration.GetSection("Settings");

builder.Services.Configure<ApplicationSettings>(settingsSection);
builder.Services.AddCors();

builder.Services.AddControllers()
    .AddControllersAsServices();

builder.Services
    .AddMvc(options =>
    {
        options.EnableEndpointRouting = false;
    })
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    });

builder.Services.AddExternalSlotApiClient<ApplicationSettings>();
builder.Services.AddInfrastructure();

//Add Health Check for External Service, Db, etc.
builder.Services.AddHealthChecks();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseHsts();

app.UseHttpsRedirection();

app.UseMvc();

app.Run();
