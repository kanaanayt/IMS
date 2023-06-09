using IMS.Plugins.InMemory;
using IMS.Services.Inventories;
using IMS.Services.Inventories.Interfaces;
using IMS.Services.PluginInterfaces;
using IMS.WebApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
builder.Services.AddTransient<IViewInventoriesByNameService, ViewInventoriesByNameService>();
builder.Services.AddTransient<IAddInventoryItemService, AddInventoryItemService>();
builder.Services.AddTransient<IEditInventoryItemService, EditInventoryItemService>();
builder.Services.AddTransient<IGetInventoryByIdService, GetInventoryByIdService>();


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
