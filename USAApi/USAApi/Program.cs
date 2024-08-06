using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using USAApi.Filters;

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
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();


}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
