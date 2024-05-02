var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();


// using DAL;
// using Services;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.OpenApi.Models;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// builder.Services.AddDbContext<User_RegistrationContext>(options =>
// {
//     options.UseMySQL(connectionString);
// });
// builder.Services.AddScoped<IUser_RegistrationService, User_RegistrationService>(); //Add dependency injection
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();

// // Add CORS services
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("CorsPolicy",
//         builder =>
//         {
//             builder.WithOrigins("http://localhost:3000") // Specify your allowed origins here
//                    .AllowAnyMethod()
//                    .AllowAnyHeader();
//         });
// });



// var app = builder.Build();

// // Use CORS
// app.UseCors("CorsPolicy");

// app.UseHttpsRedirection();
// app.UseAuthorization();
// app.MapControllers();

// app.Run();

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// builder.Services.AddDbContext<User_RegistrationContext>(options =>
// {
//     options.UseMySQL(connectionString);
// });
// builder.Services.AddScoped<IUser_RegistrationService, User_RegistrationService>(); //Add dependency injection
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Home/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }

// app.UseHttpsRedirection();
// app.UseStaticFiles();
// app.UseRouting();
// app.UseAuthorization();

// // app.UseHttpsRedirection();
// // app.UseAuthorization();
//  app.MapControllers();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

// app.Run();
