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

//�	CORS ����� ������  �
builder.Services.AddCors(opotion => opotion.AddPolicy("AllowAll",//����� �� ������
                p => p.AllowAnyOrigin()//����� �� ����
                .AllowAnyMethod()//�� ����� - �������
                .AllowAnyHeader()));//��� ����� �������

// �	(����� ������� ������)
builder.Services.AddControllers()
           .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

//�	����� ���� �� ��� ������� 

builder.Services.AddDbContext<TravelContext>(
    a => a.UseSqlServer("Server=AVISHAG;Database=Travels;Trusted_Connection=True; TrustServerCertificate=True"));

//�	����� ���� ���� �� ���� ������ ������ �����
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
