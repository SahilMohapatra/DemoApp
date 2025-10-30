using System;
using BooksManagement.GraphQL;
using BooksManagement.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using BooksManagement.Validators;
using BooksManagement.GraphQL.Mutations;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HealthContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


builder.Services
    .AddGraphQLServer()
    .AddQueryType<BookQuery>()
    .AddMutationType(d => d.Name("Mutation")) 
        .AddTypeExtension<BookMutation>()     
        .AddTypeExtension<ReviewMutation>()   
    .AddProjections()
    .AddFiltering()
    .AddSorting();


builder.Services.AddValidatorsFromAssemblyContaining<ReviewValidator>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});


var app = builder.Build();


app.UseCors("AllowReact");
app.MapGraphQL();


app.Run();
