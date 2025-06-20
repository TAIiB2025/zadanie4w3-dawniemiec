using BLL;
using FluentValidation;
using IBL;
using IBL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFilmyService, FilmyService>();
builder.Services.AddValidatorsFromAssemblyContaining<FilmPostDTO>();
builder.Services.AddCors(corsBuilder =>
    corsBuilder.AddPolicy("CORSpolicy",
        policyBuilder => policyBuilder
            .AllowAnyHeader()
                .AllowAnyMethod()
                    .AllowAnyOrigin()
                        .Build()
                        )
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CORSpolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
