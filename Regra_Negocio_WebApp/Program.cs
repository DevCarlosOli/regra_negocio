
using Regra_Negocio_WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("Regra_Negocio_API", c => {
    c.BaseAddress = new Uri("https://localhost:7155/api/");
    c.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddScoped<RegraNegocioService>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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
