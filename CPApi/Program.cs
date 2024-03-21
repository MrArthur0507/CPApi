using CPApi.Service;
using JudgeSystem.Core.CompilerComponent.Services.Implementation;
using JudgeSystem.Core.CompilerComponent.Services.Interfaces;
using JudgeSystem.Core.ExecutorComponent.Services.Implementation;
using JudgeSystem.Core.ExecutorComponent.Services.Interfaces;
using JudgeSystem.Core.SubmissionComponent.Services.Implementation;
using JudgeSystem.Core.SubmissionComponent.Services.Interfaces;
using JudgeSystem.DataAccess.Data;
using JudgeSystem.Models.User;
using JudgeSystem.Services.Implementations;
using JudgeSystem.Services.Interfaces;
using JudgeSystem.Services.MappingProfiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Add JWT Authentication to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
});



builder.Services.AddMvc();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JudgeDataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"), b => b.MigrationsAssembly("JudgeSystem.DataAccess"))
);

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<ApplicationUser>().AddEntityFrameworkStores<JudgeDataContext>();

builder.Services.AddCors();
builder.Services.AddScoped<IBasicCompilerService, BasicCompilerService>();
builder.Services.AddScoped<ISubmissionHandling, SubmissionHandling>();
builder.Services.AddScoped<ISubmissionSaver, SubmissionSaver>();
builder.Services.AddScoped<ISubmissionValidator, SubmissionValidator>();
builder.Services.AddScoped<ICompiler, BasicCSharpCompiler>();
builder.Services.AddScoped<IExecutor, BasicCSharpExecutor>();
builder.Services.AddScoped<ISubmissionService, SubmissionService>();
builder.Services.AddAutoMapper(typeof(JudgeMappingProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.MapIdentityApi<ApplicationUser>(); 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
