using Biblioteca.Rest.Services.Services.Implementations;
using Biblioteca.Rest.Services.Services.Interfaces;
using BibliotecaRest.Data.Data;
using EcommerRest.Services.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// conexion dbContext
var connection = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        connection,
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name) // ← automático
    )
);

builder.Services.Configure<UploadSettings>(
    builder.Configuration.GetSection("UploadSettings"));

builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<UploadSettings>>().Value);

#region
// uno por request
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAuthosService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();



#endregion

var app = builder.Build();
app.UseCors("AllowAngularApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Uploads") // Ajusta "Uploads" si está en otra subcarpeta
    ),
    RequestPath = "/Uploads"
});


app.UseAuthorization();

app.MapControllers();

app.Run();
