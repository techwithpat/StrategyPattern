using StrategyPattern.Services;
using StrategyPattern.Services.Export;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IExporter, CsvExporter>();
builder.Services.AddScoped<IExporter, JsonExporter>();
builder.Services.AddScoped<IExporter, XmlExporter>();

builder.Services.AddRazorPages();
builder.Services.AddScoped<IExportService, ExportService>();
builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
