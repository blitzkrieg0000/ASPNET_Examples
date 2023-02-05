using CQRS.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson(opt => {
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddDbContext<MainContext>(opt => {
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Local"));
});
builder.Services.AddMediatR(typeof(Program));

var app = builder.Build();
app.MapControllers();
app.Run();
