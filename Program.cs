using DotNetWebProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers() 
   .AddNewtonsoftJson(options =>
   {
       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
   });

// Register your services (Dependency Injection)
builder.Services.AddScoped<InvoiceService, InvoiceService>(); 
builder.Services.AddScoped<ClientService, ClientService>();   
builder.Services.AddScoped<AzureOpenAIService, AzureOpenAIService>();

// Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();

