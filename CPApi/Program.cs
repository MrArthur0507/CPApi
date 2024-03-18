using CPApi.Service;
using JudgeSystem.DataAccess.Data;
using JudgeSystem.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
