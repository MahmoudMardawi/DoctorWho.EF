using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using DoctorWho.Db.Contexts;
using System.Data.Entity;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<DoctorWhoCoreDbContext>(options =>
{
    options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DoctorWhoCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
});
var app = builder.Build();
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<DoctorWhoCoreDbContext>())
{
    context.Database.EnsureCreated();
}
