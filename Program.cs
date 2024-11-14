using Microsoft.EntityFrameworkCore;
using ComicSystemAPI.Data;  // Thêm dòng này


var builder = WebApplication.CreateBuilder(args);

// Cấu hình DbContext với csdl 
builder.Services.AddDbContext<ComicSystemContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 30))));

// Add controller 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
