using BLL.Interface;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//•	CORS טיפול בבעיית  ה
builder.Services.AddCors(opotion => opotion.AddPolicy("AllowAll",//נתינת שם להרשאה
                p => p.AllowAnyOrigin()//מאפשר כל מקור
                .AllowAnyMethod()//כל מתודה - פונקציה
                .AllowAnyHeader()));//וכל כותרת פונקציה

// •	(טיפול באותיות גדולות)
builder.Services.AddControllers()
           .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

//•	הזרקת תלות של מסד הנתונים 

builder.Services.AddDbContext<TravelContext>(
    a => a.UseSqlServer("Server=AVISHAG;Database=Travels;Trusted_Connection=True; TrustServerCertificate=True"));

//•	הזרקת תלות עבור כל ממשק שמתקבל שבבנאי כלשהו
builder.Services.AddScoped(typeof(IOrederPlaceBLL), typeof(IOrederPlaceDAL));
builder.Services.AddScoped(typeof(IOrederPlaceDAL), typeof(IOrederPlaceBLL));

builder.Services.AddScoped(typeof(ITravelTypeBLL), typeof(ITravelTypeDAL));
builder.Services.AddScoped(typeof(ITravelTypeDAL), typeof(ITravelTypeBLL));

builder.Services.AddScoped(typeof(ITripBLL), typeof(ITripDAL));
builder.Services.AddScoped(typeof(ITripDAL), typeof(ITripBLL));

builder.Services.AddScoped(typeof(IUserBLL), typeof(IUserDAL));
builder.Services.AddScoped(typeof(IUserDAL), typeof(IUserBLL));


var app = builder.Build();
app.UseCors("AllowAll");


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
