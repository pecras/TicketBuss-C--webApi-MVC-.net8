using Microsoft.EntityFrameworkCore;
using TicketBuss.Models;



var builder = WebApplication.CreateBuilder(args);

var connec = builder.Configuration.GetConnectionString(name:"DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<ApiDbContext>(optionsAction:options =>
options.UseSqlite(connec));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





// Configurar CORS para permitir todas as origens
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        corsBuilder => corsBuilder.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    // Usar CORS que permite todas as origens
    app.UseCors("AllowAll");
}
else
{
    // Permitir todas as origens também em produção (para testes ou outras situações)
    app.UseCors("AllowAll");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

class ApiDbContext:DbContext
{
  public virtual DbSet<Passenger> Passengers{get;set;}
  
   public ApiDbContext(DbContextOptions<ApiDbContext> options)
   :base(options)
   {
    
   }

};