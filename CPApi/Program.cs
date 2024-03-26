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
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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

builder.Services.AddAuthentication().AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Jwt:Key"))),
        };
    });

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
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
builder.Services.AddScoped<IProblemService, ProblemService>();
builder.Services.AddScoped<IProblemDetailService, ProblemDetailService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapIdentityApi<ApplicationUser>();

app.Run();
