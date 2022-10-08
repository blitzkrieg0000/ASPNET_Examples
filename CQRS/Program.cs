using CQRS.Data;
using CQRS.CQRS.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson(opt => {
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddDbContext<MainContext>(opt => {
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Local"));
});
builder.Services.AddScoped<GetStudentByIdQueryHandler>();
builder.Services.AddScoped<GetStudentsQueryHandler>();
builder.Services.AddScoped<CreateStudentCommandHandler>();
builder.Services.AddScoped<RemoveStudentCommandHandler>();

var app = builder.Build();
app.MapControllers();
app.Run();
