using LMS.BL.Managers;
using LMS.DAL.EF;
using LMS.Interface;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddTransient<IBookManager, BookSqlManager>();
builder.Services.AddTransient<IUserManager, UserSqlManager>();
builder.Services.AddDbContext<EntityFramworkContext>(options =>
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LMS;Integrated Security=True"));


//integrate  logger
var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var scope = app.Services.CreateScope();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
