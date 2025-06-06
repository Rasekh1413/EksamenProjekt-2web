using EFCZealand.Services;
//using Microsoft.AspNetCore.DataProtection.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IAkademiRepository, AkademiRepository>();
builder.Services.AddSingleton<IStudielederRepository, StudielederRepository>();
builder.Services.AddSingleton<IUddannelseRepository, UddannelseRepository>();
builder.Services.AddSingleton<IFagRepository, FagRepository>();
builder.Services.AddSingleton<ILærerRepository, LærerRepository>();
builder.Services.AddSingleton<IKompetenceRepository, KompetencerRepository>();

builder.Services.AddSingleton<ILærerOgKompetenceAllokeringRepository, LærerOgKompetenceAllokeringRepository>();
builder.Services.AddSingleton<IUddannelseOgLærerAllokeringRepository, UddannelseOgLærerAllokeringRepository>();
builder.Services.AddSingleton<IUddannelseOgFagAllokeringRepository, UddannelseOgFagAllokeringRepository>();



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
