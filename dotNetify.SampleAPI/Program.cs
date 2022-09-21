using DotNetify.SampleAPI.UserPersonaModels;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<UserPIIDbContext>(options =>
                   options.UseNpgsql(builder.Configuration.GetConnectionString("UserPIIPostgres"), options => options.EnableRetryOnFailure(3)));
builder.Services.AddDbContextFactory<UserPersonaDbContext>(options =>
                   options.UseNpgsql(builder.Configuration.GetConnectionString("UserPersonaPostgres"), options => options.EnableRetryOnFailure(3)));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var app = builder.Build();

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
