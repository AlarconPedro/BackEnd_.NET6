using API_Alunos.Context;
using API_Alunos.Services.Aluno;
using API_Alunos.Services.Desafio;
using API_Alunos.Services.Evento;
using API_Alunos.Services.Treinador;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var PainelSouMaisFit = "PainelSouMaisFit";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<SouMaisFitContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: PainelSouMaisFit, 
        policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.WithOrigins("http://localhost:3000");
        });
});

// Add services to the container.


var connectionString = builder.Configuration.GetConnectionString("SouMaisFitConnection");

builder.Services.AddDbContext<SouMaisFitContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAuthorization();

builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<ITreinadorService, TreinadorService>();
builder.Services.AddScoped<IDesafioService, DesafioService>();
builder.Services.AddScoped<IEventoService, EventoService>();


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
