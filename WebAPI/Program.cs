using Autofac;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.DependencyResolvers;
using Core.Utilities.Security.JWT;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Security.Encryption;
using Business.DependencyResolvers.Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

var tokenOptions = new TokenOptions();
builder.Configuration.GetSection("TokenOptions").Bind(tokenOptions);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
    };
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // containerBuilder.RegisterModule(new CoreModule());
    containerBuilder.RegisterModule(new AutofacBusinessModule());
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule(),
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();