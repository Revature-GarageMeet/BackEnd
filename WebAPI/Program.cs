using System;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Datalayer;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;
using Hubs;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(
    (ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.File("../logs/log.txt", rollingInterval: RollingInterval.Day)
);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
                    {
                        policy.WithOrigins("http://localhost:4200, http://localhost:5205, http://localhost:9876, http://localhost:4201")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                            //.AllowCredentials();
                    });
});

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*Adds signalR to the services*/
builder.Services.AddSignalR();

builder.Services.AddDbContext<GMDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GarageMeetDBDev"))); //REMOVE THE 'Dev' WHEN WE GO TO RELEASE ~Leo
builder.Services.AddScoped<DBInterface, DatabaseCalls>();

var app = builder.Build();
app.MapHub<MessageHub>("/chatsocket");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.UseRouting();
/*Adds the map hub
//app.MapHub<MessageHub>("../Datalayer");
app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
        
        endpoints.MapHub<MessageHub>("/chatsocket");
    });
*/
app.Run();
