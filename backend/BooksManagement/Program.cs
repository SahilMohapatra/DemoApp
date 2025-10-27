using BooksManagement.GraphQL;
using BooksManagement.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();

var config = provider.GetRequiredService<IConfiguration>();


builder.Services.AddDbContext<HealthContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<BookQuery>()
    .AddMutationType<BookMutation>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
}
);

var app = builder.Build();

app.UseCors("AllowReact");

app.MapGraphQL();

app.Run();
