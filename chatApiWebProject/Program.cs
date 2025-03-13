using Microsoft.EntityFrameworkCore;
using SignalRChatServer.Controllers;
using SignalRChatServer.Data;
using SignalRChatServer.Hubs;
using SignalRChatServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSignalR();
builder.Services.AddCors();
builder.Services.AddDbContext<UserDbContext>(options => {
    options.UseMySQL("server=localhost;port=3306;user=root;password=psekwz;database=webchat");
});
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();



var app = builder.Build();
app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(p => {
    p.WithOrigins(["http://localhost:4200","http://localhost:8000"]).AllowAnyHeader().AllowCredentials().AllowAnyMethod();
});
app.MapHub<ChatHub>("/chat/user/10");

app.Run();
