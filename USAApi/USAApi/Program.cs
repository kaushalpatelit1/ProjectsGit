using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using USAApi.Filters;
using USAApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(opt => opt.LowercaseUrls = true); // lower case urls settings in middleware
builder.Services.AddApiVersioning(opt => {
    opt.DefaultApiVersion = new ApiVersion(1, 0); //providing default API version
    opt.ApiVersionReader = new MediaTypeApiVersionReader(); // using media type api reader
    opt.AssumeDefaultVersionWhenUnspecified = true; // it will assume default version when not specified.
    opt.ReportApiVersions = true; // report api version to the browser
    opt.ApiVersionSelector = new CurrentImplementationApiVersionSelector(opt); //defines the behavior of how an API version is selected for a given request context. 
});

builder.Services.AddMvc(opt =>
{
    opt.Filters.Add<JsonExceptionFilter>();
    opt.Filters.Add<RequireHttpsOrCloseAttribute>();
});
builder.Services.AddCors(opt =>
{
    //opt.AddPolicy("AllowMyApp", policy => policy.WithOrigins("https://example.com")); //to add cors policy with specific origins policy.
    opt.AddPolicy("AllowMyApp", policy => policy.AllowAnyOrigin()); //to add cors policy with any origins, use for developers testing.
});
builder.Services.Configure<HotelInfo>(
    builder.Configuration.GetSection("Info"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("AllowMyApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
