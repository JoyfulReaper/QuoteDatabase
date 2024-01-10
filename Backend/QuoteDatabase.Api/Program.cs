using Microsoft.EntityFrameworkCore;
using QuoteDatabase.Api;
using QuoteDatabase.Repository;
using QuoteDatabase.Repository.Entities;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<QuoteDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IQuoteRepository, QuoteRepository>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<ISongRepository, SongRepository>();

builder.Services.AddCors(options =>
    options.AddPolicy(name: "localhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("localhost");

app.AddBookEndpoints();
app.AddQuoteEndpoints();
app.AddMovieEndpoints();
app.AddPersonEndpoints();
app.AddSongEndpoints();

app.Run();
