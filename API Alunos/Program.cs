using API_Alunos.Context;
using Microsoft.AspNetCore.Identity;


var PainelSouMaisFit = "PainelSouMaisFit";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: PainelSouMaisFit, 
        policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.WithOrigins("");
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(PainelSouMaisFit);

app.UseAuthorization();

app.MapControllers();

app.Run();
