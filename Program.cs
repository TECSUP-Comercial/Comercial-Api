using Comercial.Api.Database;
using Comercial.Api.Endpoints;
using Comercial.Api.Extensions;
using Comercial.Api.Repository;
using Comercial.Api.Services.FileStorage;
using Comercial.Api.Services.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
const string cors = "Cors";

string databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: cors,
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.WithOrigins("*");
            corsPolicyBuilder.AllowAnyMethod();
            corsPolicyBuilder.AllowAnyHeader();
        });
});

builder.Services.AddDbContext<ApplicationDbContext>((options) =>
{
    options.UseNpgsql(databaseConnectionString);
});

NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();

builder.Services.TryAddSingleton(npgsqlDataSource);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.SectionName));

builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddSingleton<IFileStorageLocal, FileStorageLocal>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ISeccionRepository, SeccionRepository>();

var app = builder.Build();

app.UseCors(cors);

app.UseSwagger();

app.UseSwaggerUI();

app.ApplyMigrations();

app.MapUsuarioEndpoins();

app.MapGrupoEndpoints();

app.MapMediaEndpoints();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.Run();

public partial class Program;
