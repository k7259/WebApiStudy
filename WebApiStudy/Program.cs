using Microsoft.EntityFrameworkCore;
using WebApiStudy.ModelFolder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionstring =
		  "Data Source=DESKTOP-3N1B328;Initial Catalog=PlayerDataBase;Integrated Security=True;  TrustServerCertificate=True;";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDB>
    (options => options.UseSqlServer(connectionstring));
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
