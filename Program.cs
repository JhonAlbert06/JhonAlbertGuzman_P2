using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Blazored.Toast;
using JhonAlbertGuzman_P2.BLL;
using JhonAlbertGuzman_P2.DAL;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Aqui inyectamos el DbContext
builder.Services.AddDbContext<Contexto>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("ConStr"))    
);

builder.Services.AddBlazoredToast();
builder.Services.AddTransient<ProductoBLL>();
builder.Services.AddTransient<ProductoEmpaqueBLL>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
