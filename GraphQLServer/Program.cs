using GraphQLServer.Data;
using GraphQLServer.Extensions;
using GraphQLServer.GraphQl;
using GraphQLServer.GraphQl.Publicaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

builder.Services.AddGraphQLServer()
    .AddQueryType()
    .AddMutationType()    
    .AddGraphQLServerTypes()
    .RegisterDbContext<Context>()
    .AddProjections().AddFiltering().AddSorting();

builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlogConnection"),
    x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "bg")));

var app = builder.Build();

await app.ConfigMigraciones();

app.UseCors(x => x.AllowAnyHeader().WithMethods("POST").AllowAnyOrigin());

app.MapGraphQL();

app.MapGet("/", () => "Hello World!");

app.Run();

public partial class Program { }