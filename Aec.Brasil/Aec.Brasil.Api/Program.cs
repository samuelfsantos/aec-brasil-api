using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Aec.Brasil.Api.Configurations;
using Aec.Brasil.Api.StartupExtensions;
using Aec.Brasil.Application.MapperProfiles;
using Aec.Brasil.Domain.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.ConfigureContainer();

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddAutoMapper(typeof(CidadeProfile).Assembly);

builder.Services.AddApiConfig();

builder.Services.AddSwagger();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddBrasilApiServiceConfig(builder.Configuration);

var app = builder.Build();




app.UseApiConfig(app.Environment);

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
app.UseSwagger(provider);

app.ApplyMigrations();

app.Run();