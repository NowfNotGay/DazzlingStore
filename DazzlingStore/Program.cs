using DazzlingStore.Models;
using DazzlingStore.Models.Services.Interfaces;
using DazzlingStore.Respository;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

builder.Services.AddScoped<IRepository<Account>, AccountRespository<Account>>();
builder.Services.AddScoped<IRepository<AddressProfile>, AddressRespository<AddressProfile>>();
builder.Services.AddScoped<IRepository<Category>, CategoryRespository<Category>>();
builder.Services.AddScoped<IRepository<Color>, ColorRespository<Color>>();
builder.Services.AddScoped<IRepository<Event>, EventRespository<Event>>();
builder.Services.AddScoped<IRepository<Invoice>, InvoiceRespository<Invoice>>();
builder.Services.AddScoped<IRepository<Order>, OrderRespository<Order>>();
builder.Services.AddScoped<IRepository<PaymentMethod>, PaymentRespository<PaymentMethod>>();
builder.Services.AddScoped<IRepository<Product>, ProductRespository<Product>>();
builder.Services.AddScoped<IRepository<Review>, ReviewRespository<Review>>();
builder.Services.AddScoped<IRepository<Role>, RoleRespository<Role>>();
builder.Services.AddScoped<IRepository<Size>, SizeRespository<Size>>();
builder.Services.AddScoped<IRepository<Voucher>, VoucherRespository<Voucher>>();
builder.Services.AddScoped<IRepository<Wishlist>, WishlistRespository<Wishlist>>();
builder.Services.AddScoped<IRepository<SocialAccount>, SocialRespository<SocialAccount>>();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
