using HouseUtils.Presentation;
using HouseUtils.Presentation.Res;

internal class Program
{
   private static void Main (string[] args)
   {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.
      builder.Services.AddControllersWithViews();
      builder.Services.AddHandlers();
      builder.Services.AddValidation();
      builder.Services.AddProviders();
      builder.Services.AddPersistence();
      builder.Services.AddResources();

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

      app.MapAreaControllerRoute(
         "area_register",
         "register",
         "register/{controller=Home}/{action=Index}/{id?}");

      app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");

      app.Run();
   }
}