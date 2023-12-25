using Microsoft.Extensions.DependencyInjection.Extensions;
using MVCPractice.Controllers;
using MVCPractice.Mappers;
using MVCPractice.Models.dbContext;
using MVCPractice.Processors;
using MVCPractice.Storers;
using MVCPractice.Utilities;
using MVCPractice.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.TryAddScoped(typeof(ILogger<HomeController>), typeof(Logger<HomeController>));
builder.Services.TryAddScoped(typeof(ItemsContext), typeof(ItemsContext));
builder.Services.TryAddScoped(typeof(IUserIdGetter), typeof(UserIdGetter));
builder.Services.TryAddScoped(typeof(IRecordPosterValidator), typeof(RecordPosterValidator));
builder.Services.TryAddScoped(typeof(IGuidCreator), typeof(GuidCreator));
builder.Services.TryAddScoped(typeof(IRecordPosterMapper), typeof(RecordPosterMapper));
builder.Services.TryAddScoped<IRecordPosterStorer>(c => new RecordPosterStorer(c.GetRequiredService<ItemsContext>()));
builder.Services.TryAddScoped<IRecordPosterProcessor>(c => new RecordPosterProcessor(c.GetRequiredService<IRecordPosterValidator>(), c.GetRequiredService<IGuidCreator>(), c.GetRequiredService<IRecordPosterMapper>(), c.GetRequiredService<IRecordPosterStorer>()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.MapControllerRoute(
    name: "GetByUserId",
    pattern: "{controller=Home}/{action=GetByUserId}/{userId}");

app.MapControllerRoute(
    name: "PostUserRecord",
    pattern: "{controller=Home}/{action=PostUserRecord}");

app.Run();
