using Microsoft.EntityFrameworkCore;
using NLog.Web;
using ToDoList.DAL;
using ToDoList.Presentation;

WebApplicationBuilder applicationBuilder = WebApplication.CreateBuilder(args);

applicationBuilder.Logging.ClearProviders();
applicationBuilder.Logging.SetMinimumLevel(LogLevel.Trace);
applicationBuilder.Host.UseNLog();

// Add services to the container.
applicationBuilder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

applicationBuilder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(applicationBuilder.Configuration.GetConnectionString("DefaultConnection"));
});

applicationBuilder.Services.InitializeRepositories();
applicationBuilder.Services.InitializeServices();

WebApplication webApplication = applicationBuilder.Build();

// Configure the HTTP request pipeline.
if (!webApplication.Environment.IsDevelopment())
{
    webApplication.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    webApplication.UseHsts();
}

webApplication.UseHttpsRedirection();
webApplication.UseStaticFiles();

webApplication.UseRouting();

webApplication.UseAuthorization();

webApplication.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=CreateTask}/{id?}");

webApplication.Run();